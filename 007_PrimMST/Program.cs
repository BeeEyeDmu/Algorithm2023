using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_PrimMST
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Graph g = new Graph();
      g.ReadGraph("graph1.txt");
      g.PrintGraph();

      g.Prim(5);  // 0번 버텍스에서 시작하는 MST
    }
  }
}
