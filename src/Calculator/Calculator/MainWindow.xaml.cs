/*
Copyright (c) 2021 Parmajiat Foundation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Contributers:
    - @tarekjihad
*/
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        double leftOperand = 0;
        double rightOperand = 0;
        string operation;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberClicked(object sender, RoutedEventArgs e)
        {
            // Check if the current displayed text is 0, then replace it with the clicked number
            // else append the clicked number to current text.
            Button button = (Button)sender;
            if (DisplayTextBox.Text == "0")
            {
                DisplayTextBox.Text = button.Content.ToString();
            }
            else
            {
                DisplayTextBox.Text += button.Content.ToString();
            }
        }
        private void OperationClicked(object sender, RoutedEventArgs e)
        {
            // Store the current number in the left operand value
            // Clear the display to allow entering the right operand
            // Store the operation with the clicked one.
            Button button = (Button)sender;

            leftOperand = double.Parse(DisplayTextBox.Text);

            DisplayTextBox.Text = "";
            operation = button.Content.ToString();

        }
        private void DecimalClicked(object sender, RoutedEventArgs e)
        {
            if (!DisplayTextBox.Text.Contains("."))
                DisplayTextBox.Text += ".";
        }
        private void EqualClicked(object sender, RoutedEventArgs e)
        {
            rightOperand = double.Parse(DisplayTextBox.Text);

            if (operation == "+")
                DisplayTextBox.Text = (leftOperand + rightOperand).ToString();

            else if (operation == "-")
                DisplayTextBox.Text = (leftOperand - rightOperand).ToString();

            else if (operation == "/")
                DisplayTextBox.Text = (leftOperand / rightOperand).ToString();

            else if (operation == "*")
                DisplayTextBox.Text = (leftOperand * rightOperand).ToString();

            leftOperand = double.Parse(DisplayTextBox.Text);
            operation = "";
            rightOperand = 0;
        }
        private void SignClicked(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(DisplayTextBox.Text);
            DisplayTextBox.Text = (value * -1).ToString();
        }
        private void ClearDigitClicked(object sender, RoutedEventArgs e)
        {
            if (DisplayTextBox.Text.Length == 1)
                DisplayTextBox.Text = "0";
            else if (DisplayTextBox.Text != "0" && DisplayTextBox.Text.Length > 0)
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Substring(0, DisplayTextBox.Text.Length - 1);
            }
        }
        private void ClearEntryClicked(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "";
        }
        private void ClearClicked(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "0";
            leftOperand = 0;
            rightOperand = 0;
        }
        private void AboutClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Simple Calcuator @ 2021 Parmajiat Foundation", "Calculator", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
