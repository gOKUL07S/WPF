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
using UserControlTest;

namespace ImageViewer2
{
    /// <summary>
    /// Interaction logic for CroppedImageViewer.xaml
    /// </summary>
    public partial class CroppedImageViewer : UserControl
    {
        //public CroppedImageViewer(int id , Rectangle rect)
        public CroppedImageViewer(int id , ResizableRectangle rect)
        {
            InitializeComponent();
            Id = id;
            Rect = rect;
        }

       

        public int Id { get; set; }

        //public Rectangle Rect { get; set; }
        public ResizableRectangle Rect { get; set; }

        public BitmapSource ImageSource
        {
            get { return (BitmapSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        
        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(BitmapSource), typeof(CroppedImageViewer), new FrameworkPropertyMetadata(default(BitmapSource), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public event EventHandler DeleteClicked;

        private void OnDeleteLblMouseDown(object sender, MouseButtonEventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
