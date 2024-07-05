using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginControls
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty dependencyProperty = DependencyProperty.Register("MyEmail", typeof(string), typeof(Login), new PropertyMetadata(""));
        public String MyEmail
        {
            get { return (string)GetValue(dependencyProperty); }
            set { SetValue(dependencyProperty, value); }
        }

        private void textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "Password" || t.Text == "emailaddress")
            {
                label.Visibility =Visibility;
                label.Content = t.Text;
                FormattedText formattedText = new FormattedText(
                   t.Text,
                   System.Globalization.CultureInfo.CurrentCulture,
                   FlowDirection.LeftToRight,
                   new Typeface(label.FontFamily, label.FontStyle, label.FontWeight, label.FontStretch),
                   label.FontSize,
                   Brushes.Black,
                   VisualTreeHelper.GetDpi(label).PixelsPerDip
                   );
                int width = (int)formattedText.WidthIncludingTrailingWhitespace;
                label.Width = width+10;
                textbox.Text = "";
            }
        }
        //directly binding use binding myemail,relativesource ancestor=usercontrol
        //private static void OnChangeProperty(DependencyObject d,DependencyPropertyChangedEventArgs e)
        //{
        //    Login l = d as Login;
        //    if(l!=null)
        //    {
        //        string s = e.NewValue as string;
        //        l.TextChange(s);
        //    }
        //}

        //private void TextChange(string s)
        //{
        //    textbox.Text = s;
        //}
    }
}
