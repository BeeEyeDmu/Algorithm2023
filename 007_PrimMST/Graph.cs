using System;

namespace _007_PrimMST
{
  internal class Graph
  {
    static int MAX = 100; // 최대 버텍스 수
    static int INF = 999; // 무한대
    int V = 0;
    string[] vertex = new string[MAX];
    int[,] adj = new int[MAX, MAX];

    internal void ReadGraph(string filename)
    {
      string[] lines
        = System.IO.File.ReadAllLines("../../" + filename);
      V = int.Parse(lines[0]);

      for(int i=1; i<lines.Length; i++)
      {
        // A	0	3	999	2	4	999
        string[] s = lines[i].Split('\t');
        for (int j = 0; j < s.Length; j++)
        {
          Console.Write(s[j] + "\t");          
        }
        Console.WriteLine();
      }
    }
  }
}