using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using ForJob.Service.Services;
using System.IO.IsolatedStorage;
using ForJob.Service.DTOs.Users;
using System.Collections.Generic;

namespace ForJob.App.Windows.Auth
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService userService;

        public LoginWindow()
        {
            this.userService = new UserService();

            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            //create a stream reader object to read content from the created isolated location
            StreamReader srReader = new StreamReader(new IsolatedStorageFileStream("isotest", FileMode.OpenOrCreate, isolatedStorage));
            //Open the isolated storage
            List<string> strings = new();
            if (srReader == null)
            {
                MessageBox.Show("No Data stored!");
            }
            else
            {
                //MessageBox.Show(stateReader.ReadLine());
                while (!srReader.EndOfStream)
                {
                    string item = srReader.ReadLine();
                    strings.Add(item);
                }

            }
            //close reader
            srReader.Close();

            InitializeComponent();
            if (strings.Count > 0)
            {
                tbUserName.Text = strings[0];
                pwbPassword.Password = strings[1];
                Checkbox.IsChecked = true;
            }
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text) && string.IsNullOrEmpty(pwbPassword.Password))
            {
                MessageBox.Show("Password and User name are required.");
            }

            var userLoginDto = new UserLoginDto
            {
                UserName = tbUserName.Text,
                Password = pwbPassword.Password
            };

            try
            {
                var result = await userService.LoginAsync(userLoginDto);
                if (result is not null)
                {
                    Application.Current.Properties["UserId"] = result.Id;
                    MainWindow main = new();
                    main.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Checkbox.IsChecked.Value)
            {
                App.Current.Properties[0] = tbUserName.Text;
                App.Current.Properties[1] = pwbPassword.Password;
                App.Current.Properties[2] = Checkbox.IsChecked.Value;
                IsolatedStorageFile isolatedStorage1 = IsolatedStorageFile.GetUserStoreForAssembly();
                //create a stream writer object to write content in the location
                StreamWriter srWriter = new StreamWriter(new IsolatedStorageFileStream("isotest", FileMode.Create, isolatedStorage1));
                //check the Application property collection contains any values.
                if (App.Current.Properties[0] != null)
                {
                    //wriet to the isolated storage created in the above code section.
                    srWriter.WriteLine(App.Current.Properties[0].ToString());
                    srWriter.WriteLine(App.Current.Properties[1].ToString());
                    srWriter.WriteLine(App.Current.Properties[2].ToString());
                }

                srWriter.Flush();
                srWriter.Close();
            }
            else
            {
                IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
                isolatedStorage.DeleteFile("isotest");
            }
        }

        private void ShowPasswordToggle_Checked(object sender, RoutedEventArgs e)
        {
            pwbPassword.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
            tbPassword.Text = pwbPassword.Password;
        }

        private void ShowPasswordToggle_Unchecked(object sender, RoutedEventArgs e)
        {

            pwbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
            pwbPassword.Password = tbPassword.Text;
            tbPassword.Text = pwbPassword.Password;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();

            this.Close();
        }
    }
}
