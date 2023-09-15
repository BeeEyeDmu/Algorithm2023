using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _004_SortGraph
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    static int MAX = 100000;
    int[] a = new int[MAX];
    int N = 0;    // 데이터의 갯수
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnRandom_Click(object sender, RoutedEventArgs e)
    {
      N = int.Parse(txtNo.Text);

      Random r = new Random();
      for (int i = 0; i < N; i++)
        a[i] = r.Next(N*3);

      Graph();
    }

    private void Graph()
    {
      can.Children.Clear();
      for(int i=0; i<N; i++)
      {
        Line l = new Line();
        l.X1 = l.X2 = i * 5;
        if (l.X1 > can.Width)
          break;
        l.Y1 = can.Height - 
          (int)(a[i] / (3.0 * N) * can.Height);
        l.Y2 = can.Height;
        l.Stroke = Brushes.RoyalBlue;
        l.StrokeThickness = 4;
        can.Children.Add(l);
      }
    }

    private void btnBubble_Click(object sender, RoutedEventArgs e)
    {
      BubbleSort();
    }

    private void BubbleSort()
    {
      for(int i=N-1; i>0; i--)
        for(int j=0; j<i; j++)
          if (a[j] > a[j+1])
          {
            int t = a[j];
            a[j] = a[j + 1];
            a[j + 1] = t;
          }

      Graph();
    }

    private void btnQuick_Click(object sender, RoutedEventArgs e)
    {
      QuicKSort(a, 0, N-1);
      Graph();
    }

    private void QuicKSort(int[] a, int left, int right)
    {
      if(left < right)
      {
        int q = Partition(a, left, right);
        QuicKSort(a, left, q - 1);
        QuicKSort(a, q + 1, right);
      }
    }

    private int Partition(int[] a, int left, int right)
    {
      int i = left;
      int j = right;

      int pivot = a[left];

      while(i < j)
      {
        while ((i <= right) && (a[i] < pivot))
          i++;
        while ((j >= left) && (a[j] > pivot))
          j--;

        if(i < j)
        {
          int t = a[i];
          a[i] = a[j];
          a[j] = t;

          if (a[i] == a[j])
            j--;
        }
      }

      return j;
    }

    private void btnMerge_Click(object sender, RoutedEventArgs e)
    {
      MergeSort(a, 0, N-1);
      Graph();
    }

    private void MergeSort(int[] a, int left, int right)
    {
      if(left < right)
      {
        int mid = (left+right) / 2;
        MergeSort(a, left, mid);
        MergeSort(a, mid + 1, right);
        Merge(a, left, mid, right);
      }
    }

    int[] sorted = new int[MAX];
    private void Merge(int[] a, int left, int mid, int right)
    {
      int i, j, k = left;
      for (i = left, j = mid + 1; i <= mid && j <= right;)
        sorted[k++] = (a[i] <= a[j]) ? a[i++] : a[j++];
      if (i > mid)
        for (int l = j; l <= right; l++)
          sorted[k++] = a[l];
      else
        for (int l = i; l <= mid; l++)
          sorted[k++] = a[l];

      // sorted[]을 a[]로 복사
      for (int l = left; l <= right; l++)
        a[l] = sorted[l];
    }

    private void btnTime_Click(object sender, RoutedEventArgs e)
    {
      var watch = System.Diagnostics.Stopwatch.StartNew();
      BubbleSort();
      watch.Stop();
      long tickBubble = watch.ElapsedTicks;
      long msBubble = watch.ElapsedMilliseconds;
      txtBubble.Text = "Bubble Sort : " + tickBubble 
        + " Ticks, " + msBubble + " ms";

      N = int.Parse(txtNo.Text);

      Random r = new Random();
      for (int i = 0; i < N; i++)
        a[i] = r.Next(N * 3);

      watch = System.Diagnostics.Stopwatch.StartNew();
      QuicKSort(a, 0, N - 1); 
      watch.Stop();
      long tickQuick = watch.ElapsedTicks;
      long msQuick = watch.ElapsedMilliseconds;
      txtQuick.Text = "Quick Sort : " + tickQuick
        + " Ticks, " + msQuick + " ms";

      watch = System.Diagnostics.Stopwatch.StartNew();
      MergeSort(a, 0, N - 1);
      watch.Stop();
      long tickMerge = watch.ElapsedTicks;
      long msMerge = watch.ElapsedMilliseconds;
      txtMerge.Text = "Merge Sort : " + tickMerge
        + " Ticks, " + msMerge + " ms";

      Graph();
    }
  }
}
