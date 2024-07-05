using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegionEditor
{
    /// <summary>
    /// Interaction logic for Resize.xaml
    /// </summary>
    public partial class Resize : Window
    {
        public event EventHandler OnClose;

        public Resize(Image ImageToEdit , double orgWidth , double orgHeight)
        {
            InitializeComponent();

            ImageBorder.Width = orgWidth;
            ImageBorder.Height = orgHeight;
            Canvas.SetLeft(ResizeThumb, Canvas.GetLeft(ImageBorder) + ImageBorder.Width - ResizeThumb.Width);
            Canvas.SetTop(ResizeThumb, Canvas.GetTop(ImageBorder) + ImageBorder.Height - ResizeThumb.Height);

            ResizableImage.Source = ImageToEdit.Source;
        }

        private void ResizeThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = ImageBorder.Width + e.HorizontalChange;
            double newHeight = ImageBorder.Height + e.VerticalChange;

            if (newWidth > 50 && newWidth < TopCanvas.ActualWidth - TopCanvas.Margin.Right)
                ImageBorder.Width = newWidth;

            if (newHeight > 50 && newHeight < TopCanvas.ActualHeight - TopCanvas.Margin.Bottom)
                ImageBorder.Height = newHeight;

            Canvas.SetLeft(ResizeThumb, Canvas.GetLeft(ImageBorder) + ImageBorder.Width - ResizeThumb.Width);
            Canvas.SetTop(ResizeThumb, Canvas.GetTop(ImageBorder) + ImageBorder.Height - ResizeThumb.Height);
        }

        protected override void OnClosed(EventArgs e)
        {
            OnClose?.Invoke(this, e);
            base.OnClosed(e);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            double imageWidth = ImageBorder.ActualWidth;
            double imageHeight = ImageBorder.ActualHeight;

            double d = ResizableImage.ActualWidth;

            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)imageWidth,
                                                                    (int)imageHeight,
                                                                    96, 96, PixelFormats.Pbgra32);
            renderBitmap.Render(ResizableImage);

            CroppedBitmap croppedBitmap = new CroppedBitmap(renderBitmap,
                new Int32Rect(0, 0, (int)imageWidth, (int)imageHeight));

            BitmapEncoder encoder = null;
            string extension = System.IO.Path.GetExtension(ResizableImage.Source.ToString()).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    encoder = new JpegBitmapEncoder();
                    break;
                case ".bmp":
                    encoder = new BmpBitmapEncoder();
                    break;
                case ".png":
                default:
                    encoder = new PngBitmapEncoder();
                    break;
            }

            encoder.Frames.Add(BitmapFrame.Create(croppedBitmap));

            SaveImage(encoder);
        }

        private void SaveImage(BitmapEncoder encoder)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PNG Files (*.png)|*.png",
                DefaultExt = System.IO.Path.GetExtension(ResizableImage.Source.ToString())
            };

            if (saveDialog.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(saveDialog.FileName, FileMode.Create))
                {
                    encoder.Save(stream);
                }
                MessageBox.Show("Image saved successfully!");
            }
        }
    }
}
