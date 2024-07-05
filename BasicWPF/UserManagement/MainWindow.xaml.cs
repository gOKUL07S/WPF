using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UserManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            createUserBorder.Visibility = Visibility.Hidden;
        }

        ViewWindow viewDetails;

        private void OnLoginBtnClicked(object sender, RoutedEventArgs e)
        {
            var tempUser = UserManager.GetUser(usernameTb.TextBoxText);
            loginSuccessfulBorder.Visibility = Visibility.Visible;
            loginBorder.Visibility = Visibility.Hidden;

        }

        private void OnSignUpOrResetBtnClicked(object sender, RoutedEventArgs e)
        {
            if (UserManager.create)
            {
                UserManager.CreateUser(CreateUsernameTb.TextBoxText, CreateNewPasswordTb.Passworddemo, CreateConfirmPasswordTb.Passworddemo);
            }
            else
            {
                UserManager.ChangePassword(CreateUsernameTb.TextBoxText, CreateNewPasswordTb.Passworddemo, CreateConfirmPasswordTb.Passworddemo);
            }
            createUserBorder.Visibility = Visibility.Hidden;
            loginBorder.Visibility = Visibility.Visible;
        }

        private void OnCreateUserLblClicked(object sender, MouseButtonEventArgs e)
        {
            CreateUsernameTb.TextBoxText = "";
            CreateNewPasswordTb.ClearPassword();
            CreateConfirmPasswordTb.ClearPassword();
            loginBorder.Visibility = Visibility.Hidden;
            createUserBorder.Visibility = Visibility.Visible;
            headerLbl2.Text = "Sign up";
            UserManager.create = true;
        }

        private void OnForgetLblClicked(object sender, MouseButtonEventArgs e)
        {
            CreateUsernameTb.TextBoxText = "";
            CreateNewPasswordTb.ClearPassword();
            CreateConfirmPasswordTb.ClearPassword();
            loginBorder.Visibility = Visibility.Hidden;
            createUserBorder.Visibility = Visibility.Visible;
            headerLbl2.Text = "Reset Password";
            UserManager.create = false;
        }

        private void OnSignInLblClicked(object sender, MouseButtonEventArgs e)
        {
            createUserBorder.Visibility = Visibility.Hidden;
            loginBorder.Visibility = Visibility.Visible;
            usernameTb.TextBoxText = "";
            passwordTb.ClearPassword();
        }

        private void OnBackBtnClicked(object sender, RoutedEventArgs e)
        {
            loginBorder.Visibility = Visibility.Visible;
            loginSuccessfulBorder.Visibility = Visibility.Hidden;
            usernameTb.TextBoxText = "";
            passwordTb.ClearPassword();
        }
        
        private void OnContinueBtnClicked(object sender, RoutedEventArgs e)
        {
            viewDetails = new ViewWindow();
            viewDetails.ShowDialog();
        }
    }
}
