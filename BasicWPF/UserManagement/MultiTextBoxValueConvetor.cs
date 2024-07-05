using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UserManagement
{
    public class MultiTextBoxValueConvetor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 1)
            {
                if (values[0] is string username)
                    return !string.IsNullOrEmpty(username) && username == "Admin";
                return false;
            }
            else if (values.Length == 2)
            {
                if (values[0] is string username && values[1] is string newpassword)
                    return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(newpassword) && UserManager.IsUserExists(username) && UserManager.PasswordMatches(values[0].ToString(), values[1].ToString());
                return false;
            }
            else if (values.Length == 3)
            {
                if (UserManager.create)
                {
                    if (values[0] is string username && values[1] is string newpassword && values[1] is string confirmpassword)
                        return !string.IsNullOrEmpty(values[0].ToString()) && !string.IsNullOrEmpty(values[1].ToString()) && !string.IsNullOrEmpty(values[2].ToString()) &&
                            values[1].ToString() == values[2].ToString() && !UserManager.IsUserExists(values[0].ToString());
                    return false;
                }
                else
                {
                    if (values[0] is string username && values[1] is string newpassword && values[1] is string confirmpassword)
                        return !string.IsNullOrEmpty(values[0].ToString()) && !string.IsNullOrEmpty(values[1].ToString()) && !string.IsNullOrEmpty(values[2].ToString()) &&
                            values[1].ToString() == values[2].ToString() && UserManager.IsUserExists(values[0].ToString());
                    return false;
                }
            }
            else return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return targetTypes; // empty return
        }
    }
}
