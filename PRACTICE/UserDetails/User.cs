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
using System.Windows.Shapes;

namespace UserDetails
{
    public partial class Main : Window
    {
        
        private ObservableCollection<User> Users { get; set; }

        private User user;

        private bool create;

        public Main()
        {
            InitializeComponent();
            createUserBorder.Visibility = Visibility.Hidden;
            Users = new ObservableCollection<User>
            {
                new User() { UserName = "Admin", Password = "Admin", CreatedTime = DateTime.Now, LastUpdated = DateTime.Now, PasswordStrength = 0 }
            };
        }
        
        private void OnLoginBtnClicked(object sender, RoutedEventArgs e)
        {
            var tempUser = UserExists(usernameTb.TextBoxText);
            if(tempUser != null)
            {
                if(tempUser.Password == passwordTb.Passworddemo)
                {
                    loginSuccessfulBorder.Visibility = Visibility.Visible;
                    loginBorder.Visibility = Visibility.Hidden;
                }
            }
        }

        private User UserExists(string username)
        {
            return Users.First(i => i.UserName == username);
        }
        
        private void OnSignUpOrResetBtnClicked(object sender, RoutedEventArgs e)
        {
            if(create)
            {
                if(CreateNewPasswordTb.Passworddemo == CreateConfirmPasswordTb.Passworddemo)
                {
                    if(UserExists(CreateUsernameTb.TextBoxText)==null)
                    {
                        Users.Add(new User() { UserName = CreateUsernameTb.TextBoxText, CreatedTime = DateTime.Now, LastUpdated = DateTime.Now, Password = CreateNewPasswordTb.Passworddemo });
                    }
                }
            }
            else
            {

            }
        }

        private void OnCreateUserLblClicked(object sender, MouseButtonEventArgs e)
        {
            CreateUsernameTb.TextBoxText = "";
            CreateNewPasswordTb.ClearPassword();
            CreateConfirmPasswordTb.ClearPassword();
            if(sender is Label lbl)
            {
                if(lbl.Content.ToString() == "Create User")
                {
                    create = true;
                }
                else
                {
                    create = false;
                }
            }
        }

        private void OnSignInLblClicked(object sender, MouseButtonEventArgs e)
        {
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
            
        }
    }
}
