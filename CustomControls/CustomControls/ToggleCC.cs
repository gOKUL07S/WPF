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

namespace CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls;assembly=CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ToggleCC/>
    ///
    /// </summary>
    public class ToggleCC : Control
    {
        static ToggleCC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleCC), new FrameworkPropertyMetadata(typeof(ToggleCC)));
        }

        public static readonly DependencyProperty BackgroundColorProperty = 
            DependencyProperty.Register(
                "BackColor",
                typeof(SolidColorBrush),
                typeof(ToggleCC),
                new PropertyMetadata(Brushes.Red));

        public Brush BackColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        private void ToggleBackgorundColor()
        {
            //if (BackColor == Brushes.Green)
            //    BackColor = Brushes.Red;
            //else
            //    BackColor = Brushes.Green;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_Border") is Border border)
            {
                border.MouseLeftButtonDown += (s, e) => ToggleBackgorundColor();
            }
        }
    }
}
