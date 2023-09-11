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

namespace _002_factorial
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }


    private void button_Click(object sender, RoutedEventArgs e)
    {
      int n = int.Parse(textBox.Text);

      var watch = System.Diagnostics.Stopwatch.StartNew();

      long rfact = 1;
      for (int i = 1; i <= n; i++)
      {
        rfact = rFactorial(i);
        string s
          = string.Format("rfact({0}) = {1}", i, rfact);
        listBox.Items.Add(s);
      }

      watch.Stop();
      var elapsedTicks = watch.ElapsedTicks;      // 또는 watch.ElapsedMilliseconds
      string result = elapsedTicks + " Ticks = " + elapsedTicks / 10000.0 + " ms";
      listBox.Items.Add(result);

      watch = System.Diagnostics.Stopwatch.StartNew();

      long fact = 1;
      for(int i=1; i<=n; i++)
      {
        fact = Factorial(i);
        string s
          = string.Format("fact({0}) = {1}", i, fact);
        listBox.Items.Add(s);
      }
      watch.Stop();
      elapsedTicks = watch.ElapsedTicks;      // 또는 watch.ElapsedMilliseconds

      result = elapsedTicks + " Ticks = " + elapsedTicks / 10000.0 + " ms";
      listBox.Items.Add(result);
    }

    private long rFactorial(int x)
    {
      if (x == 1)
        return 1;
      else
        return rFactorial(x - 1) * x;
    }

    private long Factorial(int x) // 반복문
    {
      long f = 1;
      for (int i = 2; i <= x; i++)
        f *= i;
      return f;
    }
  }
}
