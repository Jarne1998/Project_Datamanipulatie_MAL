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

        /// <summary>
        /// Laad een afbeelding in.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PosterBleach.Source = new BitmapImage(new Uri("images/DeamonSlayer.jpg", UriKind.Relative));
        }

        /// <summary>
        /// Maakt het mogelijk om een anime of een studio te selecteren en door te gaan naar de bijhorende window.
        /// Maakt gebruik van de Helper klasse.
        /// </summary>
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

        /// <summary>
        /// Laad alle animes in.
        /// </summary>
        private void BtnAnime_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /// <summary>
        /// Laad alle studios in.
        /// </summary>
        private void BtnStudio_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenStudio();
        }

        /// <summary>
        /// Sluit het huidige venster.
        /// </summary>
        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }
    }
}
