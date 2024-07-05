using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllBasicControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Span_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFile.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
            }
        }


        //OpenFileDialog openFileDialog = new OpenFileDialog();
        //if(openFileDialog.ShowDialog() == true)
        //{
        //    Uri fileUri = new Uri(openFileDialog.FileName);
        //    imgDynamic.Source = new BitmapImage(fileUri);
        //}

        //Uri resourceUri = new Uri("/Images/white_bengal_tiger.jpg", UriKind.Relative);
        //imgDynamic.Source = new BitmapImage(resourceUri);
    }
}
