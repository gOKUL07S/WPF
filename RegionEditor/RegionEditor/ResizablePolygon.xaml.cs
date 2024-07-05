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
    public partial class ResizablePolygon : UserControl
    {
        private List<List<Thumb>> MultiPoints = new List<List<Thumb>>();
        private List<List<Line>> MultiLine = new List<List<Line>>();

        private List<Thumb> points = new List<Thumb>();
        private List<Line> lines = new List<Line>();

        public ResizablePolygon()
        {
            InitializeComponent();

            InitialIzeControls();
        }

        private void InitialIzeControls()
        {
            MainControl.MouseLeftButtonDown += MainControlMouseLeftButtonDown;
            MainControl.MouseRightButtonDown += MainControlMouseRightButtonDown;
        }

        private void MainControlMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (points.Count == 0)
            {
                points.Clear();
                lines.Clear();
            }


            Point clickPosition = e.GetPosition(MainControl);

            Thumb point = new Thumb
            {
                Width = 16,
                Height = 16,
                BorderBrush = Brushes.AliceBlue,
                BorderThickness = new Thickness(1)
            };
            point.DragDelta += ThumbDragDelta;

            Canvas.SetLeft(point, clickPosition.X - point.Width / 2);
            Canvas.SetTop(point, clickPosition.Y - point.Height / 2);

            MainControl.Children.Add(point);
            points.Add(point);
            Panel.SetZIndex(point, 1);
            if (points.Count > 1)
            {
                Thumb previousPoint = points[points.Count - 2];
                Line line = new Line
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    StrokeDashArray = { 2, 2 },
                    X1 = Canvas.GetLeft(previousPoint) + previousPoint.Width / 2,
                    Y1 = Canvas.GetTop(previousPoint) + previousPoint.Height / 2,
                    X2 = Canvas.GetLeft(point) + point.Width / 2,
                    Y2 = Canvas.GetTop(point) + point.Height / 2
                };
                MainControl.Children.Add(line);
                lines.Add(line);
                Panel.SetZIndex(line, 0);
            }
        }

        private void MainControlMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (points.Count > 2)
            {
                Thumb firstPoint = points[0];
                Thumb lastPoint = points[points.Count - 1];

                Line closingLine = new Line
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    StrokeDashArray = { 2, 2 },
                    X1 = Canvas.GetLeft(lastPoint) + lastPoint.Width / 2,
                    Y1 = Canvas.GetTop(lastPoint) + lastPoint.Height / 2,
                    X2 = Canvas.GetLeft(firstPoint) + firstPoint.Width / 2,
                    Y2 = Canvas.GetTop(firstPoint) + firstPoint.Height / 2
                };

                MainControl.Children.Add(closingLine);
                lines.Add(closingLine);

                MultiPoints.Add(new List<Thumb>(points));
                MultiLine.Add(new List<Line>(lines));

                points.Clear();
                lines.Clear();
            }
        }

        private void ThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb draggedThumb && MultiPoints.Count > 0)
            {
                double newLeft = Canvas.GetLeft(draggedThumb) + e.HorizontalChange;
                double newTop = Canvas.GetTop(draggedThumb) + e.VerticalChange;

                Canvas.SetLeft(draggedThumb, newLeft);
                Canvas.SetTop(draggedThumb, newTop);

                UpdateLinesForThumb(draggedThumb);
            }
        }

        private void UpdateLinesForThumb(Thumb thumb)
        {
            int OuterIndex = 0;
            int index = -1;

            foreach (List<Thumb> p in MultiPoints)
            {
                if (p.Contains(thumb))
                {
                    index = p.IndexOf(thumb);
                    OuterIndex = MultiPoints.IndexOf(p);
                    break;
                }
            }

            if (index < 0) return;

            if (index >= 0)
            {
                Line lineToPrevious = index != 0 ? MultiLine[OuterIndex][index - 1] : MultiLine[OuterIndex][MultiLine[OuterIndex].Count - 1];
                lineToPrevious.X2 = Canvas.GetLeft(thumb) + thumb.Width / 2;
                lineToPrevious.Y2 = Canvas.GetTop(thumb) + thumb.Height / 2;
            }

            if (index < MultiLine[OuterIndex].Count)
            {
                Line lineToNext = MultiLine[OuterIndex][index];
                lineToNext.X1 = Canvas.GetLeft(thumb) + thumb.Width / 2;
                lineToNext.Y1 = Canvas.GetTop(thumb) + thumb.Height / 2;
            }
        }
    }
}
