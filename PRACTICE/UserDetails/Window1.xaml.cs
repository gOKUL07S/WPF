﻿using System;
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
using System.Windows.Shapes;

namespace UserDetails
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            pwddemo = "asdad";
        }

        public string pwddemo
        {
            get { return (string)GetValue(pwddemoProperty); }
            set { SetValue(pwddemoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for pwddemo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty pwddemoProperty =
            DependencyProperty.Register("pwddemo", typeof(string), typeof(Window1), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
    //public static class PasswordHelper
    //{
    //    public static readonly DependencyProperty PasswordProperty =
    //        DependencyProperty.RegisterAttached("Password",
    //        typeof(string), typeof(PasswordHelper),
    //        new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

    //    public static readonly DependencyProperty AttachProperty =
    //        DependencyProperty.RegisterAttached("Attach",
    //        typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

    //    private static readonly DependencyProperty IsUpdatingProperty =
    //        DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
    //        typeof(PasswordHelper));
        

    //    public static void SetAttach(DependencyObject dp, bool value)
    //    {
    //        dp.SetValue(AttachProperty, value);
    //    }

    //    public static bool GetAttach(DependencyObject dp)
    //    {
    //        return (bool)dp.GetValue(AttachProperty);
    //    }

    //    public static string GetPassword(DependencyObject dp)
    //    {
    //        return (string)dp.GetValue(PasswordProperty);
    //    }

    //    public static void SetPassword(DependencyObject dp, string value)
    //    {
    //        dp.SetValue(PasswordProperty, value);
    //    }

    //    private static bool GetIsUpdating(DependencyObject dp)
    //    {
    //        return (bool)dp.GetValue(IsUpdatingProperty);
    //    }

    //    private static void SetIsUpdating(DependencyObject dp, bool value)
    //    {
    //        dp.SetValue(IsUpdatingProperty, value);
    //    }

    //    private static void OnPasswordPropertyChanged(DependencyObject sender,
    //        DependencyPropertyChangedEventArgs e)
    //    {
    //        PasswordBox passwordBox = sender as PasswordBox;
    //        passwordBox.PasswordChanged -= PasswordChanged;

    //        if (!(bool)GetIsUpdating(passwordBox))
    //        {
    //            passwordBox.Password = (string)e.NewValue;
    //        }
    //        passwordBox.PasswordChanged += PasswordChanged;
    //    }

    //    private static void Attach(DependencyObject sender,
    //        DependencyPropertyChangedEventArgs e)
    //    {
    //        PasswordBox passwordBox = sender as PasswordBox;

    //        if (passwordBox == null)
    //            return;

    //        if ((bool)e.OldValue)
    //        {
    //            passwordBox.PasswordChanged -= PasswordChanged;
    //        }

    //        if ((bool)e.NewValue)
    //        {
    //            passwordBox.PasswordChanged += PasswordChanged;
    //        }
    //    }

    //    private static void PasswordChanged(object sender, RoutedEventArgs e)
    //    {
    //        PasswordBox passwordBox = sender as PasswordBox;
    //        SetIsUpdating(passwordBox, true);
    //        SetPassword(passwordBox, passwordBox.Password);
    //        SetIsUpdating(passwordBox, false);
    //    }
    //}
}
