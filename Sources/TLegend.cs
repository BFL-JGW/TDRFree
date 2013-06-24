using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TDRFree
{
  class TLegend
  {
    private TDrawing Drawing;
    private Int32 PlotWidth;
    private Int32 PlotHeight;
    private Color BackgroundColor;
    private Color ForegroundColor;

    //
    //**********************************************************************************************
    //
    // Class TLegend
    //   Part of  : TDRFree
    //   Function : Contains the legend of the contourplots
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //
    
    public TLegend(Color aBackColor, Color aForeColor)
    {
      BackgroundColor = aBackColor;
      ForegroundColor = aForeColor;
      Drawing = new TDrawing(aBackColor, aForeColor);
    }

    //
    //**********************************************************************************************
    //

    public Bitmap GetBitmap(Boolean aLegend)
    {
      return Drawing.GetBitmap(aLegend);
    }

    //
    //**********************************************************************************************
    //

    public void DrawDerivedLegend(List<TDerivedClass> aClass)
    {
      Drawing.DrawDerivedLegend(aClass);
    }

    //
    //**********************************************************************************************
    //

    public void DrawLegend(List<TMoistureClass> aClass)
    {
      Drawing.DrawLegend(aClass);
    }
    public void SetDrawingArea(Int32 aWidth, Int32 aHeight)
    {
      PlotWidth = aWidth;
      PlotHeight = aHeight;
      Drawing.SetDrawingArea(PlotWidth, PlotHeight);
    }

  }
}
