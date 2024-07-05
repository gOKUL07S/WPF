using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public static class UserManager
    {
        public static ObservableCollection<User> Users = new ObservableCollection<User>() { new User() { Username = "Admin", Password = "Admin", CreatedTime = DateTime.Now, LastUpdated = DateTime.Now } };

        public static bool create;

        public static bool IsUserExists(string username)
        {
            User user = Users.FirstOrDefault(i => i.Username == username);
            if ( user != null)
                return true;
            return false;
        }

        public static User GetUser(string username)
        {
            return Users.FirstOrDefault(i => i.Username == username);
        }

        public static bool PasswordMatches(string username ,string password)
        {
            User user = Users.First(i => i.Username == username);
            if (user.Password == password)
                return true;
            else
                return false;
        }

        public static bool CreateUser(string username , string confirmPassword , string newPassword)
        {
            if(!IsUserExists(username) && confirmPassword == newPassword)
            {
                Users.Add(new User() { Username = username, Password = confirmPassword, CreatedTime = DateTime.Now, LastUpdated = DateTime.Now });
            }
            return false;
        }

        public static bool ChangePassword(string username, string newPassword , string confirmPassword)
        {
            User user = GetUser(username);
            if (user!=null && newPassword == confirmPassword)
            {
                user.Password = confirmPassword;
                return true;
            }
            return false;
        }
        
    }
}
