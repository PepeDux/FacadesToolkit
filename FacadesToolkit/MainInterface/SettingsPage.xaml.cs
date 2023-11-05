using FacadesToolkit.Properties;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace FacadesToolkit
{
    public partial class SettingsPage : Page
    {
        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);

        public SettingsPage()
        {
            InitializeComponent();

            //Передача настроек чекбоксам
            CheckTopClippingWindow.IsChecked = (bool)Settings.Default["TopClippingWindow"];
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTopClippingWindow.IsChecked == true)
            {
                Settings.Default["TopClippingWindow"] = true;
            }
            else
            {
                Settings.Default["TopClippingWindow"] = false;
            }

            //Сохранение настроек
            Settings.Default.Save();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;

            switch (pressed.Content)
            {
                case "Точка":
                    DataBank.separator = 1;
                    break;
                case "Запятая":
                    DataBank.separator = 2;
                    break;
                default:
                    DataBank.separator = 1;
                    break;
            }
        }
    }
}
