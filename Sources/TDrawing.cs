using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using Steema.TeeChart;

namespace TDRFree
{
  class TDrawing
  {
    private TChart MyChart;
    private Bitmap MyBitmap;
    private Graphics MyGraph;
    public Int32 HorSizeChart;
    public Int32 VertSizeChart;
    private Int32 HorOffset;
    private Int32 VertOffset;
    private Int32 HorSize;
    private Int32 VertSize;
    public Color BackgroundColor;
    public Color ForegroundColor;
    private List<TPoint> TopBoundary;
    private List<TPoint> RightBoundary;
    private List<TPoint> BottomBoundary;
    private List<TPoint> LeftBoundary;
    private Double XMin;
    private Double XMax;
    private Double YMin;
    private Double YMax;
    private Double dX;
    private Double dY;

    //
    //**********************************************************************************************
    //
    // Class TDrawing
    //   Part of  : TDRFree
    //   Function : Draw the charts
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TDrawing(Color aBackColor, Color aForeColor)
    {
      BackgroundColor = aBackColor;
      ForegroundColor = aForeColor;
      TopBoundary = new List<TPoint>();
      RightBoundary = new List<TPoint>();
      BottomBoundary = new List<TPoint>();
      LeftBoundary = new List<TPoint>();
    }

    //
    //**********************************************************************************************
    //

