using System;
using System.Collections.Generic;

namespace TDRFree
{
  class TElement
  {
    public Int32 Id;
    public Int32 Steps;
    public TNode[] Node;
    public Double Area;
    public Double[] Alpha;
    public Double[] Beta;
    public Double[] Gamma;
    public Double[] Delta;
    public List<TThetaPoint> Theta;
    public Boolean Virtual;
    
    //
    //**********************************************************************************************
    //
    // Class TElement
    //   Part of  : TDRFree
    //   Function : All functions related to the element in the Finite Element Method
    //   Author   : Jan G. Wesseling
    //   Date     : April 9th, 2013
    //
    //**********************************************************************************************
    //

    public TElement()
    {
      Id = -1;
      Virtual = false;
      Node = new TNode[4];
      Theta = new List<TThetaPoint>();
    }

    //
    //**********************************************************************************************
    //
    
    private Double ComputeAreaOfShape(TNode[] aNode)
    {
      Int32 j;
      Int32 N = aNode.Length;
      Double MyArea = 0.0;
      for (Int32 i = 0; i < N; i++)
      {
        j = i + 1;
        if (j > N - 1)
        {
          j = j - N;
        }

        MyArea = MyArea + aNode[i].X * aNode[j].Y - aNode[j].X * aNode[i].Y;
      }
      MyArea = 0.5 * MyArea;
      return MyArea;
    }

    //
    //**********************************************************************************************
    //

    private void ComputeArea()
    {
      Area = ComputeAreaOfShape(Node);
    }

    //
    //**********************************************************************************************
    //

    public Boolean IsInteriorPoint(Double aX, Double aY)
    {
      Boolean Interior = true;
      Double Direction = 0.0;
      Int32 i = -1;
      Int32 j;
      Int32 N=Node.Length;

      while (i < N - 1)
      {
        i++;
        j = i + 1;
        if (j == N)
        {
          j = 0;
        }
        Direction = (aY - Node[i].Y) * (Node[j].X - Node[i].X) - (aX - Node[i].X) * (Node[j].Y - Node[i].Y);
        if (Direction < 0.0)
        {
          Interior = false;
          i = N;
        }
      }
      return Interior;
    }

    //
    //**********************************************************************************************
    //

    private Double[] Solve(Double[,] aMatrix, Double[] aVector)
    {
      Double[] Sol = new Double[aVector.Length];
      Boolean[] Pivot = new Boolean[aVector.Length];
      for (Int32 i = 0; i < aVector.Length; i++)
      {
        Pivot[i] = false;
      }

      Double MyValue;
      for (Int32 i = 0; i < aVector.Length-1; i++)
      {
        // correct row i
        MyValue = aMatrix[i, i];
        for (Int32 j = i; j < aVector.Length; j++)
        {
          aMatrix[i, j] = aMatrix[i, j] / MyValue;
        }
        aVector[i] = aVector[i] / MyValue;

        // the other rows
        for (Int32 k = i + 1; k < aVector.Length; k++)
        {
          MyValue = aMatrix[k, i];
          for (Int32 j = i; j < aVector.Length; j++)
          {
            aMatrix[k, j] = aMatrix[k, j] - MyValue * aMatrix[i, j];
          }
          aVector[k] = aVector[k] - MyValue * aVector[i];
        }
      }

      // solution
      Sol[aVector.Length-1] = aVector[aVector.Length-1] / aMatrix[aVector.Length-1,aVector.Length-1];
      for (Int32 i = aVector.Length-2; i>=0; i--)
      {
        Sol[i] = aVector[i];
        for (Int32 j = i + 1; j <= aVector.Length - 1; j++)
        {
          Sol[i] = Sol[i] - aMatrix[i, j] * Sol[j];
        }
      }
      return Sol;
    }

    //
    //**********************************************************************************************
    //

    private void ComputeAlpha()
    {
      Alpha = new Double[4];
      Double[,] Matrix = new Double[4, 4];
      Double[] Vector = new Double[4];

      // fill matrix
      Matrix[0, 0] = 1.0; Matrix[0, 1] = -1.0; Matrix[0, 2] = -1.0; Matrix[0, 3] = 1.0;
      Matrix[1, 0] = 1.0; Matrix[1, 1] = 1.0; Matrix[1, 2] = -1.0; Matrix[1, 3] = -1.0;
      Matrix[2, 0] = 1.0; Matrix[2, 1] = 1.0; Matrix[2, 2] = 1.0; Matrix[2, 3] = 1.0;
      Matrix[3, 0] = 1.0; Matrix[3, 1] = -1.0; Matrix[3, 2] = 1.0; Matrix[3, 3] = -1.0;

      // fill vector
      for (Int32 i = 0; i <= 3; i++)
      {
        Vector[i] = Node[i].X;
      }

      Alpha = Solve(Matrix, Vector);
    }

