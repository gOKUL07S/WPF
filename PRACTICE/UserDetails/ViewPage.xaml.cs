using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserDetails
{
    /// <summary>
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Window
    {
        public ViewPage()
        {
            InitializeComponent();
            DataContext = this;
            Users.Add(new User() { UserName = "Admin", Password = "Admin", CreatedTime = DateTime.Now, LastUpdated = DateTime.Now, PasswordStrength = 0 });
            list.ItemsSource = Users;
        }

        public ObservableCollection<User> Users { get; set; }
    }
}
