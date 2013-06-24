using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TDRFree
{
  class TDerivedClass
  {
    public Double LowLimit;
    public Double HighLimit;
    public Color TheColor;
    public String TheName;
    
    //
    //**********************************************************************************************
    //
    // Class TDerivedClass
    //   Part of  : TDRFree
    //   Function : Class definition of the derived property
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TDerivedClass(Double aLow, Double aHigh, Int32 aR, Int32 aG, Int32 aB, String aName)
    {
      LowLimit = aLow;
      HighLimit = aHigh;
      TheColor = System.Drawing.Color.FromArgb(aR, aG, aB);
      TheName = aName;
    }
  }
}
