using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDRFree
{
  class TPlotToShow
  {
    public TItemToVisualize ItemToVisualize;
    public Int32 PlotId;

    //
    //**********************************************************************************************
    //
    // Class TPlotToShow
    //   Part of  : TDRFree
    //   Function : Indicates which plot to show
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //
    
    public TPlotToShow()
    {
      PlotId = -1; 
      ItemToVisualize = TItemToVisualize.Nothing;
    }
  }
}
