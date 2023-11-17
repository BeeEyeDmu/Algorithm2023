using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_Sorting
{
  internal class Program
  {
    static int N = 100;
    static int[] a = new int[N];
    //static Random r = new Random();
    static void Main(string[] args)
    {
      RandomInit();
      PrintArray();

      Array.Sort(a);
      Console.WriteLine("\nArray.Sort() :");
      PrintArray();

      RandomInit();
      BubbleSort();

      RandomInit();
      SelectionSort();

      RandomInit();
      InsertionSort();

      RandomInit();
      ShellSort();

      RandomInit();
      HeapSort();

      RandomInit();
      RadixSort();
    }

    private static void RadixSort()
    {
      int max = GetMax();

      // 자리수에 따라 CountingSort()를 호출
      for (int exp = 1; max / exp > 0; exp *= 10)
        CountingSort(a, exp);

      Console.WriteLine("\nRadixSort :");
      PrintArray();
    }

    private static void CountingSort(int[] a, int exp)
    {
      int[] count = new int[10];
      int[] output = new int[N];  // 중간과정에서 값을 저장하는 배열

      for (int i = 0; i < N; i++)
        count[(a[i] / exp) % 10]++;

      //printCount(count);

      // count[] 배열의 누적값을 만든다
      for (int i = 1; i < 10; i++)
        count[i] += count[i - 1];

      //printCount(count);

      // output[]에 정렬된 값으로 복사
      // 뒤에서부터 하는 이유는 앞에서 정렬된 순서를
      // 유지하기위함
      for(int i=N-1; i>=0; i--)
      {
        int pos = count[(a[i] / exp) % 10] - 1; // 인덱스
        output[pos] = a[i];
        count[(a[i] / exp) % 10]--;
      }

      // output[]을 원래의 a[]에 복사
      for (int i = 0; i < N; i++)
        a[i] = output[i];

      Console.WriteLine("{0}의 자리 정렬", exp);
      PrintArray();
    }

    private static void printCount(int[] count)
    {
      for (int i = 0; i < 10; i++)
        Console.Write(count[i] + " ");
      Console.WriteLine();
    }

    private static int GetMax()
    {
      int max = a[0];

      for(int i=1; i<N; i++)
        if (a[i] > max)
          max = a[i];
      return max;
    }

    private static void HeapSort()
    {
      // 처음에 임의로 저장된 배열을 힙으로 만드는 과정
      for (int i = N / 2 - 1; i >= 0; i--)
        DownHeap(a, N, i);

      Console.WriteLine("Heap 구성 : ");
      PrintArray();

      for(int i=N-1; i>=0; i--)
      {
        // 루트와 맨 뒤의 값을 바꾼다
        Swap(0, i);
        DownHeap(a, i, 0);  // N이 아니고 i이다(하나씩 줄어든다)
      }

      Console.WriteLine("\nHeapSort :");
      PrintArray();
    }

    private static void DownHeap(int[] a, int n, int i)
    {
      int largest = i;
      int left = 2 * i;
      int right = 2 * i + 1;

      if(left < n && a[left] > a[largest])
        largest = left;
      if (right < n && a[right] > a[largest])
        largest = right;

      if(largest != i)  // 자식이 부모보다 큰 경우
      {
        Swap(i, largest);
        DownHeap(a, n, largest);
      }


    }

    private static void ShellSort()
    {
      int[] h = { 0, 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
      int index = 0;  // h[]의 시작하는 값의 인덱스
      while (h[index] < N / 2)
        index++;
      int gap = h[--index];

      while(gap > 0)
      {
        Console.WriteLine("gap = {0}", gap);
        for(int i=gap; i<N; i++)
        {
          int current = a[i];
          int j = i;
          while(j >= gap && a[j-gap] > current)
          {
            a[j] = a[j - gap];
            j = j - gap;
          }
          a[j] = current;
        }
        gap = h[--index];
      }
      Console.WriteLine("\nShellSort :");
      PrintArray();
    }

    private static void InsertionSort()
    {
      for(int i=0; i<N; i++)
      {
        int current = a[i];
        int j = i - 1;
        while(j >= 0 && a[j] > current)
        {
          a[j + 1] = a[j];
          j--;
        }
        a[j+1] = current; 
      }
      Console.WriteLine("\nInsertionSort :");
      PrintArray();
    }

    private static void SelectionSort()
    {
      for(int i=0; i<N-1; i++)
      {
        int min = i;  // 최소값이 들어가 있는 인덱스
        for(int j=i+1; j<N; j++)
          if (a[min] > a[j])
            min = j;
        Swap(i, min);
      }
      Console.WriteLine("\nSelectionSort :");
      PrintArray();
    }

    private static void BubbleSort()
    {
      for(int i=N-1; i>=0; i--)
        for(int j=0; j<i; j++) 
          if (a[j] > a[j+1])          
            Swap(j, j+1);

      Console.WriteLine("\nBubbleSort :");
      PrintArray();
    }

    private static void Swap(int i, int j)
    {
      int t = a[i];
      a[i] = a[j];
      a[j] = t;
    }

    private static void PrintArray()
    {
      foreach(var i in a)
      {
        Console.Write(i + " ");
      }
      Console.WriteLine();
    }

    private static void RandomInit()
    {
      Random r = new Random();
      for (int i=0; i < N; i++)
      {
        a[i] = r.Next(1000);
      }
    }
  }
}
