using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDRFree
{
  class TVirtualNode
  {
    public Int32 Id;
    public Int32[] Neighbour;
 
    //
    //**********************************************************************************************
    //
    // Class TVirtualNode
    //   Part of  : TDRFree
    //   Function : Properties of a virtual node 
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TVirtualNode()
    {
      Id = -1;
      Neighbour = new Int32[3];
    }
  }
}
