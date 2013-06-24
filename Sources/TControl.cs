using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Threading;

namespace TDRFree
{
  class TControl
  {
    TDataManager DataManager;

    private System.Windows.Forms.RichTextBox LogBox;
    private List<TPlot> Plot;
    private List<TPoint> Top;
    private List<TPoint> Bottom;
    private List<TPoint> Left;
    private List<TPoint> Right;
    private List<TMoistureClass> MoistureClass;
    private List<TDerivedClass> DerivedClass;
    private List<TMeteo> Precipitation;
    private List<TMeteo> Irrigation;
    private TDrawing MyDrawing;
    private String[,] MoistureContent;
    private ProgressBar brPoints;
    private ProgressBar brTimes;
    private String PPTFile;
    private String PrecipitationFile;
    private Boolean IrrigationRequired;
    private String IrrigationFile;
    public String OutputDir;
    private Boolean PPTRequired;
    private TPPT PPT;
    public DateTime FirstDay;
    public DateTime LastDay;
    private DateTime FirstDayWithData;
    private DateTime LastDayWithData;
    private Steema.TeeChart.TChart chrtPrec1;
    private Steema.TeeChart.TChart chrtPrec2;
    private Int32 PrecipitationInterval;
    private Bitmap TotalBitmap;
    private Graphics MyGraph;
    private TLegend MyMoistureLegend;
    private TLegend MyDerivedLegend;
    private List<TPlotToShow> PlotToShow;
    private Color BackgroundColor;
    private Color TextColor;
    private Color PrecipitationColor;
    private Color IrrigationColor;
    public Boolean Running;
    public Boolean CreatingPicture;
    private TAssignmentMethod AssignmentMethod;


    //
    //**********************************************************************************************
    //
    // Class TControl
    //   Part of  : TDRFree
    //   Function : All controlling routines
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TControl()
    {
      DataManager = new TDataManager();
    }

    //
    //**********************************************************************************************
    //

    public void ShowInitialValues(System.Windows.Forms.TextBox aMoisture,
                                  System.Windows.Forms.TextBox aPrecipitation,
                                  System.Windows.Forms.TextBox aIrrigation,
                                  System.Windows.Forms.TextBox aOutputDir,
                                  System.Windows.Forms.CheckBox aCheck,
                                  System.Windows.Forms.CheckBox aPPTCheck,
                                  System.Windows.Forms.TextBox aPPTFile)
    {
      aMoisture.Text = DataManager.InitialMoistureFile;
      aPrecipitation.Text = DataManager.InitialPrecFile;
      aIrrigation.Text = DataManager.InitialIrrigFile;
      aOutputDir.Text = DataManager.InitialOutputDir;
      aCheck.Checked = DataManager.InitialIrrigPresent;
      aPPTCheck.Checked = DataManager.InitialPPTRequired;
      aPPTFile.Text = DataManager.InitialPPTFile;
    }

    //
    //**********************************************************************************************
    //

    private void SetDateFormat()
    {
      CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
      String DateTimeFormat = DataManager.ReadDateFormat();
      String DateFormat = "";
      String TimeFormat = "";
      if (DateTimeFormat.IndexOf(" ") > 0)
      {
        DateFormat = DateTimeFormat.Substring(0, DateTimeFormat.IndexOf(" "));
        TimeFormat = DateTimeFormat.Substring(DateTimeFormat.IndexOf(" ") + 1, DateTimeFormat.Length - DateTimeFormat.IndexOf(" ") - 1);
        culture.DateTimeFormat.ShortDatePattern = DateFormat;
        culture.DateTimeFormat.ShortTimePattern = TimeFormat;
        Thread.CurrentThread.CurrentCulture = culture;
      }
      else
      {
        culture.DateTimeFormat.ShortDatePattern = DateTimeFormat;
      }
    }
    

        
    //
    //**********************************************************************************************
    //