    public void Scale(List<TPoint> aTop, List<TPoint> aRight, List<TPoint> aBottom, List<TPoint> aLeft)
    {
      TopBoundary = aTop;
      RightBoundary = aRight;
      BottomBoundary = aBottom;
      LeftBoundary = aLeft;

      XMax = -1.0e99;
      XMin = 1.0e99;
      YMax = -1.0e99;
      YMin = 1.0e99;

      foreach (TPoint MyPoint in TopBoundary)
      {
        if (MyPoint.X < XMin)
        {
          XMin = MyPoint.X;
        }
        if (MyPoint.X > XMax)
        {
          XMax = MyPoint.X;
        }
        if (MyPoint.Y < YMin)
        {
          YMin = MyPoint.Y;
        }
        if (MyPoint.Y > YMax)
        {
          YMax = MyPoint.Y;
        }
      }

      foreach (TPoint MyPoint in RightBoundary)
      {
        if (MyPoint.X < XMin)
        {
          XMin = MyPoint.X;
        }
        if (MyPoint.X > XMax)
        {
          XMax = MyPoint.X;
        }
        if (MyPoint.Y < YMin)
        {
          YMin = MyPoint.Y;
        }
        if (MyPoint.Y > YMax)
        {
          YMax = MyPoint.Y;
        }
      }

      foreach (TPoint MyPoint in BottomBoundary)
      {
        if (MyPoint.X < XMin)
        {
          XMin = MyPoint.X;
        }
        if (MyPoint.X > XMax)
        {
          XMax = MyPoint.X;
        }
        if (MyPoint.Y < YMin)
        {
          YMin = MyPoint.Y;
        }
        if (MyPoint.Y > YMax)
        {
          YMax = MyPoint.Y;
        }
      }

      foreach (TPoint MyPoint in LeftBoundary)
      {
        if (MyPoint.X < XMin)
        {
          XMin = MyPoint.X;
        }
        if (MyPoint.X > XMax)
        {
          XMax = MyPoint.X;
        }
        if (MyPoint.Y < YMin)
        {
          YMin = MyPoint.Y;
        }
        if (MyPoint.Y > YMax)
        {
          YMax = MyPoint.Y;
        }
      }
      MyChart.Panel.Color = BackgroundColor;
      MyChart.Panel.Brush.Color = BackgroundColor;
      MyChart.Panel.Gradient.Visible = false;
      MyChart.Panel.Shadow.Visible = false;
      MyChart.Panel.Transparent = false;
      MyChart.BackColor = BackgroundColor;
      MyChart.Legend.Visible = false;
      MyChart.Footer.Visible = false;
      MyChart.Chart.Aspect.View3D = false;
      MyChart.Panel.Pen.Color = ForegroundColor;
      MyChart.Header.Font.Color = ForegroundColor;
      MyChart.Walls.Right.Color = BackgroundColor;
      MyChart.Walls.Back.Color = BackgroundColor;
      MyChart.Walls.Visible = false;

      MyChart.Axes.Bottom.AxisPen.Color = ForegroundColor;
      MyChart.Axes.Bottom.Title.Color = ForegroundColor;
      MyChart.Axes.Bottom.Ticks.Color = ForegroundColor;
      MyChart.Axes.Bottom.Labels.Color = ForegroundColor;
      MyChart.Axes.Bottom.Grid.Color = ForegroundColor;
      MyChart.Axes.Bottom.MinorTicks.Color = ForegroundColor;
      MyChart.Axes.Bottom.Labels.Font.Color = ForegroundColor;

      MyChart.Axes.Left.AxisPen.Color = ForegroundColor;
      MyChart.Axes.Left.Title.Color = ForegroundColor;
      MyChart.Axes.Left.Ticks.Color = ForegroundColor;
      MyChart.Axes.Left.Labels.Color = ForegroundColor;
      MyChart.Axes.Left.Grid.Color = ForegroundColor;
      MyChart.Axes.Left.MinorTicks.Color = ForegroundColor;
      MyChart.Axes.Left.Labels.Font.Color = ForegroundColor;
      MyChart.Panel.Bevel.ColorOne = BackgroundColor;
      MyChart.Panel.Bevel.ColorTwo = BackgroundColor;
 
      MyChart.Axes.Left.Automatic = false;
      MyChart.Axes.Left.Maximum = YMax;
      MyChart.Axes.Left.Minimum = YMin;

      MyChart.Axes.Bottom.Automatic = false;
      MyChart.Axes.Bottom.Minimum = XMin;
      MyChart.Axes.Bottom.Maximum = XMax;

      MyChart.Legend.Visible = false;
      MyChart.Header.Visible = false;
      MyChart.Axes.Bottom.Title.Visible = false;
      MyChart.Axes.Left.Title.Visible = false;

      Steema.TeeChart.Styles.Line MyLine = new Steema.TeeChart.Styles.Line();
      MyLine.Add(XMin, YMin);
      MyLine.Add(XMax, YMax);
      MyChart.Series.Add(MyLine);

      MyChart.Draw();
      MyChart.Update();
      MyChart.Refresh();
      Application.DoEvents();

      HorOffset = MyChart.Axes.Bottom.IStartPos;
      HorSize = MyChart.Axes.Bottom.IEndPos - HorOffset + 2;
      VertOffset = MyChart.Axes.Left.IStartPos;
      VertSize = MyChart.Axes.Left.IEndPos - VertOffset + 2;
      MyBitmap = new Bitmap(HorSize, VertSize);

      MyGraph = Graphics.FromImage(MyBitmap);
      MyGraph.Clear(BackgroundColor);

      dX = HorSize / (XMax - XMin);
      dY = VertSize / (YMax - YMin);
    }


    //
    //**********************************************************************************************
    //

