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
using WindowsFormsApp1;
namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc;
        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.DidUpdateValue += Calc_DidUpdateValue;
        }

        private void Calc_DidUpdateValue(Calculator sender, double value, int precision)
        {
            output.Text = value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int digit = -1;
            Button b = sender as Button;
            if (int.TryParse(b.Content.ToString(), out digit))
                calc.AddDigit(digit);
            else
            {
                switch (b.Tag)
                {
                    case "div":
                        calc.AddOperation(CalculatorOperation.Div);
                        break;
                    case "mul":
                        calc.AddOperation(CalculatorOperation.Mul);
                        break;
                    case "min":
                        calc.AddOperation(CalculatorOperation.Sub);
                        break;
                    case "pls":
                        calc.AddOperation(CalculatorOperation.Add);
                        break;
                    case "clear":
                        calc.Clear();
                        break;
                    case "clearall":
                        calc.clearAll();
                        break;
                    case "compute":
                        calc.Compute();
                        break;
                    case "dot":
                        calc.AddPoint();
                        break;
                    case "negate":
                        calc.TransformInput(CalculatorTransformation.Negate);
                        break;
                    case "percent":
                        calc.TransformInput(CalculatorTransformation.Percent);
                        break;
                    case "sqr":
                        calc.TransformInput(CalculatorTransformation.Sqr);
                        break;
                    case "sqrt":
                        calc.TransformInput(CalculatorTransformation.Sqrt);
                        break;
                    case "inverse":
                        calc.TransformInput(CalculatorTransformation.Inverse);
                        break;
                    case "del":
                        calc.RemoveDigit();
                        break;
                }
            }
        }
    }
}
