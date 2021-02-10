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
using System.IO;

namespace Zene_lejatszo
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
        MediaPlayer mediaPlayer = new MediaPlayer();
        string filename;

        private void BT_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    if (!SongsListBox.Items.Contains(file))
                    {
                        SongsListBox.Items.Add(file);
                    }
                }
            }
        }

        private void BT_Click_Play(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void BT_Click_Pause(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void BT_Click_Stop(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void BT_Click_Repeat(object sender, RoutedEventArgs e)
        {
            if (repeatType == 0)
            {
                repeatType = 1;
            }
            else if (repeatType == 1)
            {
                repeatType = 2;
                Repeat.Content = "Be";
            }
            else
            {
                repeatType = 0;
                Repeat.Content = "Ki";

            }
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = (double)volumeSlider.Value;
            
        }
        public double ElapsedSeconds
        {
               get
               {
                   return mediaPlayer.Position.TotalSeconds;
               }
               set
               {
                   PropertyChanged(this, new PropertyChangedEventArgs(nameof(ElapsedSeconds)));
               }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds = mediaPlayer.Position.TotalSeconds;
        }
    
    }
}
