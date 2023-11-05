using FacadesToolkit.Properties;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FacadesToolkit.AddIns.Cutting
{
    public partial class CuttingMenu : Window
    {
        public CuttingMenu()
        {
            InitializeComponent();



            this.Topmost = (bool)Settings.Default["TopClippingWindow"];
        }


        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            if (IndentTextBox.Text == "")
            {
                DataBank.indent = 0;
            }
            else
            {
                DataBank.indent = Convert.ToInt16(IndentTextBox.Text);
            }

            DataBank.cutType = (int)DigitSlider.Value;


            //Закрытие окна если настройка не применена
            if ((bool)Settings.Default["TopClippingWindow"] == false)
            {
                this.Close();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Type.Content = ((int)DigitSlider.Value);
        }

        private void StackPanel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