    public Boolean InitializeControl(System.Windows.Forms.PictureBox aPicture,
                    System.Windows.Forms.RichTextBox aLog,
                    System.Windows.Forms.ProgressBar aTimeBar,
                    System.Windows.Forms.ProgressBar aPointBar,
                    System.Windows.Forms.Button aBackgroundButton,
                    System.Windows.Forms.Button aTextButton,
                    System.Windows.Forms.Button aPrecipitationButton,
                    System.Windows.Forms.Button aIrrigationButton,
                    String aFile,
                    String aPrecipitationFile,
                    Boolean aIrrigationRequired,
                    String aIrrigationFile,
                    String aPPTFile,
                    Boolean aPPTRequired,
                    String aOutputDir,
                    Steema.TeeChart.TChart achrtPrec1)
    {
      Boolean success = false;
      if (!Directory.Exists(aOutputDir))
      {
        if (MessageBox.Show("Output dir " + aOutputDir + " does not exist. Create it?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          Directory.CreateDirectory(aOutputDir);
        }
      }
      if (Directory.Exists(aOutputDir))
      {
        try
        {
          Running = false;
          brTimes = aTimeBar;
          PrecipitationFile = aPrecipitationFile;
          brPoints = aPointBar;
          LogBox = aLog;
          OutputDir = aOutputDir;
          LogBox.Clear();
          LogBox.AppendText("Started at " + DateTime.Now.ToString() + "\n");
          Top = new List<TPoint>();
          Bottom = new List<TPoint>();
          Left = new List<TPoint>();
          Right = new List<TPoint>();
          IrrigationRequired = aIrrigationRequired;
          IrrigationFile = aIrrigationFile;
          PPTFile = aPPTFile;
          PPTRequired = aPPTRequired;
          chrtPrec1 = achrtPrec1;
          PlotToShow = new List<TPlotToShow>();

          if (PPTRequired)
          {
            PPT = new TPPT();
          }

          DataManager.SaveToIniFile(aFile, aPrecipitationFile, aIrrigationFile, aOutputDir, aIrrigationRequired, aPPTRequired, aPPTFile);
          DataManager.ReadExcelFile(aFile);

          if (DataManager.ExcelIsAvailable)
          {

            SetDateFormat();

            TotalBitmap = new Bitmap(800, 600);
            //        TotalBitmap.SetResolution(300, 300);
            DataManager.ReadContourSheet(Top, Right, Bottom, Left);
            MyDrawing = new TDrawing(BackgroundColor, TextColor);
            //      MyDrawing.DrawContours(Top, Right, Bottom, Left);
            MyGraph = Graphics.FromImage(TotalBitmap);

            Int32 NumberOfPlots = DataManager.ReadNumberOfPlots();

            AssignmentMethod = DataManager.ReadAssignmentMethod();

            Plot = new List<TPlot>();
            for (Int32 i = 0; i < NumberOfPlots; i++)
            {
              TPlot MyPlot = new TPlot(i);
              MyPlot.AddBoundaries(Top, Bottom, Left, Right);
              MyPlot.AssignmentMethod = AssignmentMethod;

              Plot.Add(MyPlot);
            }

            DataManager.ReadPlotDescription(Plot);
            DataManager.ReadVisualization(PlotToShow);

            DistributePlots();

            for (Int32 i = 0; i < NumberOfPlots; i++)
            {
              DataManager.ReadNodes(Plot[i].Node, i);
              DataManager.ReadElements(Plot[i].Node, Plot[i].Element, i);
              DataManager.ReadVirtualNodes(Plot[i].VirtualNode, i);
            }

            foreach (TPlotToShow MyPlot in PlotToShow)
            {
              Plot[MyPlot.PlotId].PrepareAndDrawGrid(MyPlot.ItemToVisualize);
            }

            DefineFirstAndLastNode();

            CreateTotalBitmap(false);

            SaveGraph(OutputDir, -100);

            MoistureClass = new List<TMoistureClass>();
            DerivedClass = new List<TDerivedClass>();
            DataManager.ReadDerivativeTables(Plot);
            DataManager.ReadMoistureClasses(MoistureClass, DerivedClass);

            MyMoistureLegend = new TLegend(Color.Black, Color.White);
            MyMoistureLegend.SetDrawingArea(800, 600);
            MyMoistureLegend.DrawLegend(MoistureClass);

            MyDerivedLegend = new TLegend(Color.Black, Color.White);
            MyDerivedLegend.SetDrawingArea(800, 600);
            MyDerivedLegend.DrawDerivedLegend(DerivedClass);

            String FileName = SaveGraph(OutputDir, -10);
            if (PPTRequired)
            {
              PPT.AddPictureToSlide(FileName);
            }
            FileName = SaveGraph(OutputDir, -11);
            if (PPTRequired)
            {
              PPT.AddPictureToSlide(FileName);
            }

            MoistureContent = DataManager.ReadMoistureContents();

            FindFirstAndLastDay();

            PrecipitationInterval = DataManager.ReadPInterval();

            ReadColors(aBackgroundButton, aTextButton, aPrecipitationButton, aIrrigationButton);

            DataManager.CloseExcelFile();

            Precipitation = DataManager.ReadPrecipitation(PrecipitationFile, FirstDay, LastDay);
            if (IrrigationRequired)
            {
              Irrigation = DataManager.ReadIrrigation(IrrigationFile);
            }

            DataManager.QuitExcel();

            chrtPrec2 = new Steema.TeeChart.TChart();

            // precipitation
            Steema.TeeChart.Styles.Bar NewSeries = new Steema.TeeChart.Styles.Bar();
            NewSeries.XValues.DateTime = true;
            NewSeries.Color = PrecipitationColor;
            NewSeries.Marks.Visible = false;
            NewSeries.Pen.Visible = false;
            chrtPrec2.Series.Add(NewSeries);

            // irrigation
            NewSeries = new Steema.TeeChart.Styles.Bar();
            NewSeries.XValues.DateTime = true;
            NewSeries.Color = IrrigationColor;
            NewSeries.Marks.Visible = false;
            NewSeries.Pen.Visible = false;
            chrtPrec2.Series.Add(NewSeries);

            // line
            Steema.TeeChart.Styles.Line Line = new Steema.TeeChart.Styles.Line();
            Line.Color = Color.Red;
            Line.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
            Line.XValues.DateTime = true;
            chrtPrec2.Axes.Right.Automatic = false;
            chrtPrec2.Axes.Right.Minimum = 0.0;
            chrtPrec2.Axes.Right.Maximum = 1.0;
            chrtPrec2.Axes.Right.Visible = false;
            chrtPrec2.Series.Add(Line);

            // clear
            chrtPrec1.Series[0].Clear();
            chrtPrec1.Series[1].Clear();
            chrtPrec1.Series[2].Clear();
            chrtPrec2.Series[0].Clear();
            chrtPrec2.Series[1].Clear();
            chrtPrec2.Series[2].Clear();

            ShowPrecipitation(1);
            ShowPrecipitation(2);

            //      MyDrawing.SaveGraph(OutputDir, -1);
          }
          LogBox.AppendText(@"Data read at " + DateTime.Now.ToString());
          success = true;
        }
        catch (Exception e)
        {
          String ErrorMessage = @"Error in input data : " + e.Message;
          MessageBox.Show(ErrorMessage);
          LogBox.AppendText(ErrorMessage);
        }
      }
      return success;
    }

    //
    //**********************************************************************************************
    //

    private void SetPropertiesOfPrec2()
    {
      chrtPrec2.Height = 99;
      chrtPrec2.Width = 800;
      chrtPrec2.Panel.Color = BackgroundColor;
      chrtPrec2.Panel.Bevel.ColorOne = BackgroundColor;
      chrtPrec2.Panel.Bevel.ColorTwo = BackgroundColor;
      chrtPrec2.Panel.Brush.Color = BackgroundColor;
      chrtPrec2.Panel.Gradient.Visible = false;
      chrtPrec2.Panel.Shadow.Visible = false;
      chrtPrec2.Panel.Transparent = false;
      chrtPrec2.BackColor = BackgroundColor;
      chrtPrec2.Legend.Visible = false;
      chrtPrec2.Footer.Visible = false;
      chrtPrec2.Chart.Aspect.View3D = false;
      chrtPrec2.Panel.Pen.Color = TextColor;
      chrtPrec2.Header.Font.Color = TextColor;
      chrtPrec2.Walls.Right.Color = BackgroundColor;
      chrtPrec2.Walls.Back.Color = BackgroundColor;
      chrtPrec2.Walls.Visible = false;

      chrtPrec2.Axes.Bottom.AxisPen.Color = TextColor;
      chrtPrec2.Axes.Bottom.Title.Color = TextColor;
      chrtPrec2.Axes.Bottom.Ticks.Color = TextColor;
      chrtPrec2.Axes.Bottom.Labels.Color = TextColor;
      chrtPrec2.Axes.Bottom.Grid.Color = TextColor;
      chrtPrec2.Axes.Bottom.MinorTicks.Color = TextColor;
      chrtPrec2.Axes.Bottom.Labels.Font.Color = TextColor;

      chrtPrec2.Axes.Left.AxisPen.Color = TextColor;
      chrtPrec2.Axes.Left.Title.Color = TextColor;
      chrtPrec2.Axes.Left.Ticks.Color = TextColor;
      chrtPrec2.Axes.Left.Labels.Color = TextColor;
      chrtPrec2.Axes.Left.Grid.Color = TextColor;
      chrtPrec2.Axes.Left.MinorTicks.Color = TextColor;
      chrtPrec2.Axes.Left.Labels.Font.Color = TextColor;
    }

    //
    //**********************************************************************************************
    //

    private void ReadColors(System.Windows.Forms.Button aBackgroundButton, System.Windows.Forms.Button aTextButton, 
      System.Windows.Forms.Button aPrecipitationButton, System.Windows.Forms.Button aIrrigationButton)
    {
      aBackgroundButton.BackColor = DataManager.ReadBackgroundColor();
      aTextButton.BackColor = DataManager.ReadTextColor();
      aPrecipitationButton.BackColor = DataManager.ReadPrecipitationColor();
      aIrrigationButton.BackColor = DataManager.ReadIrrigationColor();
    }

    //
    //**********************************************************************************************
    //

    public void SetColors(System.Windows.Forms.Button aBackColorButton, System.Windows.Forms.Button aTextColorButton,
      System.Windows.Forms.Button aPrecipitationColorButton, System.Windows.Forms.Button aIrrigationColorButton)
    {
      BackgroundColor = aBackColorButton.BackColor;
      TextColor = aTextColorButton.BackColor;
      PrecipitationColor = aPrecipitationColorButton.BackColor;
      IrrigationColor = aIrrigationColorButton.BackColor;

      SetPropertiesOfPrec2();

      chrtPrec2.Series[0].Color = PrecipitationColor;
      chrtPrec2.Series[1].Color = IrrigationColor;
    }

    //
    //**********************************************************************************************
    //

    public void ShowDataForEachDay(System.Windows.Forms.PictureBox aPicture, Color aBackgroundColor, Color aTextColor,
      System.Windows.Forms.Button aButton)
    {
      BackgroundColor = aBackgroundColor;
      TextColor = aTextColor;

      aButton.Enabled = false;

      foreach (TPlot MyPlot in Plot)
      {
        MyPlot.SetBackgoundColor(BackgroundColor);
      }


      SetPropertiesOfPrec2();

      ShowMoistureContents(aPicture);

      if (PPTRequired)
      {
        PPT.SavePresentation(PPTFile);
      }
      aButton.Enabled = true;
      LogBox.AppendText("Stopped at " + DateTime.Now.ToString() + "\n");
    }

    //
    //**********************************************************************************************
    //

    private void CreateTotalBitmap(Boolean aLegend)
    {
      Color MyColor = BackgroundColor;
      for (Int32 i = 0; i <= TotalBitmap.Width - 1; i++)
      {
        for (Int32 j = 0; j <= TotalBitmap.Height - 1; j++)
        {
          TotalBitmap.SetPixel(i, j, MyColor);
        }
      }

      if (aLegend)
      {
        MyGraph.DrawImageUnscaled(MyMoistureLegend.GetBitmap(true), 0, 0);
      }
      else
      {
        if (chrtPrec2 != null)
        {
          MyGraph.DrawImageUnscaled(chrtPrec2.Bitmap, 0, 0);
        }

        if (PlotToShow.Count == 1)
        {
          Int32 Offset = 100;
          foreach (TPlotToShow MyPlotToShow in PlotToShow)
          {
            TPlot MyPlot = Plot[MyPlotToShow.PlotId];
            Bitmap MyBitmap = MyPlot.GetBitmap(MyPlotToShow.ItemToVisualize);
            MyGraph.DrawImageUnscaled(MyBitmap, 0, Offset);
          }

        }

        if (PlotToShow.Count == 2)
        {      
          Int32 Offset = 100;
          Int32 PlotNumber = -1;
          foreach (TPlotToShow MyPlotToShow in PlotToShow)
          {
            PlotNumber = PlotNumber + 1;
            Offset = Offset + PlotNumber * 250;
            TPlot MyPlot = Plot[MyPlotToShow.PlotId];
            Bitmap MyBitmap = MyPlot.GetBitmap(MyPlotToShow.ItemToVisualize);
            MyGraph.DrawImageUnscaled(MyBitmap, 0, Offset);
          }
        }

        if (PlotToShow.Count == 3)
        {
          Int32 OffsetBase = 100;
          Int32 PlotNumber = -1;
          foreach (TPlotToShow MyPlotToShow in PlotToShow)
          {
            PlotNumber = PlotNumber + 1;
            Int32 Offset = OffsetBase + PlotNumber * 166;
            TPlot MyPlot = Plot[MyPlotToShow.PlotId]; 
            Bitmap MyBitmap = MyPlot.GetBitmap(MyPlotToShow.ItemToVisualize);
            MyGraph.DrawImageUnscaled(MyBitmap, 0, Offset);
          }
        }

        if (PlotToShow.Count == 4)
        {
          Int32 OffsetBase = 100;
          Int32 PlotNumber = -1;
          foreach (TPlotToShow MyPlotToShow in PlotToShow)
          {
            PlotNumber = PlotNumber + 1;
            Int32 Offset = OffsetBase + PlotNumber * 125;
            TPlot MyPlot = Plot[MyPlotToShow.PlotId];
            Bitmap MyBitmap = MyPlot.GetBitmap(MyPlotToShow.ItemToVisualize);
            MyGraph.DrawImageUnscaled(MyBitmap, 0, Offset);
          }
        }
      }
    }

    //
    //**********************************************************************************************
    //

    private void DefineFirstAndLastNode()
    {
      Int32 LastNode = -1;
      Int32 FirstNode = 0;
      for (Int32 i = 0; i < Plot.Count; i++)
      {
        FirstNode = LastNode + 1;
        LastNode = FirstNode + Plot[i].Node.Count-1;
        Plot[i].FirstNode = FirstNode;
        Plot[i].LastNode = LastNode;
      }
    }

    //
    //**********************************************************************************************
    //

    private void DistributePlots()
    {
      Int32 PlotHeight = 0;
      Int32 PlotWidth = 0;
      if (PlotToShow.Count == 1)
      {
        PlotHeight = 500;
        PlotWidth = 800;
      }
      else
      {
        if (PlotToShow.Count == 2)
        {
          PlotHeight = 245;
          PlotWidth = 800;
        }
        else
        {
          if (PlotToShow.Count == 3)
          {
            PlotHeight = 165;
            PlotWidth = 800;
          }
          else
          {
            PlotHeight = 120;
            PlotWidth = 800;
          }
        }
      }
      foreach (TPlot MyPlot in Plot)
      {
          MyPlot.SetDrawingArea(PlotWidth, PlotHeight);
      }
    }

    //
    //**********************************************************************************************
    //

    public void FindNewStartAndEnd(Double aFraction)
    {
      Int64 Delta;
      if (aFraction < 0.0)
      {
        FirstDay = FirstDayWithData;
        LastDay = LastDayWithData;
      }
      else
      {
        Delta = Convert.ToInt64(aFraction * (LastDay.Ticks - FirstDay.Ticks));
        if (aFraction < 0.5)
        {
          FirstDay = FirstDay.AddTicks(Delta);
        }
        else
        {
          LastDay = FirstDay.AddTicks(Delta);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void ShowPrecipitation(Int32 aChart)
    {
      DateTime MyDate;
      Double P = 0.0;

      if (aChart == 1)
      {
        chrtPrec1.Series[0].Clear();
        chrtPrec1.Axes.Bottom.Automatic = true;
        chrtPrec1.Axes.Left.Automatic = true;

        Boolean LegendVisible = false;
        if ((Precipitation != null) & (Irrigation != null))
        {
          LegendVisible = ((Precipitation.Count > 0) & (Irrigation.Count > 0));
        }
        chrtPrec1.Legend.Visible = LegendVisible;
        chrtPrec1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
        chrtPrec1.Update();
      }
      else
      {
        chrtPrec2.Series[0].Clear();
        chrtPrec2.Axes.Bottom.Automatic = true;
        chrtPrec2.Axes.Left.Automatic = true;
        chrtPrec2.Update();
      }

      DateTime PreviousDate;
      MyDate = Convert.ToDateTime(MoistureContent[1, 0]);
      while (MyDate < LastDay)
      {
        PreviousDate = MyDate;
        MyDate = PreviousDate.AddHours(PrecipitationInterval);
        P = 0.0;
        for (Int32 j = 0; j <= Precipitation.Count - 1; j++)
        {
          if (Precipitation[j].Date > PreviousDate)
          {
            if (Precipitation[j].Date <= MyDate)
            {
              P = P + Precipitation[j].Value;
            }
            else
            {
              break;
            }
          }
        }
        
        if (aChart == 1)
        {
          chrtPrec1.Series[0].Add(MyDate, P);
        }
        else
        {
          chrtPrec2.Series[0].Add(MyDate, P);
        }
      }

      // irrigation
      if(aChart == 1)
      {
        chrtPrec1.Series[1].Clear();
      }
      else
      {
        chrtPrec2.Series[1].Clear();
      }

      if ((IrrigationRequired) & (Irrigation != null))
      {
        foreach (TMeteo MyIrrig in Irrigation)
        {
          if ((MyIrrig.Date >= FirstDay) & (MyIrrig.Date <= LastDay))
          {
            if (aChart == 1)
            {
              chrtPrec1.Series[1].Add(MyIrrig.Date, MyIrrig.Value);
            }
            else
            {
              chrtPrec2.Series[1].Add(MyIrrig.Date, MyIrrig.Value);
            }
          }
        }
      }

      if (aChart == 1)
      {
        chrtPrec1.Axes.Bottom.Automatic = false;
        chrtPrec1.Axes.Bottom.Minimum = FirstDay.ToOADate();
        chrtPrec1.Axes.Bottom.Maximum = LastDay.ToOADate();
        chrtPrec1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
        chrtPrec1.Update();
      }
      else
      {
        chrtPrec2.Axes.Bottom.Automatic = false;
        chrtPrec2.Axes.Bottom.Minimum = FirstDay.ToOADate();
        chrtPrec2.Axes.Bottom.Maximum = LastDay.ToOADate();
        chrtPrec2.Update();
      }

    }

    //
    //**********************************************************************************************
    //

    private void FindFirstAndLastDay()
    {
      FirstDay = Convert.ToDateTime(MoistureContent[1, 0]);
      LastDay = Convert.ToDateTime(MoistureContent[MoistureContent.GetLength(0) - 1, 0]);
      FirstDayWithData = FirstDay;
      LastDayWithData = LastDay;
    }

    //
    //**********************************************************************************************
    //

    public void ShowMoistureContents(System.Windows.Forms.PictureBox aBox)
    { 
      String FileName;
      Double[] Theta;
      Int32 Rows = MoistureContent.GetLength(0);

      Int32 FirstRow = 0;
      for (Int32 TheRow = 1; TheRow < Rows; TheRow++)
      {
        DateTime MyDate = Convert.ToDateTime(MoistureContent[TheRow, 0]);
        if (MyDate >= FirstDay)
        {
          FirstRow = TheRow;
          break;
        }
      }

      Int32 LastRow = Rows;
      for (Int32 Row = Rows - 1; Row > 0; Row--)
      {
        DateTime MyDate = Convert.ToDateTime(MoistureContent[Row, 0]);
        if (MyDate <= LastDay)
        {
          LastRow = Row;
          break;
        }
      }

      Int32 ImageCounter = 0;
      brTimes.Minimum = FirstRow;
      brTimes.Maximum = LastRow;

      Int32 j = FirstRow - 1;
      while ((j < LastRow) & (Running))
      {
        CreatingPicture = true;
        j = j + 1;
        brTimes.Value = j;

        DateTime MyDate = Convert.ToDateTime(MoistureContent[j, 0]);
        if ((MyDate >= FirstDay) & (MyDate <= LastDay))
        {
          ImageCounter++;
          chrtPrec2.Header.Text = MoistureContent[j, 0];
          chrtPrec2.Series[2].Clear();
          chrtPrec2.Series[2].Add(MyDate.ToOADate(), 0.0, Color.Red);
          chrtPrec2.Series[2].Add(MyDate.ToOADate(), 1.0, Color.Red);

          Int32 NVirtual = 0;
          foreach (TPlotToShow MyPlotToShow in PlotToShow)
          {
            TPlot MyPlot = Plot[MyPlotToShow.PlotId];
            Theta = new Double[MyPlot.Node.Count];
            for (Int32 i = 0; i < MyPlot.Node.Count; i++)
            {
              if (MyPlot.Node[i].Virtual)
              {
                NVirtual++;
                Theta[i] = 0.0;
              }
              else
              {
                Theta[i] = Convert.ToDouble(MoistureContent[j, i + 1 - NVirtual + MyPlot.FirstNode]);
              }
            }
            MyPlot.ProcessTheta(Theta, brPoints, MoistureClass, DerivedClass, MyPlotToShow.ItemToVisualize);
          }

          CreateTotalBitmap(false);

          FileName = SaveGraph(OutputDir, ImageCounter);
          if (PPTRequired)
          {
            PPT.AddPictureToSlide(FileName);
          }
          aBox.Image = null;
          aBox.Image = TotalBitmap;
          aBox.Refresh();
        }
        CreatingPicture = false;
      }
    }

    //
    //**********************************************************************************************
    //

    public String SaveGraph(String aDir, Int32 aNumber)
    {
      Bitmap myBitmap = null;
      String File = "";
      try
      {
        if (aNumber == -100)
        {
          File = aDir + @"grid.png";
          myBitmap = new Bitmap(TotalBitmap);
        }
        else
        {
          if (aNumber == -10)
          {
            File = aDir + @"legendm.png";
            myBitmap = MyMoistureLegend.GetBitmap(true);
          }
          else
          {
            if (aNumber == -11)
            {
              File = aDir + @"legendd.png";
              myBitmap = MyDerivedLegend.GetBitmap(true);
            }
            else
            {
              String MyNumber = aNumber.ToString();
              while (MyNumber.Length < 4)
              {
                MyNumber = "0" + MyNumber;
              }
              File = aDir + @"plot" + MyNumber + @".png";
              myBitmap = new Bitmap(TotalBitmap);
            }
          }
        }
        myBitmap.Save(File, System.Drawing.Imaging.ImageFormat.Png);
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error writing file " + File + ": " + e.Message);
      }
       return File;
    }

  }
}