    //
    //**********************************************************************************************
    //

    private void ComputeBeta()
    {
      Beta = new Double[4];
      Double[,] Matrix = new Double[4, 4];
      Double[] Vector = new Double[4];

      // fill matrix
      Matrix[0, 0] = 1.0; Matrix[0, 1] = -1.0; Matrix[0, 2] = -1.0; Matrix[0, 3] = 1.0;
      Matrix[1, 0] = 1.0; Matrix[1, 1] = 1.0; Matrix[1, 2] = -1.0; Matrix[1, 3] = -1.0;
      Matrix[2, 0] = 1.0; Matrix[2, 1] = 1.0; Matrix[2, 2] = 1.0; Matrix[2, 3] = 1.0;
      Matrix[3, 0] = 1.0; Matrix[3, 1] = -1.0; Matrix[3, 2] = 1.0; Matrix[3, 3] = -1.0;

      // fill vector
      for (Int32 i = 0; i <= 3; i++)
      {
        Vector[i] = Node[i].Y;
      }

      Beta = Solve(Matrix, Vector);
    }

    //
    //**********************************************************************************************
    //

    private void ComputeGamma()
    {
      Gamma = new Double[4];
      Double[,] Matrix = new Double[4, 4];
      Double[] Vector = new Double[4];

      // fill matrix
      Matrix[0, 0] = 1.0; Matrix[0, 1] = Node[0].X; Matrix[0, 2] = Node[0].Y; Matrix[0, 3] = Node[0].X * Node[0].Y;
      Matrix[1, 0] = 1.0; Matrix[1, 1] = Node[1].X; Matrix[1, 2] = Node[1].Y; Matrix[1, 3] = Node[1].X * Node[1].Y;
      Matrix[2, 0] = 1.0; Matrix[2, 1] = Node[2].X; Matrix[2, 2] = Node[2].Y; Matrix[2, 3] = Node[2].X * Node[2].Y;
      Matrix[3, 0] = 1.0; Matrix[3, 1] = Node[3].X; Matrix[3, 2] = Node[3].Y; Matrix[3, 3] = Node[3].X * Node[3].Y;

      // fill vector
      Vector[0] = -1.0;
      Vector[1] = 1.0;
      Vector[2] = 1.0;
      Vector[3] = -1.0;

      for (Int32 i = 1; i <= 3; i++)
      {
        if (Node[i].Id == Node[i - 1].Id)
        {
          Vector[i] = 1.0;
          Matrix[i, 0] = 1.0;
          for (Int32 j = 1; j <= 3; j++)
          {
            Matrix[i, j] = 0.0;
          }
        }
      }

      Gamma = Solve(Matrix, Vector);
    }

    //
    //**********************************************************************************************
    //

    private void ComputeDelta()
    {
      Delta = new Double[4];
      Double[,] Matrix = new Double[4, 4];
      Double[] Vector = new Double[4];

      // fill matrix
      Matrix[0, 0] = 1.0; Matrix[0, 1] = Node[0].X; Matrix[0, 2] = Node[0].Y; Matrix[0, 3] = Node[0].X * Node[0].Y;
      Matrix[1, 0] = 1.0; Matrix[1, 1] = Node[1].X; Matrix[1, 2] = Node[1].Y; Matrix[1, 3] = Node[1].X * Node[1].Y;
      Matrix[2, 0] = 1.0; Matrix[2, 1] = Node[2].X; Matrix[2, 2] = Node[2].Y; Matrix[2, 3] = Node[2].X * Node[2].Y;
      Matrix[3, 0] = 1.0; Matrix[3, 1] = Node[3].X; Matrix[3, 2] = Node[3].Y; Matrix[3, 3] = Node[3].X * Node[3].Y;

      // fill vector
      Vector[0] = -1.0;
      Vector[1] = -1.0;
      Vector[2] = 1.0;
      Vector[3] = 1.0;

      for (Int32 i = 1; i <= 3; i++)
      {
        if (Node[i].Id == Node[i - 1].Id)
        {
          Vector[i] = 1.0;
          Matrix[i, 0] = 1.0;
          for (Int32 j = 1; j <= 3; j++)
          {
            Matrix[i, j] = 0.0;
          }
        }
      }
      
      Delta = Solve(Matrix, Vector);
    }

    //
    //**********************************************************************************************
    //

