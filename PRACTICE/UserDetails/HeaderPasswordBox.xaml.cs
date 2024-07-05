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

namespace UserDetails
{
    /// <summary>
    /// Interaction logic for HeaderPasswordBox.xaml
    /// </summary>
    public partial class HeaderPasswordBox : UserControl
    {
        public HeaderPasswordBox()
        {
            InitializeComponent();
            
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(" Header", typeof(string), typeof(HeaderPasswordBox), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        //private bool internalVariable = true;

        //public string PasswordText
        //{
        //    get { return (string)GetValue(PasswordTextProperty); }
        //    set
        //    {
        //        SetValue(PasswordTextProperty, value);
        //        //if (value == "" && !internalVariable)
        //        //{
        //        //    passwordBox.PasswordChanged -= OnPasswordBoxPasswordChanged;
        //        //    passwordBox.Password = "";
        //        //    passwordBox.PasswordChanged += OnPasswordBoxPasswordChanged;
        //        //    return;
        //        //}
        //        //internalVariable = false;
        //    }
        //}

        //public static readonly DependencyProperty PasswordTextProperty =
        //    DependencyProperty.Register("PasswordText", typeof(string), typeof(HeaderPasswordBox), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public void ClearPassword()
        {
            passwordBox.Clear();
            Passworddemo = "";
        }

        public string Passworddemo
        {
            get { return (string)GetValue(PasswordDemoProperty); }
            set { SetValue(PasswordDemoProperty, value); }
        }
        
        public static readonly DependencyProperty PasswordDemoProperty =
            DependencyProperty.Register("passworddemo", typeof(string), typeof(HeaderPasswordBox), new FrameworkPropertyMetadata(default(string),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        

        //private void OnPasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    internalVariable = true;
        //    passworddemo = passwordBox.Password;
        //    //MessageBox.Show(PasswordText);
        //}

        //protected override void OnVisualParentChanged(DependencyObject oldParent)
        //{
        //    base.OnVisualParentChanged(oldParent);
        //    passwordBox.Password = "";
        //}
    }
    public static class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
            typeof(PasswordHelper));


        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }
}
