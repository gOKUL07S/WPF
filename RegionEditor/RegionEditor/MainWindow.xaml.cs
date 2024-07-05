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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegionEditor
{
    public partial class MainWindow : Window
    {
        //Rect Variables
        private bool isDragging = false;
        private Point startingPoint;

        //Poly Variables
        private List<Point> points = new List<Point>();
        private Polygon currentPolygon;
        private Line previewLine;

        public MainWindow()
        {
            InitializeComponent();

            ImageGrid.MouseDown += ImageGridMouseDown;
            ImageGrid.MouseUp += ImageGridMouseUp;
            ImageGrid.MouseMove += ImageGridMouseMove;
        }

        private void ResetPolygon()
        {
            OverlayCanvas.Children.Remove(previewLine);
            OverlayCanvas.Children.Remove(currentPolygon);

            previewLine = null;
            currentPolygon = null;

            points.Clear();
        }

        private void ImageGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ShapeBox.Text == "Rectangle" && ResizableSelectionRectangle.Visibility == Visibility.Hidden)
            {
                isDragging = true;
                startingPoint = e.GetPosition(OverlayCanvas);

                Canvas.SetLeft(ResizableSelectionRectangle, startingPoint.X);
                Canvas.SetTop(ResizableSelectionRectangle, startingPoint.Y);

                ResizableSelectionRectangle.Width = ResizableSelectionRectangle.Height = 0;
                ResizableSelectionRectangle.Visibility = Visibility.Visible;
            }
            else if (ShapeBox.Text == "Circle")
            {
            }
        }

        private void ImageGridMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(OverlayCanvas);

                double x = Math.Min(currentPoint.X, startingPoint.X);
                double y = Math.Min(currentPoint.Y, startingPoint.Y);
                double width = Math.Abs(currentPoint.X - startingPoint.X);
                double height = Math.Abs(currentPoint.Y - startingPoint.Y);

                Canvas.SetLeft(ResizableSelectionRectangle, x);
                Canvas.SetTop(ResizableSelectionRectangle, y);
                ResizableSelectionRectangle.Width = width;
                ResizableSelectionRectangle.Height = height;
            }
        }

        private void ImageGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void LoadButtonMouseDown(object sender, RoutedEventArgs e)
        {
            ResetBounds();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            bool? result = openFileDialog.ShowDialog();


            if (result == true)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                ImageViewer.Source = bitmapImage;
            }
        }

        private void CropButtonMouseDown(object sender, RoutedEventArgs e)
        {
            Image image = ImageGrid.Children.OfType<Image>().FirstOrDefault();
            if (image == null || image.Source == null)
                return;


            if (!(image.Source is BitmapSource bitmapSource))
                return;

            if (ShapeBox.Text == "Rectangle")
            {
                double x = Canvas.GetLeft(ResizableSelectionRectangle);
                double y = Canvas.GetTop(ResizableSelectionRectangle);
                double width = ResizableSelectionRectangle.Width;
                double height = ResizableSelectionRectangle.Height;

                double imageX = x * (bitmapSource.PixelWidth / image.ActualWidth);
                double imageY = y * (bitmapSource.PixelHeight / image.ActualHeight);
                double imageWidth = width * (bitmapSource.PixelWidth / image.ActualWidth);
                double imageHeight = height * (bitmapSource.PixelHeight / image.ActualHeight);

                if (imageX < 0 || imageY < 0 || imageX + imageWidth > bitmapSource.PixelWidth || imageY + imageHeight > bitmapSource.PixelHeight)
                {
                    MessageBox.Show("Selection is out of bounds of the image");
                    ResetBounds();
                    return;
                }

                Int32Rect cropRect = new Int32Rect((int)imageX, (int)imageY, (int)imageWidth, (int)imageHeight);
                CroppedBitmap croppedBitmap = new CroppedBitmap(bitmapSource, cropRect);

                SaveImage(croppedBitmap);

                ResetBounds();
            }
            else
            {
                CapturePolygonAreaAsImage(currentPolygon);
            }
        }

        private void CapturePolygonAreaAsImage(Polygon polygon)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(polygon);

            RenderTargetBitmap renderTarget = new RenderTargetBitmap(
                (int)bounds.Width, (int)bounds.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawRectangle(Brushes.White, null, new Rect(new Size(bounds.Width, bounds.Height)));
                drawingContext.PushTransform(new TranslateTransform(-bounds.X, -bounds.Y));
                drawingContext.DrawGeometry(polygon.Fill, new Pen(polygon.Stroke, polygon.StrokeThickness), polygon.RenderedGeometry);
            }

            renderTarget.Render(ImageViewer);

            SaveImage(renderTarget);
        }

        private void SaveImage(BitmapSource croppedBitmap)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Files|*.png|JPEG Files|*.jpg|Bitmap Files|*.bmp|All Files|*.*",
                DefaultExt = System.IO.Path.GetExtension(ImageViewer.Source.ToString()),
                Title = "Save Cropped Image"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                BitmapEncoder encoder = null;
                string extension = System.IO.Path.GetExtension(ImageViewer.Source.ToString()).ToLower();

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

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(fileStream);
                }

                MessageBox.Show("Image saved successfully!", "Save Image", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ResizeButtonClick(object sender, RoutedEventArgs e)
        {
            ResetBounds();
            Resize resize = new Resize(ImageViewer, ImageViewer.Source.Width, ImageViewer.Source.Height);
            resize.OnClose += (obj, evnt) => { Show(); };
            resize.Show();
            Hide();
        }

        private void ResetBounds()
        {
            ResizableSelectionRectangle.Width = ResizableSelectionRectangle.Height = 0;
            ResizableSelectionRectangle.Visibility = Visibility.Hidden;
        }

        private void ShapeBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetBounds();
            ResetPolygon();
            //CustomCrop.Completed = ShapeBox.Text == "Polygon" ? false : true;
        }

        private RenderTargetBitmap CaptureCanvasToBitmap(Canvas canvas)
        {
            double dpi = 96; // Standard screen DPI
            var size = new Size(canvas.ActualWidth, canvas.ActualHeight);

            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            var renderBitmap = new RenderTargetBitmap(
                (int)canvas.ActualWidth,
                (int)canvas.ActualHeight,
                dpi,
                dpi,
                PixelFormats.Pbgra32);

            renderBitmap.Render(canvas);
            return renderBitmap;
        }

        private BitmapSource CropToPolygon(RenderTargetBitmap source, List<Point> polygonPoints)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;

            byte[] pixelData = new byte[height * stride];
            source.CopyPixels(pixelData, stride, 0);

            WriteableBitmap writeableBitmap = new WriteableBitmap(width, height, source.DpiX, source.DpiY, source.Format, null);

            Int32Rect cropRect = new Int32Rect(0, 0, width, height);

            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(polygonPoints[0], true, true);
                ctx.PolyLineTo(polygonPoints.Skip(1).ToList(), true, true);
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Point point = new Point(x, y);
                    if (geometry.FillContains(point))
                    {
                        int sourceIndex = (y * stride) + (x * 4);

                        writeableBitmap.WritePixels(new Int32Rect(x, y, 1, 1), pixelData, stride, sourceIndex);
                    }
                }
            }

            return writeableBitmap;
        }

        private void SaveBitmap(BitmapSource bitmap, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(fileStream);
            }
        }
    }
}
