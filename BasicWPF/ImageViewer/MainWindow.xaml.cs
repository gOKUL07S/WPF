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

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        BitmapImage Bitmap = new BitmapImage();

        private bool IsMouseDown = false;

        Rectangle rect;

        private void OnCanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
            Console.WriteLine(e.GetPosition(img));
            xPos.Text = e.GetPosition(imageCanvas).X.ToString();
            yPos.Text = e.GetPosition(imageCanvas).Y.ToString();
            //xPos.Text = e.GetPosition(img).X.ToString();
            //yPos.Text = e.GetPosition(img).Y.ToString();
            rect = new Rectangle() { Stroke = Brushes.White, StrokeThickness = 3 };
            
            //imageCanvas.Children.Add(rect);
        }

        private void OnCanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(e.GetPosition(imageCanvas));
            IsMouseDown = false;
        }

        private void OnCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if(IsMouseDown)
            {
                x2Pos.Text = e.GetPosition(imageCanvas).X.ToString();
                y2Pos.Text = e.GetPosition(imageCanvas).Y.ToString();
                //x2Pos.Text = e.GetPosition(img).X.ToString();
                //y2Pos.Text = e.GetPosition(img).Y.ToString();
            }
            //rect.Height = Math.Abs((int)(xPos.Text)- (int)(x2Pos.Text))
            
        }
    }
}
