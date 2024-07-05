using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RegionEditor
{
    public class ResizeAdorner : Adorner
    {
        VisualCollection AdornerVisuals;
        Thumb thumb1, thumb2;
        Rectangle Rec;

        public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            AdornerVisuals = new VisualCollection(this);
            thumb1 = new Thumb()
            {
                Background = Brushes.Coral,
                Height = 10,
                Width = 10,
            };

            thumb2 = new Thumb()
            {
                Background = Brushes.Bisque,
                Height = 10,
                Width = 10,
            };

            Rec = new Rectangle()
            {
                Stroke = Brushes.Coral,
                StrokeThickness = 2,
                StrokeDashArray = { 3, 2 },
            };

            thumb1.DragDelta += Thumb1DragDelta;
            thumb2.DragDelta += Thumb2DragDelta;

            AdornerVisuals.Add(Rec);
            AdornerVisuals.Add(thumb1);
            AdornerVisuals.Add(thumb2);
        }

        private void Thumb2DragDelta(object sender, DragDeltaEventArgs e)
        {
            var element = (FrameworkElement)AdornedElement;

            element.Height = element.ActualHeight + e.VerticalChange < 0 ? 0 : element.ActualHeight + e.VerticalChange;
            element.Width = element.ActualWidth + e.HorizontalChange < 0 ? 0 : element.ActualWidth + e.HorizontalChange;
        }

        private void Thumb1DragDelta(object sender, DragDeltaEventArgs e)
        {
            var element = (FrameworkElement)AdornedElement;

            element.Height = element.ActualHeight - e.VerticalChange < 0 ? 0 : element.ActualHeight - e.VerticalChange;
            element.Width = element.ActualWidth - e.HorizontalChange < 0 ? 0 : element.ActualWidth - e.HorizontalChange;
        }

        protected override Visual GetVisualChild(int index)
        {
            return AdornerVisuals[index];
        }

        protected override int VisualChildrenCount => AdornerVisuals.Count;

        protected override Size ArrangeOverride(Size finalSize)
        {
            Rec.Arrange(new Rect(-2.5, -2.5, AdornedElement.DesiredSize.Width + 5, AdornedElement.DesiredSize.Height + 5));
            thumb1.Arrange(new Rect(-5, -5, 10, 10));
            thumb2.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, AdornedElement.DesiredSize.Height - 5, 10, 10));

            return base.ArrangeOverride(finalSize);
        }
    }
}
