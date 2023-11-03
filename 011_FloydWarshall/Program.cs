using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_FloydWarshall
{
  internal class Program
  {
    static int V = 5;   // vertex의 수
    const int Inf = 100;  // 무한대
    static void Main(string[] args)
    {
      // 인접행렬(Adjacent Matrix)
      int[,] graph =
      {
        {0, 4, 2, 5, Inf },
        {Inf, 0, 1, Inf, 4 },
        {1, 3, 0, 1, 2 },
        {-2, Inf, Inf, 0, 2 },
        {Inf, -3, 3, 1, 0 }
      };

      FloydWarshall(graph, V);
    }

    private static void FloydWarshall(int[,] graph, int v)
    {
      Console.WriteLine("Graph");
      PrintGraph(graph, v);

      for(int k=0; k<v; k++)
      {
        for (int i = 0; i < v; i++)
        {
          for (int j = 0; j < v; j++)
          {
            if (graph[i, k]!=Inf && graph[k, j] != Inf &&
              graph[i, k] + graph[k, j] < graph[i, j])
            {
              graph[i, j] = graph[i, k] + graph[k, j];
              Console.WriteLine("Change: [{0},{1}] = [{2},{3}]+" +
                "[{4},{5}] = {6}", i, j, i, k, k, j, graph[i, j]);
            }
          }
        }
        PrintGraph(graph, v);
      }
    }

    private static void PrintGraph(int[,] graph, int v)
    {
      for (int i = 0; i < v; i++)
      {
        for (int j = 0; j < v; j++)
          Console.Write("{0,8}", graph[i, j]);
        Console.WriteLine();
      }
    }
  }
}
