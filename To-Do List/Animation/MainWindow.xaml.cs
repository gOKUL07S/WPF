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
using System.Windows.Media.Animation;

namespace Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string StudentName { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
            StudentName = "Sharuk";
        }

        public class UserViewModel : DependencyObject
        {
            public string UserName
            {
                get { return (string)GetValue(UserNameProperty); }
                set { SetValue(UserNameProperty, value); }
            }

            public static readonly DependencyProperty UserNameProperty =
                DependencyProperty.Register("UserName", typeof(string), typeof(UserViewModel), new PropertyMetadata(""));

            public UserViewModel()
            {
                UserName = "John Doe";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation
            {
                From = 0,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(10)),
                AutoReverse = false,
                RepeatBehavior = RepeatBehavior.Forever,
            };
            button1.BeginAnimation(Button.WidthProperty, doubleAnimation);

            ColorAnimation colorAnimation = new ColorAnimation
            {
                From = Colors.Red,
                To = Colors.Blue,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                //AutoReverse = true,
                //RepeatBehavior = RepeatBehavior.Forever
            };

            // Create a SolidColorBrush to apply the animation to
            SolidColorBrush buttonBrush = new SolidColorBrush(Colors.Red);
            animatedButton.Background = buttonBrush;

            // Start the color animation
            buttonBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            //PointAnimation pointAnimation = new PointAnimation
            //{
            //    From = new Point(50, 50),
            //    To = new Point(300, 50),
            //    Duration = new Duration(TimeSpan.FromSeconds(2)),
            //    AutoReverse = true,
            //    RepeatBehavior = RepeatBehavior.Forever,
            //};
            //animatedEllipse.BeginAnimation(EllipseGeometry.CenterProperty, pointAnimation); //FOR ELLIPSE

            StringAnimationUsingKeyFrames stringAnimation = new StringAnimationUsingKeyFrames
            {
                Duration = TimeSpan.FromSeconds(100),
                RepeatBehavior = RepeatBehavior.Forever
            };

            stringAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("Hello", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));
            stringAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("World", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))));
            stringAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("Welcome", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
            stringAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("To", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4))));
            stringAnimation.KeyFrames.Add(new DiscreteStringKeyFrame("WPF!", KeyTime.FromTimeSpan(TimeSpan.FromSeconds(5))));

            animatedLabel.BeginAnimation(Label.ContentProperty, stringAnimation);
        }
    }
}
