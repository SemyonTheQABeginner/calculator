using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hueta;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Calculator calculator = new Calculator();
    public MainWindow()
    {
        InitializeComponent();
        display.Content = calculator.Display;
        pamet.Content = calculator.Pamet;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        calculator.Tlacitko((sender as Button).Content.ToString());
        display.Content = calculator.Display;
        pamet.Content = calculator.Pamet;
    }
}