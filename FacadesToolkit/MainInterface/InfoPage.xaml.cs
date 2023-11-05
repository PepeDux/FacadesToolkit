using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FacadesToolkit
{
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();

            DBQuery dBQuery = new DBQuery();

            //Обновление всех данных в БД
            dBQuery.CheckAll();
            dBQuery.ProductUpdateAll();

            Version.Text = "Версия: " + Properties.Settings.Default["Version"].ToString();

        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupportPage());
        }

        private void Cutting_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу информации о продукте
            NavigationService.Navigate(new ProductInfoPage("Cutting"));
        }

        private void Coordinater_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу информации о продукте
            NavigationService.Navigate(new ProductInfoPage("Coordinater"));
        }

        private void SFLIB_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу информации о продукте
            NavigationService.Navigate(new ProductInfoPage("SFLIB"));
        }
    }
}
