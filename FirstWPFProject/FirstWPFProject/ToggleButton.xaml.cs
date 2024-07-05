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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWPFProject
{
    /// <summary>
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        public ToggleButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(ToggleButton),
                new PropertyMetadata(Colors.Red, OnColorChanged));//Write event if required

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        private void OnCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Color == Colors.Red)
            {
                Color = Colors.Green;
            }
            else
            {
                Color = Colors.Red;
            }
            
        }
    }
}
