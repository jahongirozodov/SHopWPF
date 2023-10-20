using AutoMapper;
using ForJob.App.Components.Shops;
using ForJob.App.Windows.Categories;
using ForJob.Service.Interfaces;
using ForJob.Service.Services;
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
using System.Xml;

namespace ForJob.App.Pages
{
    /// <summary>
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        private readonly IShopService shopService;
        public ShopPage()
        {
            this.shopService = new ShopService();
            
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShopCreationWindow creationWindow = new();
            creationWindow.ShowDialog();
            if(ShopCreationWindow.IsCreated)
                Refresh_Page();
        }

        public void Refresh_Page()
        {
            wrpShops.Children.Clear();
            string userId = Application.Current.Properties["UserId"].ToString();
            var shops = shopService.GetAll().Where(x=> x.UserId.Equals(long.Parse(userId)));
            foreach (var shop in shops)
            {
                var shopsViewUserControl = new ShopsViewUserControl();
                shopsViewUserControl.SetData(shop);
                wrpShops.Children.Add(shopsViewUserControl);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh_Page();
        }
    }
}
