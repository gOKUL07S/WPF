using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(croppedImagePanel.Height);
            DataContext = this;
        }
        BitmapImage Bitmap = new BitmapImage();
        
        public bool IsRegionSelected
        {
            get { return (bool)GetValue(IsRegionSelectedProperty); }
            set { SetValue(IsRegionSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsRegionSelectedProperty =
            DependencyProperty.Register("IsRegionSelected", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        private bool IsMouseDown = false;

        int count = 0;

        //Rectangle rectRegion;
        ResizableRectangle resizableRectangle;

        //Rectangle selectedRectangle;
        ResizableRectangle selectedRectangle;

        private Point point1, point2, rectPoint1, rectPoint2;

        //List<Rectangle> sortedRectangles = new List<Rectangle>();
        List<ResizableRectangle> sortedRectangles = new List<ResizableRectangle>();

        private void OnImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CropModeCheckbox.IsChecked == true && selectRegion.IsChecked == false)
            {
                Console.WriteLine(croppedImagePanel.Height);
                Console.WriteLine(img.Height + " " + img.Width);
                Console.WriteLine(imageCanvas.Height + " " + imageCanvas.Width);
                if (e.GetPosition(img).X < 0 || e.GetPosition(img).X > img.ActualWidth
                     || e.GetPosition(img).Y < 0 || e.GetPosition(img).Y > img.ActualHeight) return;
                IsMouseDown = true;
                Console.WriteLine(e.GetPosition(img));
                Console.WriteLine(e.GetPosition(imageCanvas));
                X.Text = e.GetPosition(img).X.ToString();
                Y.Text = e.GetPosition(img).Y.ToString();
                point1 = new Point(e.GetPosition(img).X, e.GetPosition(img).Y);
                rectPoint1 = new Point(e.GetPosition(imageCanvas).X, e.GetPosition(imageCanvas).Y);
                //rectRegion = new Rectangle() { Stroke = Brushes.White, StrokeThickness = 1, Height = 10, Width = 10 };
                resizableRectangle = new ResizableRectangle() { Height = 10, Width = 10 };
                resizableRectangle.IsResized += OnResizableRectangleResized;
                //imageCanvas.Children.Add(rectRegion);
                //sortedRectangles.Add(rectRegion);
                //Canvas.SetLeft(rectRegion, rectPoint1.X);
                //Canvas.SetTop(rectRegion, rectPoint1.Y);
                imageCanvas.Children.Add(resizableRectangle);
                sortedRectangles.Add(resizableRectangle);
                Canvas.SetLeft(resizableRectangle, rectPoint1.X);
                Canvas.SetTop(resizableRectangle, rectPoint1.Y);
            }
            else
            {
                //SortRectangles(sortedRectangles);
                SortRectangles(sortedRectangles);
                //foreach (Rectangle rec in sortedRectangles)
                bool isRectRegion = false;
                foreach (ResizableRectangle rec in sortedRectangles)
                {
                    if (PointContainsCheck(rec, e.GetPosition(imageCanvas)))
                    {
                        //foreach (Rectangle rec2 in sortedRectangles)
                        foreach (ResizableRectangle rec2 in sortedRectangles) //this is to remove the resizing thumb , the alternate way is check selectedRectangle !null and make its selected false//
                        {
                            //rec2.Stroke = Brushes.White;
                            //rec2.StrokeThickness = 2;
                            rec2.IsSelected = false;
                        }
                        //rec.Stroke = Brushes.Green;
                        selectedRectangle = rec;
                        selectedRectangle.IsSelected = true;
                        isRectRegion = true;
                        //GetThumbSetToRectangle(selectedRectangle);
                        IsRegionSelected = true;
                        tempPoint = new Point(Canvas.GetLeft(selectedRectangle), Canvas.GetTop(selectedRectangle));
                        break;
                    }
                }
                if(!isRectRegion && selectedRectangle!= null)
                {
                    selectedRectangle.IsSelected = false;
                    selectedRectangle = null;
                }
            }
        }

        private void OnResizableRectangleResized(object sender, EventArgs e)
        {
            if (selectedRectangle != null && selectedRectangle.IsSelected)
            {
                CropImage((int)Canvas.GetLeft(selectedRectangle), (int)Canvas.GetTop(selectedRectangle)-22, (int)Canvas.GetLeft(selectedRectangle) + (int)selectedRectangle.Width, (int)Canvas.GetTop(selectedRectangle) + (int)selectedRectangle.Height-25, false);
            }
        }

        Point tempPoint;
        private void GetThumbSetToRectangle(Rectangle selectedRectangle)
        {
            Canvas.SetLeft(RightThumb, Canvas.GetLeft(selectedRectangle) + selectedRectangle.Width - 5);
            Canvas.SetTop(RightThumb, Canvas.GetTop(selectedRectangle) + ((selectedRectangle.Height) / 2) - 5);
            Canvas.SetLeft(LeftThumb, Canvas.GetLeft(selectedRectangle) - 5);
            Canvas.SetTop(LeftThumb, Canvas.GetTop(selectedRectangle) + ((selectedRectangle.Height) / 2) - 5);
            Canvas.SetLeft(TopThumb, Canvas.GetLeft(selectedRectangle) + (selectedRectangle.Width / 2) - 5);
            Canvas.SetTop(TopThumb, Canvas.GetTop(selectedRectangle) - 5);
            Canvas.SetLeft(BottomThumb, Canvas.GetLeft(selectedRectangle) + (selectedRectangle.Width / 2) - 5);
            Canvas.SetTop(BottomThumb, Canvas.GetTop(selectedRectangle) + selectedRectangle.Height - 5);
        }

        //private bool PointContainsCheck(Rectangle rec, Point p)
        private bool PointContainsCheck(ResizableRectangle rec, Point p)
        {
            if (p.X >= Canvas.GetLeft(rec) && p.X <= Canvas.GetLeft(rec) + rec.Width &&
                p.Y >= Canvas.GetTop(rec) && p.Y <= Canvas.GetTop(rec) + rec.Height)
            {
                //rectRegion = rec;
                resizableRectangle = rec;
                return true;
            }
            return false;
        }

        private void OnImageMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (CropModeCheckbox.IsChecked == true && selectRegion.IsChecked == false)
            {
                if (IsMouseDown)
                {
                    Console.WriteLine(e.GetPosition(imageCanvas));
                    CropImage((int)point1.X, (int)point1.Y, (int)point2.X, (int)point2.Y , true);
                }
                IsMouseDown = false;
            }
            if (IsRegionSelected && selectedRectangle!= null)
            {
                prev = 0;
                //GetThumbSetToRectangle(selectedRectangle);
                selectedRectangle.IsSelected = true;
            }

        }

        private void OnWindowMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnImageMouseUp(sender, e);
        }

        private void OnImageMouseMove(object sender, MouseEventArgs e)
        {
            if (CropModeCheckbox.IsChecked == true)
            {
                if (e.GetPosition(img).X < 0 || e.GetPosition(img).X > img.ActualWidth
                 || e.GetPosition(img).Y < 0 || e.GetPosition(img).Y > img.ActualHeight) return;
                if (IsMouseDown)
                {
                    X2.Text = e.GetPosition(img).X.ToString();
                    Y2.Text = e.GetPosition(img).Y.ToString();
                    point2 = new Point(e.GetPosition(img).X, e.GetPosition(img).Y);
                    rectPoint2 = new Point(e.GetPosition(imageCanvas).X, e.GetPosition(imageCanvas).Y);
                    if (rectPoint2.X < rectPoint1.X)
                    {
                        //Canvas.SetLeft(rectRegion, rectPoint2.X);
                        //rectRegion.Width = rectPoint1.X - rectPoint2.X;
                        Canvas.SetLeft(resizableRectangle, rectPoint2.X);
                        resizableRectangle.Width = rectPoint1.X - rectPoint2.X;
                    }
                    else
                    {
                        //Canvas.SetLeft(rectRegion, rectPoint1.X);
                        //rectRegion.Width = rectPoint2.X - rectPoint1.X;
                        Canvas.SetLeft(resizableRectangle, rectPoint1.X);
                        resizableRectangle.Width = rectPoint2.X - rectPoint1.X;
                    }
                    if (rectPoint2.Y < rectPoint1.Y)
                    {
                        //Canvas.SetTop(rectRegion, rectPoint2.Y);
                        //rectRegion.Height = rectPoint1.Y - rectPoint2.Y;
                        Canvas.SetTop(resizableRectangle, rectPoint2.Y);
                        resizableRectangle.Height = rectPoint1.Y - rectPoint2.Y;
                    }
                    else
                    {
                        //Canvas.SetTop(rectRegion, rectPoint1.Y);
                        //rectRegion.Height = rectPoint2.Y - rectPoint1.Y;
                        Canvas.SetTop(resizableRectangle, rectPoint1.Y);
                        resizableRectangle.Height = rectPoint2.Y - rectPoint1.Y;
                    }
                }
            }
            else
            {
                CropImage((int)(e.GetPosition(img).X - 20), (int)(e.GetPosition(img).Y - 20), (int)(e.GetPosition(img).X + 20), (int)(e.GetPosition(img).Y + 20) , true);
            }
        }

        private void CropImage(int x, int y, int x2, int y2 ,bool newOne)
        {
            if (CropModeCheckbox.IsChecked == true)
            {
                if (x == x2 || y == y2) return;
                if (x > x2)
                {
                    x = x + x2;
                    x2 = x - x2;
                    x = x - x2;
                }
                if (y > y2)
                {
                    y = y + y2;
                    y2 = y - y2;
                    y = y - y2;
                }
                if (img.Source is BitmapSource bitmapSource)
                {
                    TransformGroup transformGroup = new TransformGroup();
                    transformGroup.Children.Add(new ScaleTransform(bitmapSource.PixelWidth / img.ActualWidth, bitmapSource.PixelHeight / img.ActualHeight));
                    Int32Rect cropRect = new Int32Rect(x, y, x2 - x, y2 - y);
                    Rect rect = Rect.Transform(new Rect(cropRect.X, cropRect.Y, cropRect.Width, cropRect.Height), transformGroup.Value);
                    cropRect = new Int32Rect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
                    CroppedBitmap croppedBitmap = new CroppedBitmap(bitmapSource, cropRect);
                    //CroppedImageViewer cropped = new CroppedImageViewer(count++, rectRegion) { ImageSource = croppedBitmap, Height = 150, Width = croppedImagePanel.Width, Margin = new Thickness(10) };

                    if (newOne)
                    {
                        CroppedImageViewer cropped = new CroppedImageViewer(count++, resizableRectangle) { ImageSource = croppedBitmap, Height = 150, Width = croppedImagePanel.Width, Margin = new Thickness(10) };
                        cropped.DeleteClicked += OnCroppedImageDeleteClicked;
                        croppedImagePanel.Children.Add(cropped);
                    }
                    else
                    {
                        foreach(CroppedImageViewer cropped in croppedImagePanel.Children)
                        {
                            if(cropped.Rect == selectedRectangle)
                            {
                                cropped.ImageSource = croppedBitmap;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (x < 0) { x2 = x2 - x; x = 0; }
                if (y < 0) { y2 = y2 - y; y = 0; }
                if (y2 > img.ActualHeight) { y = y - (y2 - (int)(img.ActualHeight)); y2 = (int)img.ActualHeight; }
                if (x2 > img.ActualWidth) { x = x - (x2 - (int)(img.ActualWidth)); x2 = (int)img.ActualWidth; }
                if (img.Source is BitmapSource bitmapSource)
                {
                    TransformGroup transformGroup = new TransformGroup();
                    transformGroup.Children.Add(new ScaleTransform(bitmapSource.PixelWidth / img.ActualWidth, bitmapSource.PixelHeight / img.ActualHeight));
                    Int32Rect cropRect = new Int32Rect(x, y, x2 - x, y2 - y);
                    Rect rect = Rect.Transform(new Rect(cropRect.X, cropRect.Y, cropRect.Width, cropRect.Height), transformGroup.Value);
                    cropRect = new Int32Rect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
                    CroppedBitmap croppedBitmap = new CroppedBitmap(bitmapSource, cropRect);
                    zoomViewImg.Source = croppedBitmap;
                }
            }
        }

        private void OnZoomViewCanvasVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ClearRegions();
            IsRegionSelected = false;
        }

        private void OnCroppedImageDeleteClicked(object sender, EventArgs e)
        {
            if (sender is CroppedImageViewer croppedImage)
            {
                croppedImagePanel.Children.Remove(croppedImage);
                imageCanvas.Children.Remove(croppedImage.Rect);
                croppedImage.Rect.IsResized -= OnResizableRectangleResized;
                //sortedRectangles.Remove(croppedImage.Rect);
                sortedRectangles.Remove(croppedImage.Rect);
                croppedImage.DeleteClicked -= OnCroppedImageDeleteClicked;
            }
        }

        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        int prev = 0;
        private void OnTopThumbDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (selectedRectangle.Height - (e.VerticalChange - prev) <= 30) { prev = 0; return; }
            Canvas.SetTop(selectedRectangle, tempPoint.Y + e.VerticalChange);
            selectedRectangle.Height -= (e.VerticalChange - prev);
            prev = (int)e.VerticalChange;
        }

        private void OnBottomThumbDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if ((selectedRectangle.Height + (e.VerticalChange - prev)) <= 30) { prev = 0; return; }
            selectedRectangle.Height += (e.VerticalChange - prev);
            prev = (int)e.VerticalChange;
        }

        private void OnRightThumbDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if ((selectedRectangle.Width + (e.HorizontalChange - prev)) <= 30) { prev = 0; return; }
            selectedRectangle.Width += (e.HorizontalChange - prev);
            prev = (int)e.HorizontalChange;
        }

        private void OnLeftThumbDragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (selectedRectangle.Width - (e.HorizontalChange - prev) <= 30) { prev = 0; return; }
            Canvas.SetLeft(selectedRectangle, tempPoint.X + e.HorizontalChange);
            selectedRectangle.Width -= (e.HorizontalChange - prev);
            prev = (int)e.HorizontalChange;
        }

        private void SelectLblMouseDown(object sender, MouseButtonEventArgs e)
        {
            #region SaveImage
            //foreach (CroppedImageViewer cropimg in croppedImagePanel.Children)
            //{
            //    if (cropimg.ImageSource is BitmapSource bitmapSource)
            //    {
            //        // Configure save file dialog box
            //        SaveFileDialog dlg = new SaveFileDialog
            //        {
            //            FileName = "Image" + cropimg.Id, // Default file name
            //            DefaultExt = ".png", // Default file extension
            //            Filter = "PNG Files (*.png)|*.png" // Filter files by extension
            //        };

            //        bool? result = dlg.ShowDialog();

            //        using (FileStream stream = new FileStream(dlg.FileName, FileMode.Create))
            //        {
            //            BitmapEncoder encoder = new PngBitmapEncoder();
            //            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            //            encoder.Save(stream);
            //        }
            //    }
            //}
            #endregion
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ClearRegions();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();
                img.Source = bitmap;
            }
        }

        private void ClearRegions()
        {
            while (croppedImagePanel.Children.Count > 0)
            {
                OnCroppedImageDeleteClicked(croppedImagePanel.Children[0] as CroppedImageViewer, EventArgs.Empty);
            }
        }

        //private void SortRectangles(List<Rectangle> rects)
        private void SortRectangles(List<ResizableRectangle> rects)
        {
            var sorted = rects.OrderBy(r => r.Width * r.Height).ToList();
            sortedRectangles = new List<ResizableRectangle>(sorted);
        }
    }
}

