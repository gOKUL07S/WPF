using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UserControlTest
{
    class HalfValueConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value is double doubleValue )
            //{
            //    return (doubleValue / 2);
            //}
            //return value;
            if (value is double doubleValue)
            {
                double result = doubleValue / 2;

                // Apply the ConverterParameter if it's a valid number
                if (parameter != null && double.TryParse(parameter.ToString(), out double paramValue))
                {
                    result += paramValue;
                }

                return result;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
