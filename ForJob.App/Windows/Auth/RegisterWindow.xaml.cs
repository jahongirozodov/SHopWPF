using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using ForJob.Service.Services;
using ForJob.Service.DTOs.Users;
using ForJob.Service.Interfaces;
using ForJob.Service.Helpers.Validations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForJob.App.Windows.Auth
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService userService;
        public RegisterWindow()
        {
            InitializeComponent();
            this.userService = new UserService();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
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

        private void ShowConfirmPasswordToggle_Checked(object sender, RoutedEventArgs e)
        {
            pwbConfirmPassword.Visibility = Visibility.Collapsed;
            tbConfirmPassword.Visibility = Visibility.Visible;
            tbConfirmPassword.Text = pwbConfirmPassword.Password;
        }

        private void ShowConfirmPasswordToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            pwbConfirmPassword.Visibility = Visibility.Visible;
            tbConfirmPassword.Visibility = Visibility.Collapsed;
            pwbConfirmPassword.Password = tbConfirmPassword.Text;
            tbConfirmPassword.Text = pwbConfirmPassword.Password;
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (pwbPassword.Password != pwbConfirmPassword.Password)
            {
                System.Windows.Forms.MessageBox.Show("Password and Confirm password is not equal!", "",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error);
                return;
            }

            var userRegisterDto = new UserRegisterDto
            {
                Firstname = tbFirstName.Text,
                Lastname = tbLastName.Text,
                Username = tbUserName.Text,
                Password = pwbPassword.Password
            };
            var validator = new UserCreationDtoValidator();
            var validationResult = validator.Validate(userRegisterDto);

            if (!validationResult.IsValid)
            {
                errorPassword.Content = validationResult.Errors.FirstOrDefault();
                errorConfirmPassword.Content = validationResult.Errors.FirstOrDefault();
            }
            else
            {
                try
                {
                    var result = await userService.RegisterAsync(userRegisterDto);
                    if (result is not null)
                    {
                        System.Windows.Application.Current.Properties["UserId"] = result.Id;
                        var mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();

            this.Close();
        }
    }
}
