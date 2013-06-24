using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TDRFree
{
  enum TItemToVisualize { Nothing, MoistureContent, Derived };
  enum TAssignmentMethod { None, Interpolate, NearestNeighbour };

  class TPlot
  {
    public Int32 FirstNode;
    public Int32 LastNode;
    public Int32 PlotHeight;
    public Int32 PlotWidth;
    public Int32 Id;
    public String Description;
    private List<TPoint> Top;
    private List<TPoint> Bottom;
    private List<TPoint> Left;
    private List<TPoint> Right;
    private TDrawing MoistureDrawing;
    private TDrawing DerivedDrawing;
    public List<TNode> Node;
    public List<TElement> Element;
    public List<TVirtualNode> VirtualNode;
    public Int32 NumberOfNodes;
    public List<Double> ValuesForDerivation;
    public List<TDerivationLimits> DerivationLimits;
    public Color BackgroundColor;
    public TAssignmentMethod AssignmentMethod;

    //
    //**********************************************************************************************
    //
    // Class TPlot
    //   Part of  : TDRFree
    //   Function : Routines and data to draw moisture contents and derived properties of a plot
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TPlot(Int32 aId)
    {
      FirstNode = -1;
      LastNode = -1;
      PlotHeight = 0;
      PlotWidth = 0;
      Id = aId;
      Description = "";
      Top = new List<TPoint>();
      Bottom = new List<TPoint>();
      Left = new List<TPoint>();
      Right = new List<TPoint>();
      MoistureDrawing = new TDrawing(Color.Black, Color.White);
      DerivedDrawing = new TDrawing(Color.Black, Color.White);
      Node = new List<TNode>();
      Element = new List<TElement>();
      VirtualNode = new List<TVirtualNode>();
      NumberOfNodes = -1;
      DerivationLimits = new List<TDerivationLimits>();
      ValuesForDerivation = new List<Double>();
    }

    //
    //**********************************************************************************************
    //

    public void SetBackgoundColor(Color aColor)
    {
      BackgroundColor = aColor;
      MoistureDrawing.BackgroundColor = aColor;
      DerivedDrawing.BackgroundColor = aColor;
    }

    //
    //**********************************************************************************************
    //

    public void DrawMoistureLegend(List<TMoistureClass> aClass)
    {
      MoistureDrawing.DrawLegend(aClass);
    }

    //
    //**********************************************************************************************
    //

    public void DrawDerivedLegend(List<TMoistureClass> aClass)
    {
      DerivedDrawing.DrawLegend(aClass);
    }
    
    //
    //**********************************************************************************************
    //

    public void AddBoundaries(List<TPoint> aTop, List<TPoint> aBottom, List<TPoint> aLeft, List<TPoint> aRight)
    {
      Top.Clear();
      foreach (TPoint MyPoint in aTop)
      {
        Top.Add(MyPoint);
      }
      Bottom.Clear();
      foreach (TPoint MyPoint in aBottom)
      {
        Bottom.Add(MyPoint);
      }
      Left.Clear();
      foreach (TPoint MyPoint in aLeft)
      {
        Left.Add(MyPoint);
      }
      Right.Clear();
      foreach (TPoint MyPoint in aRight)
      {
        Right.Add(MyPoint);
      }
    }

    //
    //**********************************************************************************************
    //

    private void ComputeVirtualTheta(Double[] aTheta)
    {
      Double d0;
      Double d1;
      Double d2;
      Double Nominator;
      Double Denominator;
      foreach (TVirtualNode MyNode in VirtualNode)
      {
        d0 = Math.Sqrt((Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[0] - 1].X) *
                       (Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[0] - 1].X) +
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[0] - 1].Y) *
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[0] - 1].Y));
        d1 = Math.Sqrt((Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[1] - 1].X) *
                       (Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[1] - 1].X) +
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[1] - 1].Y) *
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[1] - 1].Y));
        d2 = Math.Sqrt((Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[2] - 1].X) *
                       (Node[MyNode.Id - 1].X - Node[MyNode.Neighbour[2] - 1].X) +
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[2] - 1].Y) *
                       (Node[MyNode.Id - 1].Y - Node[MyNode.Neighbour[2] - 1].Y));
        Nominator = aTheta[MyNode.Neighbour[0]-1] / d0;
        Denominator = 1.0 / d0;
        if (MyNode.Neighbour[1] != MyNode.Neighbour[0])
        {
          Nominator = Nominator + (aTheta[MyNode.Neighbour[1] - 1] / d1);
          Denominator = Denominator + (1.0 / d1);
        }
        if ((MyNode.Neighbour[2] != MyNode.Neighbour[0]) & (MyNode.Neighbour[2] != MyNode.Neighbour[1]))
        {
          Nominator = Nominator + aTheta[MyNode.Neighbour[2] - 1] / d2;
          Denominator = Denominator + (1.0 / d2);
        }
        aTheta[MyNode.Id - 1] = Nominator / Denominator;
      }
    }

    //
    //**********************************************************************************************
    //

    private void CorrectTop()
    {
      Double MaxY = -1.0e30;
      foreach (TNode MyNode in Node)
      {
        if (MyNode.Y > MaxY)
        {
          MaxY = MyNode.Y;
        }
      }

      Double MaxTop = -1.0e30;
      foreach (TPoint MyPoint in Top)
      {
        if (MyPoint.Y > MaxTop)
        {
          MaxTop = MyPoint.Y;
        }
      }

      foreach (TPoint MyPoint in Top)
      {
        MyPoint.Y = MyPoint.Y - (MaxTop - MaxY);
      }
    }

    //
    //**********************************************************************************************
    //

    public void DrawMoistureContours()
    {
      MoistureDrawing.Scale(Top, Right, Bottom, Left);
      MoistureDrawing.DrawContours();
    }

    public void DrawDerivedContours()
    {
      DerivedDrawing.Scale(Top, Right, Bottom, Left);
      DerivedDrawing.DrawContours();
    }

    //
    //**********************************************************************************************
    //

    public Bitmap GetMoistureBitmap(Boolean aLegend)
    {
      return MoistureDrawing.GetBitmap(aLegend);
    }

    //
    //**********************************************************************************************
    //

    public Bitmap GetDerivedBitmap(Boolean aLegend)
    {
      return DerivedDrawing.GetBitmap(aLegend);
    }

    //
    //**********************************************************************************************
    //

    public Bitmap GetBitmap(TItemToVisualize aItem)
    {
      Bitmap MyBitmap;
      if (aItem == TItemToVisualize.MoistureContent)
      {
        MyBitmap = GetMoistureBitmap(false);
      }
      else
      {
        MyBitmap = GetDerivedBitmap(false);
      }
      return MyBitmap;
    }

    //
    //**********************************************************************************************
    //

    private void FindNumberOfNodes()
    {
      NumberOfNodes = 0;
      foreach (TNode MyNode in Node)
      {
        if (MyNode.Virtual == false)
        {
          NumberOfNodes = NumberOfNodes + 1;
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void PrepareAndDrawGrid(TItemToVisualize aItem)
    {
      CorrectTop();
      if (aItem == TItemToVisualize.MoistureContent)
      {
        MoistureDrawing.Scale(Top, Right, Bottom, Left);
        MoistureDrawing.DrawContours();
        MoistureDrawing.DrawElements(Element);
        MoistureDrawing.DrawNodes(Node);
      }
      else
      {
        DerivedDrawing.Scale(Top, Right, Bottom, Left);
        DerivedDrawing.DrawContours();
        DerivedDrawing.DrawElements(Element);
        DerivedDrawing.DrawNodes(Node);
      }
      FindNumberOfNodes();
    }

    //
    //**********************************************************************************************
    //

    public void ProcessTheta(Double[] aTheta, ProgressBar brPoints, List<TMoistureClass> aMoistureClass, 
      List<TDerivedClass> aDerivedClass, TItemToVisualize aItem)
    {
      ComputeVirtualTheta(aTheta);

      if (aItem == TItemToVisualize.MoistureContent)
      {
        MoistureDrawing.DrawMoistureContents(Top, brPoints, Element, aMoistureClass, aTheta);
      }
      else
      {
        DerivedDrawing.DrawDerivedData(Top, brPoints, Element, aDerivedClass, aTheta, ValuesForDerivation, DerivationLimits);
      }
      //        MyDrawing.DrawElements(Element);
      //        MyDrawing.DrawNodes(Node);
    }

    public void SetDrawingArea(Int32 aWidth, Int32 aHeight)
    {
      PlotWidth = aWidth;
      PlotHeight = aHeight;
      MoistureDrawing.SetDrawingArea(PlotWidth, PlotHeight);
      DerivedDrawing.SetDrawingArea(PlotWidth, PlotHeight);
    }
  }
}