    public Double ThetaAtXY(Double[] aTheta, TAssignmentMethod aMethod, Double aX, Double aY)
    {
      Double N0 = 0.0;
      Double N1 = 0.0;
      Double N2 = 0.0;
      Double N3 = 0.0;

      Double V0 = 0.0;
      Double V1 = 0.0;
      Double V2 = 0.0;
      Double V3 = 0.0;

      Double Value = 0.0;

      if (aMethod == TAssignmentMethod.NearestNeighbour)
      {
        Double MinDist = 1.0e36;
        Int32 IMin = -1;
        for (Int32 k = 0; k <= 3; k++)
        {
          Double d = Math.Sqrt((aX - Node[k].X) * (aX - Node[k].X) + (aY - Node[k].Y) * (aY - Node[k].Y));
          if (d < MinDist)
          {
            MinDist = d;
            IMin = k;
          }
        }
        Value = aTheta[Node[IMin].Id - 1];
      }
      else
      {
        // global to local
        Double Xlocal = Gamma[0] + Gamma[1] * aX + Gamma[2] * aY + Gamma[3] * aX * aY;
        Double Ylocal = Delta[0] + Delta[1] * aX + Delta[2] * aY + Delta[3] * aX * aY;
       
        N0 = 0.25 * (1.0 + Xlocal * (-1.0)) * (1.0 + Ylocal * (-1.0));
        N1 = 0.25 * (1.0 + Xlocal * (1.0)) * (1.0 + Ylocal * (-1.0));
        N2 = 0.25 * (1.0 + Xlocal * (1.0)) * (1.0 + Ylocal * (1.0));
        N3 = 0.25 * (1.0 + Xlocal * (-1.0)) * (1.0 + Ylocal * (1.0));

        V0 = aTheta[Node[0].Id - 1];
        V1 = aTheta[Node[1].Id - 1];
        V2 = aTheta[Node[2].Id - 1];
        V3 = aTheta[Node[3].Id - 1];

        Value = N0 * V0 + N1 * V1 + N2 * V2 + N3 * V3;
      }
      return Value;
    }

    //
    //**********************************************************************************************
    //

    public void ComputeThetas(Double[] aTheta, TAssignmentMethod aMethod, Int32 aSteps)
    {
      TThetaPoint MyTheta;
      Theta.Clear();
      Double XReal;
      Double YReal;
      Steps = aSteps;
      Double dX = 2.0 / Steps;
      Double dY = 2.0 / Steps;

      Double X = -1.0 - dX;
      Double Y = -1.0 - dX;

      Double N0 = 0.0;
      Double N1 = 0.0;
      Double N2 = 0.0;
      Double N3 = 0.0;

      Double V0 = 0.0;
      Double V1 = 0.0;
      Double V2 = 0.0;
      Double V3 = 0.0;

      Double Value = 0.0;

      for (Int32 i = 0; i <= Steps; i++)
      {
        X = X + dX;
        Y = -1.0 - dY;
        for (Int32 j = 0; j <= Steps; j++)
        {
          Y = Y + dY;
          XReal = Alpha[0] + Alpha[1] * X + Alpha[2] * Y + Alpha[3] * X * Y;
          YReal = Beta[0] + Beta[1] * X + Beta[2] * Y + Beta[3] * X * Y;
          MyTheta = new TThetaPoint();
          MyTheta.X = XReal;
          MyTheta.Y = YReal;

          if (aMethod == TAssignmentMethod.NearestNeighbour)
          {
            Double MinDist = 1.0e36;
            Int32 IMin = -1;
            for (Int32 k = 0; k <= 3; k++)
            {
              Double d = Math.Sqrt((XReal - Node[k].X) * (XReal - Node[k].X) + (YReal - Node[k].Y) * (YReal - Node[k].Y));
              if (d < MinDist)
              {
                MinDist = d;
                IMin = k;
              }
            }
            Value = aTheta[Node[IMin].Id - 1];
          }
          else
          {
            N0 = 0.25 * (1.0 + X * (-1.0)) * (1.0 + Y * (-1.0));
            N1 = 0.25 * (1.0 + X * (1.0)) * (1.0 + Y * (-1.0));
            N2 = 0.25 * (1.0 + X * (1.0)) * (1.0 + Y * (1.0));
            N3 = 0.25 * (1.0 + X * (-1.0)) * (1.0 + Y * (1.0));

            V0 = aTheta[Node[0].Id - 1];
            V1 = aTheta[Node[1].Id - 1];
            V2 = aTheta[Node[2].Id - 1];
            V3 = aTheta[Node[3].Id - 1];

            Value = N0 * V0 + N1 * V1 + N2 * V2 + N3 * V3;
          }
          MyTheta.Theta = Value;

          Theta.Add(MyTheta);
        }
      }
    }

    //
    //**********************************************************************************************
    //

    public void Prepare()
    {
      ComputeArea();
      ComputeAlpha();
      ComputeBeta();
      ComputeGamma();
      ComputeDelta();
    }
  }
}
