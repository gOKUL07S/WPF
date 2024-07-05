using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

       

        private List<Uri> uris = new List<Uri>();
        private DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddSongToUriList(Properties.Resources.Telangana_Bommalu, "TelanganaBommalu.mp3");
            AddSongToUriList(Properties.Resources.galatta, "galatta.mp3");
            AddSongToUriList(Properties.Resources.mankatha, "mankatha.mp3");
            AddSongToUriList(Properties.Resources.Badass, "Badass.mp3");
            foreach (var music in uris)
            {
                listbox.Items.Add(System.IO.Path.GetFileName(music.LocalPath));
            }
        }
        private void AddSongToUriList(byte[] songResource, string fileName)
        {
            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);
            File.WriteAllBytes(tempFilePath, songResource);
            uris.Add(new Uri(tempFilePath, UriKind.Absolute));
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if(listbox.SelectedIndex !=-1)
            {
                media.Source = uris[listbox.SelectedIndex];
                media.Play();
                timer.Start();
            }
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            timer.Stop();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            timer.Stop();
            musicplayer.Value = 0;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = e.NewValue;
        }

        private void MediaOpen(object sender, RoutedEventArgs e)
        {
            musicplayer.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }
        private bool isDragging;
        private void mediaslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //double newposition = e.NewValue * media.NaturalDuration.TimeSpan.TotalSeconds;
            //media.Position = TimeSpan.FromSeconds(newposition);
            if (!isDragging)
            {
                double newPosition = e.NewValue;
                media.Position = TimeSpan.FromSeconds(newPosition);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (media.NaturalDuration.HasTimeSpan && media.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (!isDragging)
                {
                    musicplayer.Value = media.Position.TotalSeconds;
                }
            }
        }

        private void musicplayer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
        }

        private void musicplayer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            media.Position = TimeSpan.FromSeconds(musicplayer.Value);
        }
    }
}
