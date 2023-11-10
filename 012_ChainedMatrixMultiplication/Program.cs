using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ChainedMatrixMultiplication
{
  internal class Program
  {
    static int nom = 4;
    static void Main(string[] args)
    {
      int[] d = { 10, 20, 5, 15, 30 };

      int multis = 0; // 곱셈수
      for (int i = 0; i <= nom - 2; i++) // 곱셈의 횟수
        multis += d[0] * d[i + 1] * d[i + 2];

      Console.WriteLine("순서대로 곱했을 때의 곱셈수 = " + multis);
      Console.WriteLine("알고리즘에 의한 최소 곱셈수 = " + 
        MatrixChain(d));
    }

    private static int MatrixChain(int[] d)
    {
      int[,] C = new int[nom + 1, nom + 1];
      int Inf = int.MaxValue;

      // 초기화(대각선 0으로)
      for (int i = 1; i <= nom; i++)
        C[i, i] = 0;

      for(int L=1; L<=nom-1; L++)
      {
        for(int i=1; i<=nom-L; i++)
        {
          int j = i + L;
          C[i, j] = Inf;
          for(int k=i; k<=j-1; k++)
          {
            int tmp = C[i, k] + C[k + 1, j] 
              + d[i - 1] * d[k] * d[j];
            if (tmp < C[i, j])
              C[i, j] = tmp;
          }
        }
        PrintC(C, L);
      }
      return C[1, nom];
    }

    private static void PrintC(int[,] C, int L)
    {
      Console.WriteLine("L = " + L);
      for (int i = 1; i <= nom; i++)
      {
        for (int j = 1; j <= nom; j++)
        {
          Console.Write("{0,8}", C[i, j]);
        }
        Console.WriteLine();
      }
    }
  }
}