    public void DrawContours()
    {
      Pen MyPen = new Pen(Color.Black, 2);
      Int32 XPos = 0;
      Int32 YPos = 0;
      Int32 XOld = 0;
      Int32 YOld = 0;
      Boolean First = true;
      foreach (TPoint MyPoint in TopBoundary)
      {
        XOld = XPos;
        YOld = YPos;
        XPos = Convert.ToInt32(Math.Round(dX * (MyPoint.X - XMin)));
        YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyPoint.Y - YMin)));
        if (First)
        {
          First = false;
        }
        else
        {
          MyGraph.DrawLine(MyPen, XOld, YOld, XPos, YPos);
        }
      }

      First = true;
      foreach (TPoint MyPoint in RightBoundary)
      {
        XOld = XPos;
        YOld = YPos;
        XPos = Convert.ToInt32(Math.Round(dX * (MyPoint.X - XMin)));
        YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyPoint.Y - YMin)));
        if (First)
        {
          First = false;
        }
        else
        {
          MyGraph.DrawLine(MyPen, XOld, YOld, XPos, YPos);
        }
      }

      First = true;
      foreach (TPoint MyPoint in BottomBoundary)
      {
        XOld = XPos;
        YOld = YPos;
        XPos = Convert.ToInt32(Math.Round(dX * (MyPoint.X - XMin)));
        YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyPoint.Y - YMin)));
        if (First)
        {
          First = false;
        }
        else
        {
          MyGraph.DrawLine(MyPen, XOld, YOld, XPos, YPos);
        }
      }

      First = true;
      foreach (TPoint MyPoint in LeftBoundary)
      {
        XOld = XPos;
        YOld = YPos;
        XPos = Convert.ToInt32(Math.Round(dX * (MyPoint.X - XMin)));
        YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyPoint.Y - YMin)));
        if (First)
        {
          First = false;
        }
        else
        {
          MyGraph.DrawLine(MyPen, XOld, YOld, XPos, YPos);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawNodes(List<TNode> aNode)
    {
      Int32 XPos;
      Int32 YPos;
      Int32 TextHeight;
      Int32 TextWidth;
      Int32 Top;
      Int32 Left;
      Rectangle MyRect;
      String Number;

      SizeF TextSize = new SizeF();
      Font MyFont = new Font("Arial", 6);
      Brush MyBrush1 = new SolidBrush(Color.White);
      Brush MyBrush2 = new SolidBrush(Color.Aqua);
      Pen MyPen = new Pen(Color.White, 2);
      foreach (TNode MyNode in aNode)
      {
        XPos = Convert.ToInt32(Math.Round(dX * (MyNode.X - XMin)));
        YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyNode.Y - YMin)));
        MyGraph.DrawLine(MyPen, XPos, YPos, XPos+5, YPos+5);
        Number = MyNode.Id.ToString();
        TextSize = MyGraph.MeasureString(Number, MyFont);
        TextHeight = Convert.ToInt32(Math.Truncate(TextSize.Height + 1.0));
        TextWidth = Convert.ToInt32(Math.Truncate(TextSize.Width + 1.0));
        Top = YPos - (TextHeight / 2);
        if (Top < 0)
        {
          Top = 0;
        }
        if (Top + TextHeight > VertSize)
        {
          Top = VertSize - TextHeight;
        }
        Left = XPos - (TextWidth / 2);
        if (Left < 0)
        {
          Left = 0;
        }
        if (Left + TextWidth > HorSize)
        {
          Left = HorSize - TextWidth;
        }
        MyRect = new Rectangle(Left, Top, TextWidth, TextHeight);
        if (MyNode.Virtual)
        {
          MyGraph.DrawString(Number, MyFont, MyBrush2, MyRect);
        }
        else
        {
          MyGraph.DrawString(Number, MyFont, MyBrush1, MyRect);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawElements(List<TElement> aElement)
    {
      Int32 X;
      Int32 Y;
      Int32 TextHeight;
      Int32 TextWidth;
      Int32 Top;
      Int32 Left;
      Rectangle MyRect;
      String Number;
      Int32 XPos;
      Int32 YPos;
      Int32 XOld;
      Int32 YOld;
      SizeF TextSize = new SizeF();
      Font MyFont = new Font("Arial", 6);
      Brush MyBrush1 = new SolidBrush(Color.Red);
      Brush MyBrush2 = new SolidBrush(Color.Green);
      Pen MyPen1 = new Pen(Color.Red, 3);
      Pen MyPen2 = new Pen(Color.Green, 3);

      for (Int32 j = 0; j <= 1; j++)
      {
        foreach (TElement MyElement in aElement)
        {
          X = 0;
          Y = 0;
          XPos = Convert.ToInt32(Math.Round(dX * (MyElement.Node[MyElement.Node.GetLength(0) - 1].X - XMin)));
          YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyElement.Node[MyElement.Node.GetLength(0) - 1].Y - YMin)));
          for (Int32 i = 0; i < MyElement.Node.GetLength(0); i++)
          {
            XOld = XPos;
            YOld = YPos;
            XPos = Convert.ToInt32(Math.Round(dX * (MyElement.Node[i].X - XMin)));
            YPos = Convert.ToInt32(Math.Round(VertSize - dY * (MyElement.Node[i].Y - YMin)));
            if ((j == 0) & (MyElement.Virtual))
            {
              MyGraph.DrawLine(MyPen2, XOld, YOld, XPos, YPos);
            }
            else
            {
              if ((j == 1) & (!MyElement.Virtual))
              {
                MyGraph.DrawLine(MyPen1, XOld, YOld, XPos, YPos);
              }
            }
            X = X + XPos;
            Y = Y + YPos;
          }
          X = X / MyElement.Node.GetLength(0);
          Y = Y / MyElement.Node.GetLength(0);
          Number = MyElement.Id.ToString();
          TextSize = MyGraph.MeasureString(Number, MyFont);
          TextHeight = Convert.ToInt32(Math.Truncate(TextSize.Height + 1.0));
          TextWidth = Convert.ToInt32(Math.Truncate(TextSize.Width + 1.0));
          Top = Y - (TextHeight / 2);
          if (Top < 0)
          {
            Top = 0;
          }
          if (Top + TextHeight > VertSize)
          {
            Top = VertSize - TextHeight;
          }
          Left = X - (TextWidth / 2);
          if (Left < 0)
          {
            Left = 0;
          }
          if (Left + TextWidth > HorSize)
          {
            Left = HorSize - TextWidth;
          }
          MyRect = new Rectangle(Left, Top, TextWidth, TextHeight);
          if ((j ==0) & (MyElement.Virtual))
          {
            MyGraph.DrawString(Number, MyFont, MyBrush2, MyRect);
          }
          else
          {
            if ((j == 1) & (!MyElement.Virtual))
            {
              MyGraph.DrawString(Number, MyFont, MyBrush1, MyRect);
            }
          }
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawLegend(List<TMoistureClass> aClass)
    {
      Brush MyBrush = new SolidBrush(Color.Black);
      MyGraph.FillRectangle(MyBrush, 0, 0, HorSize, VertSize);
      SizeF TextSize = new SizeF();
      Font MyFont = new Font("Arial", 14);
      Pen MyPen = new Pen(Color.White, 2);

      Int32 LeftText = (HorSize / 2) + 5;
      Int32 HeightPerClass = VertSize / Math.Min(20, aClass.Count);
      Int32 HeightOfItem = 3 * HeightPerClass / 4;
      Int32 Top = (VertSize / 2) - (HeightPerClass * aClass.Count / 2) + (HeightPerClass / 8) - HeightPerClass;
      Int32 Left = 4 * HorSize / 10;
      Int32 Width = HorSize / 10;

      foreach (TMoistureClass MyClass in aClass)
      {
        Top = Top + HeightPerClass;
        MyBrush = new SolidBrush(MyClass.TheColor);
        MyGraph.FillRectangle(MyBrush, Left, Top, Width, HeightOfItem);

        String Text = MyClass.TheName;
        TextSize = MyGraph.MeasureString(Text, MyFont);
        Int32 TextHeight = Convert.ToInt32(Math.Truncate(TextSize.Height + 1.0));
        Int32 TextWidth = Convert.ToInt32(Math.Truncate(TextSize.Width + 1.0));
        Int32 TopText = Top + (HeightOfItem / 2) - (TextHeight / 2);
        MyGraph.DrawString(Text, MyFont, MyBrush, LeftText, TopText);

      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawDerivedLegend(List<TDerivedClass> aClass)
    {
      Brush MyBrush = new SolidBrush(Color.Black);
      MyGraph.FillRectangle(MyBrush, 0, 0, HorSize, VertSize);
      SizeF TextSize = new SizeF();
      Font MyFont = new Font("Arial", 14);
      Pen MyPen = new Pen(Color.White, 2);

      Int32 LeftText = (HorSize / 2) + 5;
      Int32 HeightPerClass = VertSize / Math.Min(20, aClass.Count);
      Int32 HeightOfItem = 3 * HeightPerClass / 4;
      Int32 Top = (VertSize / 2) - (HeightPerClass * aClass.Count / 2) + (HeightPerClass / 8) - HeightPerClass;
      Int32 Left = 4 * HorSize / 10;
      Int32 Width = HorSize / 10;

      foreach (TDerivedClass MyClass in aClass)
      {
        Top = Top + HeightPerClass;
        MyBrush = new SolidBrush(MyClass.TheColor);
        MyGraph.FillRectangle(MyBrush, Left, Top, Width, HeightOfItem);

        String Text = MyClass.TheName;
        TextSize = MyGraph.MeasureString(Text, MyFont);
        Int32 TextHeight = Convert.ToInt32(Math.Truncate(TextSize.Height + 1.0));
        Int32 TextWidth = Convert.ToInt32(Math.Truncate(TextSize.Width + 1.0));
        Int32 TopText = Top + (HeightOfItem / 2) - (TextHeight / 2);
        MyGraph.DrawString(Text, MyFont, MyBrush, LeftText, TopText);

      }
    }

    //
    //**********************************************************************************************
    //

    private TElement PointInElement(List<TElement> aElement, Double aX, Double aY)
    {
      TElement TheElement = null;
      foreach (TElement MyElement in aElement)
      {
        if (MyElement.IsInteriorPoint(aX, aY))
        {
          TheElement = MyElement;
          break;
        }
      }
      return TheElement;
    }

    //
    //**********************************************************************************************
    //

    public Color GetColor(Double aTheta, List<TMoistureClass> aClass)
    {
      Color MyColor = BackgroundColor;
      if (aTheta <= aClass[0].LowLimit) 
      {
        MyColor = aClass[0].TheColor;
      }
      else
      {
        if (aTheta >= aClass[aClass.Count-1].HighLimit)
        {
          MyColor = aClass[aClass.Count-1].TheColor;
        }
        else
        {
          Int32 i = 0;
          while (i < aClass.Count)
          {
            if ((aTheta >= aClass[i].LowLimit) & (aTheta <= aClass[i].HighLimit))
            {
              MyColor = aClass[i].TheColor;
              i = aClass.Count;
            }
            i++;
          }
        }
      }
      return MyColor;
    }

    //
    //**********************************************************************************************
    //

    private Double SurfacePosition(List<TPoint> aTop, Double aX)
    {
      Double Surface = 0.0;
      if (aX <= aTop[0].X)
      {
        Surface = aTop[0].Y;
      }
      else
      {
        if (aX >= aTop[aTop.Count - 1].X)
        {
          Surface = aTop[aTop.Count - 1].Y;
        }
        else
        {
          for (Int32 i = 0; i < aTop.Count; i++)
          {
            if (aTop[i].X >= aX)
            {
              Double Slope = (aTop[i].Y - aTop[i - 1].Y) / (aTop[i].X - aTop[i - 1].X);
              Surface = aTop[i - 1].Y + Slope * (aX - aTop[i - 1].X);
              break;
            }
          }
        }
      }
      return Surface;
    }

    //
    //**********************************************************************************************
    //

    public void Clear()
    {
      Color MyColor = BackgroundColor;
      for (Int32 i = 0; i <= HorSize - 1; i++)
      {
        for (Int32 j = 0; j <= VertSize - 1; j++)
        {
          MyBitmap.SetPixel(i, j, MyColor);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawMoistureContents(List<TPoint> aTop, ProgressBar aPointBar,
      List<TElement> aElements, List<TMoistureClass> aClass, Double[] aTheta)
    {
      aPointBar.Minimum = 0;
      aPointBar.Maximum = MyBitmap.Height - 1;
      for (Int32 Ylocal = 0; Ylocal < MyBitmap.Height; Ylocal++)
      {
        if (Ylocal % 10 == 0)
        {
          aPointBar.Value = Ylocal;
          Application.DoEvents();
        }
        Double Y = YMin + ((VertSize - Ylocal) / dY);

        for (Int32 Xlocal = 0; Xlocal < MyBitmap.Width; Xlocal++)
        {
          Double X = XMin + (Xlocal / dX);
          Double YTop = SurfacePosition(aTop, X);

          Color MyColor = BackgroundColor;

          if (Y < YTop)
          {
            foreach (TElement MyElement in aElements)
            {
              if (MyElement.IsInteriorPoint(X, Y))
              {
                Double Theta = MyElement.ThetaAtXY(aTheta, TAssignmentMethod.Interpolate, X, Y);
                MyColor = GetColor(Theta, aClass);
                break;
              }
            }
          }
          MyBitmap.SetPixel(Xlocal, Ylocal, MyColor);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public Color GetDerivedColor(Double aTheta, List<TDerivedClass> aClass, List<Double> aDerivedValue, List<TDerivationLimits> aLimits, Double aZ)
    {
      // first get derived value
      Double DerivedValue = -9999.0;
      if (aZ > aLimits[0].z)
      {
        if (aTheta < aLimits[0].Percentage[0])
        {
          DerivedValue = aDerivedValue[0];
        }
        else
        {
          if (aTheta > aLimits[0].Percentage[aLimits[0].Percentage.Count - 1])
          {
            DerivedValue = aDerivedValue[aDerivedValue.Count];
          }
          else
          {
            for (Int32 i = 1; i <= aLimits[0].Percentage.Count - 1; i++)
            {
              if ((aTheta >= aLimits[0].Percentage[i - 1]) & (aTheta <= aLimits[0].Percentage[i]))
              {
                DerivedValue = aDerivedValue[i + 1];
                break;
              }
            }
          }
        }
      }
      else
      {
        if (aZ <= aLimits[aLimits.Count - 1].z)
        {
          if (aTheta < aLimits[aLimits.Count - 1].Percentage[0])
          {
            DerivedValue = aDerivedValue[0];
          }
          else
          {
            if (aTheta > aLimits[aLimits.Count - 1].Percentage[aLimits[0].Percentage.Count - 1])
            {
              DerivedValue = aDerivedValue[aDerivedValue.Count-1];
            }
            else
            {
              for (Int32 i = 1; i <= aLimits[aLimits.Count - 1].Percentage.Count - 1; i++)
              {
                if ((aTheta >= aLimits[aLimits.Count - 1].Percentage[i - 1]) & (aTheta <= aLimits[aLimits.Count - 1].Percentage[i]))
                {
                  DerivedValue = aDerivedValue[i + 1];
                  break;
                }
              }
            }
          }
        }
        else
        {
          // interpolate z
          List<Double> P = new List<Double>();
          for (Int32 i = 1; i <= aLimits.Count - 1; i++)
          {
            if ((aZ <= aLimits[i - 1].z) & (aZ >= aLimits[i].z))
            {
              for (Int32 j = 0; j <= aLimits[i].Percentage.Count - 1; j++)
              {
                Double NewP = aLimits[i-1].Percentage[j] + ((aZ - aLimits[i - 1].z) * 
                  (aLimits[i].Percentage[j] - aLimits[i - 1].Percentage[j]) / (aLimits[i].z - aLimits[i - 1].z));
                P.Add(NewP);
              }
              break;
            }
          }
          // now check theta
          if (aTheta <= P[0])
          {
            DerivedValue = aDerivedValue[0];
          }
          else
          {
            if (aTheta >= P[P.Count - 1])
            {
              DerivedValue = aDerivedValue[aDerivedValue.Count - 1];
            }
            else
            {
              for (Int32 i = 1; i <= P.Count - 1; i++)
              {
                if ((aTheta >= P[i - 1]) & (aTheta <= P[i]))
                {
                  DerivedValue = aDerivedValue[i];
                  break;
                }
              }
            }
          }
        }
      }

      Color MyColor = BackgroundColor;
      if (DerivedValue <= aClass[0].LowLimit)
      {
        MyColor = aClass[0].TheColor;
      }
      else
      {
        if (DerivedValue >= aClass[aClass.Count - 1].HighLimit)
        {
          MyColor = aClass[aClass.Count - 1].TheColor;
        }
        else
        {
          Int32 i = 0;
          while (i < aClass.Count)
          {
            if ((DerivedValue >= aClass[i].LowLimit) & (DerivedValue <= aClass[i].HighLimit))
            {
              MyColor = aClass[i].TheColor;
              i = aClass.Count;
            }
            i++;
          }
        }
      }
      return MyColor;
    }

    //
    //**********************************************************************************************
    //

    public void DrawDerivedData(List<TPoint> aTop, ProgressBar aPointBar,
      List<TElement> aElements, List<TDerivedClass> aClass, Double[] aTheta, List<Double> aDerivedValue, List<TDerivationLimits> aLimits)
    {
      aPointBar.Minimum = 0;
      aPointBar.Maximum = MyBitmap.Height - 1;
      for (Int32 Ylocal = 0; Ylocal < MyBitmap.Height; Ylocal++)
      {
        if (Ylocal % 10 == 0)
        {
          aPointBar.Value = Ylocal;
          Application.DoEvents();
        }
        Double Y = YMin + ((VertSize - Ylocal) / dY);

        for (Int32 Xlocal = 0; Xlocal < MyBitmap.Width; Xlocal++)
        {
          Double X = XMin + (Xlocal / dX);
          Color MyColor = BackgroundColor;

          foreach (TElement MyElement in aElements)
          {
            if (MyElement.IsInteriorPoint(X, Y))
            {
              Double Theta = MyElement.ThetaAtXY(aTheta, TAssignmentMethod.Interpolate, X, Y);
              MyColor = GetDerivedColor(Theta, aClass, aDerivedValue, aLimits, Y);
              break;
            }
          }
          MyBitmap.SetPixel(Xlocal, Ylocal, MyColor);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void SetDrawingArea(Int32 aHor, Int32 aVert)
    {
      MyChart = new TChart();
      MyChart.Width = aHor;
      MyChart.Height = aVert;
      HorSize = aHor;
      VertSize = aVert;
      HorSizeChart = aHor;
      VertSizeChart = aVert;
      MyChart.Aspect.View3D = false;

      MyBitmap = new Bitmap(HorSizeChart, VertSizeChart);
      MyGraph = Graphics.FromImage(MyBitmap);
    }

    //
    //**********************************************************************************************
    //

    public Bitmap GetBitmap(Boolean aLegend)
    {
      if (aLegend)
      {
        return MyBitmap;
      }
      else
      {
        Int32 OffSet = HorSizeChart - HorSize;
        Bitmap NewBitmap = new Bitmap(HorSizeChart, VertSizeChart);
        Graphics NewGraph = Graphics.FromImage(NewBitmap);
        NewGraph.DrawImage(MyChart.Bitmap, 0, 0);
        NewGraph.DrawImage(MyBitmap, HorOffset, VertOffset);
        return NewBitmap;
      }
    }
  }
}
