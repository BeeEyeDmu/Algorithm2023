using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_dijstra
{
  internal class Program
  {
    static string[] city = { "서울", "천안", "원주", "강릉", 
      "논산", "대전", "대구", "포항", "광주", "부산" };
    static int V = 10;
    static bool[] spt = new bool[V]; // shortest path tree
                                // 최단경로가 결정되면 true
    static int[] D = new int[V];
    static void Main(string[] args)
    {
      int[,] graph = new int[,]
      {
         { 0,   12,  15,  0,   0,   0,   0,   0,   0,   0 },
         { 12,  0,   0,   0,   4,   10,  0,   0,   0,   0 },
         { 15,  0,   0,   21,  0,   0,   7,   0,   0,   0 },
         { 0,   0,   21,  0,   0,   0,   0,   25,  0,   0 },
         { 0,   4,   0,   0,   0,   3,   0,   0,   13,  0 },
         { 0,   10,  0,   0,   3,   0,   10,  0,   0,   0 },
         { 0,   0,   7,   0,   0,   10,  0,   19,  0,   9 },
         { 0,   0,   0,   25,  0,   0,   19,  0,   0,   5 },
         { 0,   0,   0,   0,   13,  0,   0,   0,   0,   15 },
         { 0,   0,   0,  0,   0,   0,   9,   5,   15,  0 }
      };

      ShortestPath(graph, 5); // 출발점 0 = 서울, 5 = 대전
    }

    private static void ShortestPath(int[,] graph, int start)
    {
      // 초기화
      for(int i=0; i<V; i++)
      {
        D[i] = int.MaxValue;
        spt[i] = false;
      }

      D[start] = 0;

      for(int i=0; i<V; i++)
      {
        int minIndex = MinDistance(); // 최단경로의 도시 인덱스
        spt[minIndex] = true;
        Console.WriteLine("minDistance : {0}", city[minIndex]);

        // D[] 업데이트
        // minIndex의 도시와 인접한 도시의 거리를 업데이트
        for(int v=0; v<V; v++)
        {
          if (!spt[v] // 최단경로가 결정되지 않은 도시들
            && graph[minIndex, v] != 0  // minIndex와 연결된 도시
            && D[minIndex] + graph[minIndex, v] < D[v])
          {
            D[v] = D[minIndex] + graph[minIndex, v]; 
          }          
        }
        Console.WriteLine("Iteration: {0}", i);
        PrintD(start);
      }
    }

    private static void PrintD(int start)
    {
      Console.WriteLine("도시\tDistance form {0}", city[start]);
      for(int i=0; i<V; i++)
        Console.WriteLine("{0}\t{1}", city[i], D[i]);
    }

    private static int MinDistance()
    {
      int min = int.MaxValue;
      int minIndex = -1;

      for(int i=0; i<V; i++)
      {
        if (spt[i] == false && D[i] < min)
        {
          min = D[i];
          minIndex = i;
        }
      }
      return minIndex;
    }
  }
}
