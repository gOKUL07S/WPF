using System;
using System.Collections.Generic;
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

namespace UserControlTest
{
    /// <summary>
    /// Interaction logic for ResizableRectangle.xaml
    /// </summary>
    public partial class ResizableRectangle : UserControl
    {
        public ResizableRectangle()
        {
            InitializeComponent();
            this.DataContext = this;
            IsSelected = false ;
        }
        
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
                if (value)
                {
                    Rectangle.StrokeDashArray = new DoubleCollection() { 2, 2 };
                }
                else
                {
                    Rectangle.StrokeDashArray = new DoubleCollection() { };
                }
            }

        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ResizableRectangle), new PropertyMetadata(false));


        public event EventHandler IsResized;

        private void TopLeftThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newX = Canvas.GetLeft(this) + e.HorizontalChange;
            double newY = Canvas.GetTop(this) + e.VerticalChange;
            double newWidth = Width - e.HorizontalChange;
            double newHeight = Height - e.VerticalChange;
            if (newWidth > 0 && newHeight > 0)
            {
                Canvas.SetLeft(this, newX);
                Canvas.SetTop(this, newY);
                Width = newWidth;
                Height = newHeight;
            }
        }

        private void TopRightThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newY = Canvas.GetTop(this) + e.VerticalChange;
            double newWidth = Width + e.HorizontalChange;
            double newHeight = Height - e.VerticalChange;
            if (newWidth > 0 && newHeight > 0)
            {
                Canvas.SetTop(this, newY);
                Width = newWidth;
                Height = newHeight;
            }
        }

        private void BottomLeftThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newX = Canvas.GetLeft(this) + e.HorizontalChange;
            double newWidth = Width - e.HorizontalChange;
            double newHeight = Height + e.VerticalChange;
            if (newWidth > 0 && newHeight > 0)
            {
                Canvas.SetLeft(this, newX);
                Width = newWidth;
                Height = newHeight;
            }
        }

        private void BottomRightThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = Width + e.HorizontalChange;
            double newHeight = Height + e.VerticalChange;
            if (newWidth > 0 && newHeight > 0)
            {
                Width = newWidth;
                Height = newHeight;
            }
        }

        private void TopThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newY = Canvas.GetTop(this) + e.VerticalChange;
            double newHeight = Height - e.VerticalChange;
            if (newHeight > 0)
            {
                Canvas.SetTop(this, newY);
                Height = newHeight;
            }
        }

        private void BottomThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newHeight = Height + e.VerticalChange;
            if (newHeight > 0)
            {
                Height = newHeight;
            }
        }

        private void LeftThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newX = Canvas.GetLeft(this) + e.HorizontalChange;
            double newWidth = Width - e.HorizontalChange;
            if (newWidth > 0)
            {
                Canvas.SetLeft(this, newX);
                Width = newWidth;
            }
        }

        private void RightThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = Width + e.HorizontalChange;
            if (newWidth > 0)
            {
                Width = newWidth;
            }
        }

        private void SetThumbLocations()
        {
            double halfThumbWidth = TopLeftThumb.Width / 2;
            double halfThumbHeight = TopLeftThumb.Height / 2;
            
            Canvas.SetLeft(TopLeftThumb, -halfThumbWidth);
            Canvas.SetTop(TopLeftThumb, -halfThumbHeight);

            Canvas.SetLeft(TopRightThumb, Width - halfThumbWidth);
            Canvas.SetTop(TopRightThumb, -halfThumbHeight);

            Canvas.SetLeft(BottomLeftThumb, -halfThumbWidth);
            Canvas.SetTop(BottomLeftThumb, Height - halfThumbHeight);

            Canvas.SetLeft(BottomRightThumb, Width - halfThumbWidth);
            Canvas.SetTop(BottomRightThumb, Height - halfThumbHeight);
            
            Canvas.SetLeft(TopThumb, Width / 2 - halfThumbWidth);
            Canvas.SetTop(TopThumb, -halfThumbHeight);

            Canvas.SetLeft(BottomThumb, Width / 2 - halfThumbWidth);
            Canvas.SetTop(BottomThumb, Height - halfThumbHeight);

            Canvas.SetLeft(LeftThumb, -halfThumbWidth);
            Canvas.SetTop(LeftThumb, Height / 2 - halfThumbHeight);

            Canvas.SetLeft(RightThumb, Width - halfThumbWidth);
            Canvas.SetTop(RightThumb, Height / 2 - halfThumbHeight);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            SetThumbLocations();
            IsResized?.Invoke(this , EventArgs.Empty);
        }

        //private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        //{
        //    Thumb thumb = sender as Thumb;
        //    double newWidth = Rectangle.Width;
        //    double newHeight = Rectangle.Height;
        //    double newLeft = Canvas.GetLeft(Rectangle);
        //    double newTop = Canvas.GetTop(Rectangle);

        //    //if (thumb.Name == "TopLeftThumb" || thumb.Name == "LeftThumb" || thumb.Name == "BottomLeftThumb")
        //    //{
        //    //    newWidth = Rectangle.Width - e.HorizontalChange;
        //    //    newLeft = Canvas.GetLeft(Rectangle) + e.HorizontalChange;
        //    //}
        //    //if (thumb.Name == "TopLeftThumb" || thumb.Name == "TopThumb" || thumb.Name == "TopRightThumb")
        //    //{
        //    //    newHeight = Rectangle.Height - e.VerticalChange;
        //    //    newTop = Canvas.GetTop(Rectangle) + e.VerticalChange;
        //    //}
        //    //if (thumb.Name == "TopRightThumb" || thumb.Name == "RightThumb" || thumb.Name == "BottomRightThumb")
        //    //{
        //    //    newWidth = Rectangle.Width + e.HorizontalChange;
        //    //}
        //    //if (thumb.Name == "BottomLeftThumb" || thumb.Name == "BottomThumb" || thumb.Name == "BottomRightThumb")
        //    //{
        //    //    newHeight = Rectangle.Height + e.VerticalChange;
        //    //}

        //    //if (newWidth > 0 && newHeight > 0)
        //    //{
        //    //    Rectangle.Width = newWidth;
        //    //    Rectangle.Height = newHeight;
        //    //    Canvas.SetLeft(Rectangle, newLeft);
        //    //    Canvas.SetTop(Rectangle, newTop);
        //    //}

        //    //////if(thumb.Name ==  "BottomRightThumb")
        //    //////{
        //    //////    newWidth = Rectangle.Width + e.HorizontalChange;
        //    //////    newHeight = Rectangle.Height + e.VerticalChange;
        //    //////    if (newWidth > 0 && newHeight > 0)
        //    //////    {
        //    //////        Rectangle.Width = newWidth;
        //    //////        Rectangle.Height = newHeight;
        //    //////        Canvas.SetLeft(Rectangle, newLeft);
        //    //////        Canvas.SetTop(Rectangle, newTop);
        //    //////    }
        //    //////}

        //    //////if(thumb.Name == "BottomLeftThumb")
        //    //////{
        //    //////    newHeight = Rectangle.Height - e.HorizontalChange;
        //    //////    if(newHeight > 0)
        //    //////    {
        //    //////        Rectangle.Height = newHeight;
        //    //////        Canvas.SetLeft(Rectangle, newLeft - e.HorizontalChange);
        //    //////    }
        //    //////}

        //    if (thumb.Name == "RightThumb")
        //    {
        //        newWidth = Rectangle.Width + e.HorizontalChange;
        //        if (newWidth > 0 )
        //        {
        //            Rectangle.Width = newWidth;
        //            Canvas.SetLeft(Rectangle, newLeft);
        //        }
        //    }

        //    if (thumb.Name == "BottomThumb")
        //    {
        //        newHeight = Rectangle.Height + e.VerticalChange;
        //        if (newHeight > 0)
        //        {
        //            Rectangle.Height = newHeight;
        //            Canvas.SetTop(Rectangle, newTop);
        //        }
        //    }

        //    if (thumb.Name == "TopThumb")
        //    {
        //        newHeight = Rectangle.Height - e.VerticalChange;
        //        if (newHeight > 0)
        //        {
        //            Canvas.SetTop(Rectangle, newTop + e.VerticalChange);
        //            ThisControl.Height = newHeight;
        //            Rectangle.Height = newHeight;
        //            //newTop = Canvas.GetTop(Rectangle) - e.VerticalChange;
        //        }
        //    }

        //}
    }
}
