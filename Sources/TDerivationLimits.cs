using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDRFree
{
  class TDerivationLimits
  {
    public Double z;
    public List<Double> Percentage;
 
    //
    //**********************************************************************************************
    //
    // Class TDerivationLimits
    //   Part of  : TDRFree
    //   Function : Limits of the derived properties
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TDerivationLimits()
    {
      Percentage = new List<Double>();
      z = -9999.0;
    }
  }
}
