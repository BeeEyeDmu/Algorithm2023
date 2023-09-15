using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _005_ClosestPair
{
  internal class PointPair
  {
    public Point P1 { get; set; }
    public Point P2 { get; set; }
    public double Dist { get; set; }

    public PointPair(Point p1, Point p2, double dist)
    {
      P1 = p1;
      P2 = p2;
      Dist = dist;
    }
  }
}
