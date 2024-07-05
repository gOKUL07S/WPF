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

namespace Dependency
{
    /// <summary>
    /// Interaction logic for dpUserControl.xaml
    /// </summary>
    public partial class dpUserControl : UserControl
    {
        public dpUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MyPropertyProperty =
         DependencyProperty.Register("MyProperty", typeof(string), typeof(dpUserControl), new PropertyMetadata(string.Empty,OnMyPropertyChanged));

        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            dpUserControl control = d as dpUserControl;
            if(control!=null)
            {
                string s = e.NewValue as string;
                control.OnMyPropertyTextChanged(s);
            }

        }

        private void OnMyPropertyTextChanged(string newText)
        {
            Textbox.Text = newText;
        }
    }
}
