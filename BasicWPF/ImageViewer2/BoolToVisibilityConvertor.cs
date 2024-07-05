using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ImageViewer2
{
    public class BoolToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = parameter as string;
            if (parameter == null || string.IsNullOrEmpty(name)) return Visibility.Collapsed;
            if (value is bool val)
            {
                if ((!val && name == nameof(Canvas)) || (val && name == nameof(ScrollViewer))) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility Visible)
                return true;
            return false;
        }
    }
}
