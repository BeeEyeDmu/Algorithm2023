using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_Fibonacci
{
  internal class Program
  {
    static long[] f = new long[51];
    static void Main(string[] args)
    {
      for(int i=1; i<=50; i++)
        Console.WriteLine("{0}항 = {1}", i, Fibo(i));
    }

    private static long Fibo(int n)
    {
      if (n == 1 || n == 2)
        return f[n] = 1;
      if (f[n] != 0)  // DP 버전
        return f[n];
      return f[n] = Fibo(n - 1) + Fibo(n - 2);
    }
  }
}
