using System;
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
  }
}
