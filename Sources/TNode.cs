using System;
using System.Collections.Generic;
using System.Text;

namespace TDRFree
{
  class TNode
  {
    public Double X;
    public Double Y;
    public Int32 Id;
    public Boolean Virtual;
    
    //
    //**********************************************************************************************
    //
    // Class TNode
    //   Part of  : TDRFree
    //   Function : Properties of the node as in the Finite Element Method
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TNode(Int32 aId, Double aX, Double aY, Boolean aVirtual)
    {
      Id = aId;
      X = aX;
      Y = aY;
      Virtual = aVirtual;
    }
  }
}
