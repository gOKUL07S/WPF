using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDetails
{
    public class User
    {
        public string UserName { get; set; }

        public string Password
        {
            get => Password;
            set
            {
                int n = CheckPasswordStrength(value);
                SetPasswordStrength(n);
            }

        }

        private void SetPasswordStrength(int n)
        {
            if (n == 1)
                PasswordStrength = Strength.Week;
            if (n == 2)
                PasswordStrength = Strength.Good;
            if (n == 3)
                PasswordStrength = Strength.Average;
            if (n == 4)
                PasswordStrength = Strength.Strong;
        }

        public DateTime CreatedTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public Strength PasswordStrength { get; set; } = Strength.Week;

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

        public enum Strength
        {
            Week,
            Average,
            Good,
            Strong
        }
    }
}
