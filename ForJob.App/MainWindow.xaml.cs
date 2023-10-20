using ForJob.App.Pages;
using ForJob.App.Windows.Auth;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ForJob.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuShops_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShopPage shopPage = new();
            this.Navigator.Content = shopPage;
        }

        private void LogOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }
    }
}
