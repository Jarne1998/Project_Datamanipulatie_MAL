using MAL_DAL;
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
using System.Windows.Shapes;

namespace MAL_WPF
{
    /// <summary>
    /// Interaction logic for AnimeWindow.xaml
    /// </summary>
    public partial class AnimeWindow : Window
    {
        public AnimeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PosterBleach.Source = new BitmapImage(new Uri("images/DeamonSlayer.jpg", UriKind.Relative));
        }

        private void DataAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataAnime.SelectedItem is Anime anime)
            {
                Helper.animeId = anime.animeId;

                AnimeInfoWindow animeInfoWindow = new AnimeInfoWindow();
                animeInfoWindow.Show();
            }
            else if (dataAnime.SelectedItem is Studio studio)
            {
                Helper.studioId = studio.studioId;

                StudioWindow studioWindow = new StudioWindow();
                studioWindow.Show();
            }
        }

        private void BtnAnime_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        private void BtnStudio_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenStudio();
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }
    }
}
