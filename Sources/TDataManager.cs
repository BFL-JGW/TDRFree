using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace TDRFree
{
  class TDataManager
  {
    private object Missing = System.Reflection.Missing.Value;
    private Microsoft.Office.Interop.Excel.Application ExcelApp;
    private Workbook MyWorkBook;
    private Worksheet MyWorkSheet;
    public Boolean ExcelIsAvailable;

    public String InitialMoistureFile;
    public String InitialPrecFile;
    public String InitialIrrigFile;
    public String InitialOutputDir;
    public String InitialPPTFile;
    public Boolean InitialIrrigPresent;
    public Boolean InitialPPTRequired;
    
    //
    //**********************************************************************************************
    //
    // Class TDataManager
    //   Part of  : TDRFree
    //   Function : IO from/to ini-file and Excel files
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //
    
    public TDataManager()
    {
      ReadIniFile();
    }

    //
    //**********************************************************************************************
    //
 
    public void ReadExcelFile(String aFile)
    {
      StartExcel();
      if (ExcelIsAvailable)
      {
        OpenExcelFile(aFile);
      }
    }

    //
    //**********************************************************************************************
    //
    
    private void ReadIniFile()
    {
      TIniFile MyIni = new TIniFile(System.Windows.Forms.Application.ExecutablePath.ToLower().Replace(".exe", ".ini"));
      try
      {
        InitialMoistureFile = MyIni.IniReadValue("Excel", "Moisture");
        InitialPrecFile = MyIni.IniReadValue("Excel", "Precipitation");
        InitialIrrigFile = MyIni.IniReadValue("Excel", "Irrigation");

        InitialOutputDir = MyIni.IniReadValue("Output", "Dir");
        InitialIrrigPresent = MyIni.IniReadValue("Switch", "Irrigation").Trim().Equals("1");

        InitialPPTRequired = MyIni.IniReadValue("PowerPoint", "Required").Trim().Equals("1");
        InitialPPTFile = MyIni.IniReadValue("PowerPoint", "File");
      }
      catch (Exception e)
      {
        MessageBox.Show("Error in ini-file: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //
    
    public void SaveToIniFile(String aMoistureFile, String aPrecipitationFile, String aIrrigationFile, 
      String aOutputDir, Boolean aIrrigationSwitch, Boolean aPPTSwitch, String aPPTFile)
    {
      TIniFile MyIni = new TIniFile(System.Windows.Forms.Application.ExecutablePath.ToLower().Replace(".exe", ".ini"));
      try
      {
        MyIni.IniWriteValue("Excel", "Moisture", aMoistureFile);
        MyIni.IniWriteValue("Excel", "Precipitation", aPrecipitationFile);
        MyIni.IniWriteValue("Excel", "Irrigation", aIrrigationFile);

        MyIni.IniWriteValue("Output", "Dir", aOutputDir);
        String MySwitch = "0";
        if (aIrrigationSwitch)
        {
          MySwitch = "1";
        }
        MyIni.IniWriteValue("Switch", "Irrigation", MySwitch);

        MySwitch = "0";
        if (aPPTSwitch)
        {
          MySwitch = "1";
        }
        MyIni.IniWriteValue("PowerPoint", "Required", MySwitch);
        MyIni.IniWriteValue("PowerPoint", "File", aPPTFile);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error in ini-file: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //
    
    private void StartExcel()
    {
      try
      {
        ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        ExcelApp.DisplayAlerts = false;
        ExcelApp.Visible = false;
        ExcelIsAvailable = true;
      }
      catch
      {
        ExcelIsAvailable = false;
      }
    }

    //
    //**********************************************************************************************
    //
    
    private void OpenExcelFile(String aName)
    {
      MyWorkBook = ExcelApp.Workbooks.Open(aName, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing);
    }

    //
    //**********************************************************************************************
    //
    
    private Int32[,] ConvertToIntArray(System.Array values)
    {
      // create a new array
      Int32[,] theArray = new Int32[values.GetLength(0), values.GetLength(1)];
      for (int i = 1; i <= values.GetLength(0); i++)
      {
        for (int j = 1; j <= values.GetLength(1); j++)
        {
          if (values.GetValue(i, j) == null)
            theArray[i - 1, j - 1] = -1;
          else
            theArray[i - 1, j - 1] = Convert.ToInt32((string)values.GetValue(i, j).ToString());
        }
      }
      return theArray;
    }

    //
    //**********************************************************************************************
    //
 
    private String[,] ConvertToStringArray(System.Array values)
    {
      // create a new array
      String[,] theArray = new String[values.GetLength(0), values.GetLength(1)];
      for (int i = 1; i <= values.GetLength(0); i++)
      {
        for (int j = 1; j <= values.GetLength(1); j++)
        {
          if (values.GetValue(i, j) == null)
            theArray[i - 1, j - 1] = "0.0";
          else
            theArray[i - 1, j - 1] = values.GetValue(i, j).ToString();
        }
      }
      return theArray;
    }

    //
    //**********************************************************************************************
    //

    public void ReadContourSheet(List<TPoint> aTop, List<TPoint> aRight, List<TPoint> aBottom, List<TPoint> aLeft)
    {
      Range MyRange;
      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("PlotBoundaries");

      Boolean Reading = true;
      Int32 Row;
      String ColX;
      String ColY;
      Double X = 0.0;
      Double Y = 0.0;
      String CellContent;
      
      // top boundary
      aTop.Clear();
      Row = 3;
      ColX = "A";
      ColY = "B";
      while (Reading)
      {
        MyRange = MyWorkSheet.get_Range(ColX + Row.ToString(), ColX + Row.ToString());
        if (MyRange.Value2 == null)
        {
          CellContent = "";
        }
        else
        {
          CellContent = MyRange.Value2.ToString();
        }
        if (CellContent == "")
        {
          Reading = false;
        }
        else
        {
          X = Convert.ToDouble(CellContent);
        }

        if (Reading)
        {
          MyRange = MyWorkSheet.get_Range(ColY + Row.ToString(), ColY + Row.ToString());
          CellContent = MyRange.Value2.ToString();
          if (CellContent == "")
          {
            Reading = false;
          }
          else
          {
            Y = Convert.ToDouble(CellContent);
          }
        }
        if (Reading)
        {
          aTop.Add(new TPoint(X, Y));
          Row++;
        }
      }

      // right boundary
      aRight.Clear();
      Row = 3;
      ColX = "C";
      ColY = "D";
      Reading = true;
      while (Reading)
      {
        MyRange = MyWorkSheet.get_Range(ColX + Row.ToString(), ColX + Row.ToString());
        if (MyRange.Value2 == null)
        {
          CellContent = "";
        }
        else
        {
          CellContent = MyRange.Value2.ToString();
        }
        if (CellContent == "")
        {
          Reading = false;
        }
        else
        {
          X = Convert.ToDouble(CellContent);
        }

        if (Reading)
        {
          MyRange = MyWorkSheet.get_Range(ColY + Row.ToString(), ColY + Row.ToString());
          CellContent = MyRange.Value2.ToString();
          if (CellContent == "")
          {
            Reading = false;
          }
          else
          {
            Y = Convert.ToDouble(CellContent);
          }
        }
        if (Reading)
        {
          aRight.Add(new TPoint(X, Y));
          Row++;
        }
      }

      // bottom boundary
      aBottom.Clear();
      Row = 3;
      ColX = "E";
      ColY = "F";
      Reading = true;
      while (Reading)
      {
        MyRange = MyWorkSheet.get_Range(ColX + Row.ToString(), ColX + Row.ToString());
        if (MyRange.Value2 == null)
        {
          CellContent = "";
        }
        else
        {
          CellContent = MyRange.Value2.ToString();
        }
        if (CellContent == "")
        {
          Reading = false;
        }
        else
        {
          X = Convert.ToDouble(CellContent);
        }

        if (Reading)
        {
          MyRange = MyWorkSheet.get_Range(ColY + Row.ToString(), ColY + Row.ToString());
          CellContent = MyRange.Value2.ToString();
          if (CellContent == "")
          {
            Reading = false;
          }
          else
          {
            Y = Convert.ToDouble(CellContent);
          }
        }
        if (Reading)
        {
          aBottom.Add(new TPoint(X, Y));
          Row++;
        }
      }

      // left boundary
      aLeft.Clear();
      Row = 3;
      ColX = "G";
      ColY = "H";
      Reading = true;
      while (Reading)
      {
        MyRange = MyWorkSheet.get_Range(ColX + Row.ToString(), ColX + Row.ToString());
        if (MyRange.Value2 == null)
        {
          CellContent = "";
        }
        else
        {
          CellContent = MyRange.Value2.ToString();
        }
        if (CellContent == "")
        {
          Reading = false;
        }
        else
        {
          X = Convert.ToDouble(CellContent);
        }

        if (Reading)
        {
          MyRange = MyWorkSheet.get_Range(ColY + Row.ToString(), ColY + Row.ToString());
          CellContent = MyRange.Value2.ToString();
          if (CellContent == "")
          {
            Reading = false;
          }
          else
          {
            Y = Convert.ToDouble(CellContent);
          }
        }
        if (Reading)
        {
          aLeft.Add(new TPoint(X, Y));
          Row++;
        }
      }

    }

    //
    //**********************************************************************************************
    //

    public void ReadMoistureClasses(List<TMoistureClass> aMoistureList, List<TDerivedClass> aDerivedList)
    {
      Double LowLimit;
      Double HighLimit;
      Int32 R;
      Int32 G;
      Int32 B;
      String ItemName;

      try
      {
        TMoistureClass MyClass;
        aMoistureList.Clear();
        Range MyRange;
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Colors");

        Boolean Reading = true;
        Int32 Row = 3;
        while (Reading)
        {
          MyRange = (Range)MyWorkSheet.Cells[Row, 1];
          if (MyRange.Value2 == null)
          {
            Reading = false;
          }
          else
          {
            LowLimit = Convert.ToDouble(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 2];
            HighLimit = Convert.ToDouble(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 3];
            R = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 4];
            G = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 5];
            B = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 6];
            ItemName = Convert.ToString(MyRange.Value2);

            MyClass = new TMoistureClass(LowLimit, HighLimit, R, G, B, ItemName);
            aMoistureList.Add(MyClass);

            Row++;
          }
        }

        TDerivedClass MyClassD;
        aDerivedList.Clear();

        Reading = true;
        Row = 3;
        while (Reading)
        {
          MyRange = (Range)MyWorkSheet.Cells[Row, 8];
          if (MyRange.Value2 == null)
          {
            Reading = false;
          }
          else
          {
            LowLimit = Convert.ToDouble(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 9];
            HighLimit = Convert.ToDouble(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 10];
            R = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 11];
            G = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 12];
            B = Convert.ToInt32(MyRange.Value2);
            MyRange = (Range)MyWorkSheet.Cells[Row, 13];
            ItemName = Convert.ToString(MyRange.Value2);

            MyClassD = new TDerivedClass(LowLimit, HighLimit, R, G, B, ItemName);
            aDerivedList.Add(MyClassD);

            Row++;
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading colors: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public void ReadDerivativeTables(List<TPlot> aPlot)
    {
      try
      {
        Range MyRange;
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Derive");

        for (Int32 i = 0; i < aPlot.Count; i++)
        {
          aPlot[i].ValuesForDerivation.Clear();
          Int32 Row = 2;
          Int32 Offset = 12 * i;

          Int32 PosOfValue = 1;
          // values
          while (PosOfValue < 11)
          {
            PosOfValue = PosOfValue + 2;
            MyRange = (Range)MyWorkSheet.Cells[Row, PosOfValue + Offset];
            if (MyRange.Value2 == null)
            {
              PosOfValue = 99;
            }
            else
            {
              aPlot[i].ValuesForDerivation.Add(Convert.ToDouble(MyRange.Value2));
            }
          }

          aPlot[i].DerivationLimits.Clear();
          Row = 3;
          Boolean Reading = (aPlot[i].ValuesForDerivation.Count > 0);
          while (Reading)
          {
            Row = Row + 1;
            PosOfValue = 1;
            MyRange = (Range)MyWorkSheet.Cells[Row, PosOfValue + Offset];
            if (MyRange.Value2 == null)
            {
              Reading = false;
            }
            else
            {
              TDerivationLimits MyLimits = new TDerivationLimits();
              MyLimits.z = Convert.ToDouble(MyRange.Value2);

              PosOfValue = 2;
              for (Int32 j = 0; j <= aPlot[i].ValuesForDerivation.Count - 2; j++)
              {
                PosOfValue = PosOfValue + 2;
                MyRange = (Range)MyWorkSheet.Cells[Row, PosOfValue + Offset];
                if (MyRange.Value2 == null)
                {
                  MessageBox.Show("Check limit value in cell[" + Row.ToString() + "," + (PosOfValue + Offset).ToString() + "]");
                }
                else
                {
                  MyLimits.Percentage.Add(Convert.ToDouble(MyRange.Value2));
                }
              }
              aPlot[i].DerivationLimits.Add(MyLimits);
            }
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error readeing derivative colors: " + e.Message);
      }
    }


    //
    //**********************************************************************************************
    //

    public void ReadNodes(List<TNode> aList, Int32 aPlot)
    {
      try
      {
        aList.Clear();
        Range MyRange;
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Nodes");

        Int32 Offset = aPlot * 5;
        Boolean Reading = true;
        Int32 Row;
        Int32 Id = 0;
        Double X = 0.0;
        Double Y = 0.0;
        Boolean Virtual = false;

        Row = 3;
        while (Reading)
        {
          MyRange = (Range)MyWorkSheet.Cells[Row, Offset + 1];
          if (MyRange.Value2 == null)
          {
            Reading = false;
          }
          else
          {
            Id = Convert.ToInt32(MyRange.Value2);
          }

          if (Reading)
          {
            MyRange = (Range)MyWorkSheet.Cells[Row, Offset + 2];
            if (MyRange.Value2 == null)
            {
              Reading = false;
            }
            else
            {
              X = Convert.ToDouble(MyRange.Value2);
            }
          }

          if (Reading)
          {
            MyRange = (Range)MyWorkSheet.Cells[Row, Offset + 3];
            if (MyRange.Value2 == null)
            {
              Reading = false;
            }
            else
            {
              Y = Convert.ToDouble(MyRange.Value2);
            }
          }

          if (Reading)
          {
            MyRange = (Range)MyWorkSheet.Cells[Row, Offset + 4];
            if (MyRange.Value2 == null)
            {
              Reading = false;
            }
            else
            {
              Virtual = (Convert.ToInt32(MyRange.Value2) == 1);
            }
          }

          if (Reading)
          {
            aList.Add(new TNode(Id, X, Y, Virtual));
            Row++;
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading nodes: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public String[,] ReadMoistureContents()
    {
      String[,] MoistureContents = new String[1,1];
      try
      {
        try
        {
          MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Moisture");
          Range MyRange = MyWorkSheet.UsedRange;
          System.Array MyValues = (System.Array)MyRange.Cells.get_Value(XlRangeValueDataType.xlRangeValueDefault);
          String[,] ReadMoistureContents = ConvertToStringArray(MyValues);
          Int32 LastRow = ReadMoistureContents.GetLength(0) - 1;
          while ((ReadMoistureContents[LastRow, 0].Trim() == "") || (ReadMoistureContents[LastRow, 0].Trim() == "0.0"))
          {
            LastRow = LastRow - 1;
          }
          MoistureContents = new String[LastRow + 1, ReadMoistureContents.GetLength(1)];
          for (Int32 i = 0; i <= LastRow; i++)
          {
            for (Int32 j = 0; j < ReadMoistureContents.GetLength(1); j++)
            {
              MoistureContents[i, j] = ReadMoistureContents[i, j];
            }
          }
        }
        catch (Exception e)
        {
          MessageBox.Show("???Error reading moisture contents: " + e.Message);
        }
      }
      finally
      {
      }
      return MoistureContents;
    }
 


    //
    //**********************************************************************************************
    //

    public void ReadVirtualNodes(List<TVirtualNode> aNode, Int32 aPlot)
    {
      try
      {
        aNode.Clear();
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Virtual");
        Int32 Base = 5 * aPlot;
        Int32 Row = 2;
        Boolean Reading = true;
        while (Reading)
        {
          Row = Row + 1;
          Range MyRange = (Range)MyWorkSheet.Cells[Row, Base + 1];
          if (MyRange.Value2 == null)
          {
            Reading = false;
          }
          else
          {
            TVirtualNode MyNode = new TVirtualNode();
            MyNode.Id = Convert.ToInt32(MyRange.Value2.ToString());
            for (Int32 i = 0; i < 3; i++)
            {
              MyRange = (Range)MyWorkSheet.Cells[Row, Base + 2 + i];
              MyNode.Neighbour[i] = Convert.ToInt32(MyRange.Value2.ToString());
            }
            aNode.Add(MyNode);
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading virtual nodes: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public Int32 ReadNumberOfPlots()
    {
      Int32 N = 0;
      try
      {
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
        Range MyRange = MyWorkSheet.get_Range("$C$2:$C$2", Type.Missing);
        N = Convert.ToInt32(MyRange.get_Value(XlRangeValueDataType.xlRangeValueDefault));
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading number of plots: " + e.Message);
      }
      return N;
    }

    //
    //**********************************************************************************************
    //

    public String ReadDateFormat()
    {
      String DateFormat = "dd/MM/yyyy HH:mm";
      try
      {
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
        Range MyRange = MyWorkSheet.get_Range("$C$18:$C$18", Type.Missing);
        DateFormat = Convert.ToString(MyRange.get_Value(XlRangeValueDataType.xlRangeValueDefault));
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading date format: " + e.Message);
      }
      return DateFormat;
    }

    //
    //**********************************************************************************************
    //

    public Int32 ReadPInterval()
    {
      Int32 N = 24;
      try
      {
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
        Range MyRange = MyWorkSheet.get_Range("$G$4:$G$4", Type.Missing);
        N = Convert.ToInt32(MyRange.get_Value(XlRangeValueDataType.xlRangeValueDefault));
      }
      catch (Exception e)
      {
        MessageBox.Show("???Error reading P interval: " + e.Message);
      }
      return N;
    }

    //
    //**********************************************************************************************
    //

    public void ReadPlotDescription(List<TPlot> aPlot)
    {
      try
      {
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
        Range MyRange = MyWorkSheet.get_Range("$C$5:$C$8", Type.Missing);
        System.Array MyValues = (System.Array)MyRange.Cells.get_Value(XlRangeValueDataType.xlRangeValueDefault);
        for (Int32 i = 1; i <= aPlot.Count; i++)
        {
          TPlot MyPlot = aPlot[i - 1];
          MyPlot.Description = MyValues.GetValue(i, 1).ToString();
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading plot description: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public void ReadVisualization(List<TPlotToShow> aPlotToShow)
    {
      try
      {
        aPlotToShow.Clear();
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
        Range MyRange;
        for (Int32 i = 12; i <= 15; i++)
        {
          MyRange = (Range)MyWorkSheet.Cells[i, 3];

          if (MyRange.Value2 != null)
          {
            if (MyRange.Value2.ToString().Trim() != "")
            {
              TPlotToShow MyPlot = new TPlotToShow();
              MyPlot.PlotId = Convert.ToInt32(MyRange.Value2) - 1;
              MyRange = (Range)MyWorkSheet.Cells[i, 4];
              if (MyRange.Value2 != null)
              {
                if (MyRange.Value2.ToString().ToUpper() == "M")
                {
                  MyPlot.ItemToVisualize = TItemToVisualize.MoistureContent;
                }
                else
                {
                  MyPlot.ItemToVisualize = TItemToVisualize.Derived;
                }
              }
              else
              {
                MessageBox.Show("You should specify what to show for plot " + i.ToString());
              }
              aPlotToShow.Add(MyPlot);
            }
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading visualization: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public void ReadElements(List<TNode> aNode, List<TElement> aElement, Int32 aPlot)
    {
      try
      {
        TElement MyElement;
        aElement.Clear();
        Int32 Base = 7 * aPlot;
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Elements");
        Range MyRange;
        Boolean Reading = true;
        Int32 Row = 2;
        while (Reading)
        {
          Row = Row + 1;
          MyRange = (Range)MyWorkSheet.Cells[Row, Base + 1];
          if (MyRange.Value2 == null)
          {
            Reading = false;
          }
          else
          {
            MyElement = new TElement();
            MyElement.Id = Convert.ToInt32(MyRange.Value2.ToString());
            for (Int32 i = 0; i < 4; i++)
            {
              MyRange = (Range)MyWorkSheet.Cells[Row, Base + i + 2];
              Int32 Node = Convert.ToInt32(MyRange.Value2.ToString());
              foreach (TNode MyNode in aNode)
              {
                if (MyNode.Id == Node)
                {
                  MyElement.Node[i] = MyNode;
                  break;
                }
              }
            }
            MyRange = (Range)MyWorkSheet.Cells[Row, Base + 6];
            if (Convert.ToInt32(MyRange.Value2.ToString()) == 1)
            {
              MyElement.Virtual = true;
            }
            else
            {
              MyElement.Virtual = false;
            }
            MyElement.Prepare();
            aElement.Add(MyElement);
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("??? Error reading elements: " + e.Message);
      }
    }

    //
    //**********************************************************************************************
    //

    public TAssignmentMethod ReadAssignmentMethod()
    {
      TAssignmentMethod MyMethod = TAssignmentMethod.None;
      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
      Range MyRange;

      try
      {
        MyRange = (Range)MyWorkSheet.Cells[19, 3];
        Int32 M = Convert.ToInt32(MyRange.Value2);

        switch (M)
        {
          case 0: MyMethod = TAssignmentMethod.Interpolate;
            break;
          case 1: MyMethod = TAssignmentMethod.NearestNeighbour;
            break;
          default: MyMethod = TAssignmentMethod.None;
            break;
        }
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading method: " + e.Message);
      }
      return MyMethod;
    }

    //
    //**********************************************************************************************
    //

    public Color ReadBackgroundColor()
    {
      Color MyColor = new Color();
      MyColor = Color.Black;

      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
      Range MyRange;

      try
      {
        MyRange = (Range)MyWorkSheet.Cells[12, 7];
        Int32 R = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[12, 8];
        Int32 G = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[12, 9];
        Int32 B = Convert.ToInt32(MyRange.Value2);
        MyColor = Color.FromArgb(R, G, B);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading background color: " + e.Message);
      }

      return MyColor;
    }

    //
    //**********************************************************************************************
    //
 
    public Color ReadTextColor()
    {
      Color MyColor = new Color();
      MyColor = Color.Black;

      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
      Range MyRange;

      try
      {
        MyRange = (Range)MyWorkSheet.Cells[13, 7];
        Int32 R = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[13, 8];
        Int32 G = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[13, 9];
        Int32 B = Convert.ToInt32(MyRange.Value2);
        MyColor = Color.FromArgb(R, G, B);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading text color: " + e.Message);
      }

      return MyColor;
    }

    //
    //**********************************************************************************************
    //

    public Color ReadPrecipitationColor()
    {
      Color MyColor = new Color();
      MyColor = Color.White;

      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
      Range MyRange;

      try
      {
        MyRange = (Range)MyWorkSheet.Cells[14, 7];
        Int32 R = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[14, 8];
        Int32 G = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[14, 9];
        Int32 B = Convert.ToInt32(MyRange.Value2);
        MyColor = Color.FromArgb(R, G, B);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading precipitation color: " + e.Message);
      }

      return MyColor;
    }

    //
    //**********************************************************************************************
    //

    public Color ReadIrrigationColor()
    {
      Color MyColor = new Color();
      MyColor = Color.Yellow;

      MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item("Control");
      Range MyRange;

      try
      {
        MyRange = (Range)MyWorkSheet.Cells[15, 7];
        Int32 R = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[15, 8];
        Int32 G = Convert.ToInt32(MyRange.Value2);
        MyRange = (Range)MyWorkSheet.Cells[15, 9];
        Int32 B = Convert.ToInt32(MyRange.Value2);
        MyColor = Color.FromArgb(R, G, B);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error reading irrigation color: " + e.Message);
      }

      return MyColor;
    }

    //
    //**********************************************************************************************
    //

    public void CloseExcelFile()
    {
      MyWorkBook.Close(false, "", null);
    }

    //
    //**********************************************************************************************
    //

    public void QuitExcel()
    {
      ExcelApp.Quit();
      ExcelApp = null;
    }

    //
    //**********************************************************************************************
    //

    private String GetNameOfMonth(Int32 aMonth)
    {
      String TheName;

      switch (aMonth)
      {
        case 1:
          TheName = "January";
          break;
        case 2:
          TheName = "February";
          break;
        case 3:
          TheName = "March";
          break;
        case 4:
          TheName = "April";
          break;
        case 5:
          TheName = "May";
          break;
        case 6:
          TheName = "June";
          break;
        case 7:
          TheName = "July";
          break;
        case 8:
          TheName = "August";
          break;
        case 9:
          TheName = "September";
          break;
        case 10:
          TheName = "October";
          break;
        case 11:
          TheName = "November";
          break;
        case 12:
          TheName = "December";
          break;
        default:
          TheName = "Unknown";
          break;
      }
      return TheName;
    }

    //
    //**********************************************************************************************
    //

    public List<TMeteo> ReadPrecipitation(String aFile, DateTime aFirst, DateTime aLast)
    {
      Double OldValue = 0.0;
      Double NewValue = 0.0;
      Int32 FirstMonth = aFirst.Month;
      Int32 LastMonth = aLast.Month;
      String SheetName;
      List<TMeteo> Prec = new List<TMeteo> ();
      Prec.Clear();
      MyWorkBook = ExcelApp.Workbooks.Open(aFile, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing);

      for (Int32 Month = FirstMonth; Month <= LastMonth; Month++)
      {
        OldValue = 0.0;
        SheetName = GetNameOfMonth(Month);
        MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item(SheetName);
        Range MyRange = MyWorkSheet.UsedRange;
        System.Array MyValues = (System.Array)MyRange.Cells.get_Value(XlRangeValueDataType.xlRangeValueDefault);
        String[,] MyData = ConvertToStringArray(MyValues);
        for (Int32 i = 0; i < MyData.GetLength(0); i++)
        {
          TMeteo MyMeteo = new TMeteo();
          if ((MyData[i, 0].IndexOf("/") >= 0) || (MyData[i,0].IndexOf("-") >= 0))
          {
            MyMeteo.Date = Convert.ToDateTime(MyData[i, 0]);
            NewValue = Convert.ToDouble(MyData[i, 1]);
            MyMeteo.Value = NewValue - OldValue;
            OldValue = NewValue;
            Prec.Add(MyMeteo);
          }
        }
      }
      MyWorkBook.Close(false, "", null);
      return Prec;
    }

    //
    //**********************************************************************************************
    //

    public List<TMeteo> ReadIrrigation(String aFile)
    {
      Double NewValue = 0.0;
      String SheetName = @"Irrigation";
      List<TMeteo> Irrig = new List<TMeteo>();
      Irrig.Clear();
      MyWorkBook = ExcelApp.Workbooks.Open(aFile, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing, Missing, Missing, Missing,
          Missing, Missing, Missing, Missing);

      try
      {
        try
        {
          MyWorkSheet = (Worksheet)MyWorkBook.Worksheets.get_Item(SheetName);
          Range MyRange = MyWorkSheet.UsedRange;
          System.Array MyValues = (System.Array)MyRange.Cells.get_Value(XlRangeValueDataType.xlRangeValueDefault);
          String[,] MyData = ConvertToStringArray(MyValues);
          for (Int32 i = 1; i < MyData.GetLength(0); i++)
          {
            TMeteo MyMeteo = new TMeteo();
            if ((MyData[i, 0].IndexOf("-") >= 0) || (MyData[i, 0].IndexOf("/") >= 0))
            {
              MyMeteo.Date = Convert.ToDateTime(MyData[i, 0]);
              NewValue = Convert.ToDouble(MyData[i, 1]);
              MyMeteo.Value = NewValue;
              Irrig.Add(MyMeteo);
            }
          }
        }
        catch (Exception e)
        {
          MessageBox.Show("??? Error opening sheet Irrigation in file " + aFile + ": " + e.Message);
        }
      }
      finally
      {
        MyWorkBook.Close(false, "", null);
      }
      return Irrig;
    }


  }
}
