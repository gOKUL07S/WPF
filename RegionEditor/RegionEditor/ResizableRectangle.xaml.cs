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

namespace RegionEditor
{
    /// <summary>
    /// Interaction logic for ResizableRectangle.xaml
    /// </summary>
    public partial class ResizableRectangle : UserControl
    {
        public ResizableRectangle()
        {
            InitializeComponent();
            InitializeThumbs();
        }

        private void InitializeThumbs()
        {
            TopLeftThumb.DragDelta += new DragDeltaEventHandler(TopLeftThumbDragDelta);
            TopRightThumb.DragDelta += new DragDeltaEventHandler(TopRightThumbDragDelta);
            BottomLeftThumb.DragDelta += new DragDeltaEventHandler(BottomLeftThumbDragDelta);
            BottomRightThumb.DragDelta += new DragDeltaEventHandler(BottomRightThumbDragDelta);
            TopThumb.DragDelta += new DragDeltaEventHandler(TopThumbDragDelta);
            BottomThumb.DragDelta += new DragDeltaEventHandler(BottomThumbDragDelta);
            LeftThumb.DragDelta += new DragDeltaEventHandler(LeftThumbDragDelta);
            RightThumb.DragDelta += new DragDeltaEventHandler(RightThumbDragDelta);
        }

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

        private void UpdateThumbs()
        {
            double halfThumbWidth = TopLeftThumb.Width / 2;
            double halfThumbHeight = TopLeftThumb.Height / 2;

            // Corners
            Canvas.SetLeft(TopLeftThumb, -halfThumbWidth);
            Canvas.SetTop(TopLeftThumb, -halfThumbHeight);

            Canvas.SetLeft(TopRightThumb, Width - halfThumbWidth);
            Canvas.SetTop(TopRightThumb, -halfThumbHeight);

            Canvas.SetLeft(BottomLeftThumb, -halfThumbWidth);
            Canvas.SetTop(BottomLeftThumb, Height - halfThumbHeight);

            Canvas.SetLeft(BottomRightThumb, Width - halfThumbWidth);
            Canvas.SetTop(BottomRightThumb, Height - halfThumbHeight);

            // Sides
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
            UpdateThumbs();
        }
    }
}
