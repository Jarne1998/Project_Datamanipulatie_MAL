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

        /*
         Laad een afbeelding in.
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PosterBleach.Source = new BitmapImage(new Uri("images/DeamonSlayer.jpg", UriKind.Relative));
        }

        /*
         Maakt het mogelijk om een anime of een studio te selecteren en door te gaan naar de bijhorende window.
         Maakt gebruik van de Helper klasse.
         */
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

        /*
         Laad alle animes in.
         */
        private void BtnAnime_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /*
         Laad alle studios in.
         */
        private void BtnStudio_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenStudio();
        }

        /*
         Sluit het huidige venster.
         */
        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }
    }
}
