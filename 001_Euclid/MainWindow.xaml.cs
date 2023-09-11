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

namespace _001_Euclid
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
      int x = int.Parse(textBox1.Text);
      int y = int.Parse(textBox2.Text);
      int gcd = Euclid(x, y);
      txtResult.Text 
        = "GCD = " + gcd.ToString();
    }

    private int Euclid(int x, int y)
    {
      if (y == 0)
        return x;
      else
        return Euclid(y, x%y);
    }
  }
}
