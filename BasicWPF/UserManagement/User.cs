using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class User :INotifyPropertyChanged
    {
        private string password;

        public string Username { get; set; }

        public string Password
        {
            get => password;
            
            set
            {
                password = value;
                int n = CheckPasswordStrength(value);
                SetPasswordStrength(n);
                LastUpdated = DateTime.Now;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(PasswordStrength));
                OnPropertyChanged(nameof(LastUpdated));
            }

        }

        public DateTime CreatedTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public Strength PasswordStrength { get; set; } = Strength.Week;

        private void SetPasswordStrength(int n)
        {
            if (n == 1)
                PasswordStrength = Strength.Week;
            if (n == 2)
                PasswordStrength = Strength.Average;
            if (n == 3)
                PasswordStrength = Strength.Good;
            if (n == 4)
                PasswordStrength = Strength.Strong;
        }


        private int CheckPasswordStrength(string password)
        {
            int count = 0;
            if (password.Length > 8)
            {
                count++;
            }
            foreach (char i in specialChar)
            {
                if (password.Contains(i))
                {
                    count++;
                    break;
                }
            }
            bool isLower = false, isUpper = false;
            foreach (char i in password)
            {
                if (i >= 65 && i <= 90)
                {
                    isUpper = true;
                }
                if (i >= 97 && i <= 122)
                {
                    isLower = true;
                }
                if (isLower && isUpper)
                {
                    break;
                }
            }
            if (isLower)
                count++;
            if (isUpper)
                count++;
            return count;
        }

        private readonly List<char> specialChar = new List<char>() { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public enum Strength
        {
            Week,
            Average,
            Good,
            Strong
        }
    }
}
