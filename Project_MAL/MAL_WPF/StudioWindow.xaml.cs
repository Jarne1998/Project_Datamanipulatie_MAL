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
    /// Interaction logic for StudioWindow.xaml
    /// </summary>
    public partial class StudioWindow : Window
    {
        public StudioWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataAnime.DisplayMemberPath = "name";
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();

            dataStudioInfo.DisplayMemberPath = "name";
            dataStudioInfo.ItemsSource = DatabaseOperations.OphalenStudio();

            Studio studio = DatabaseOperations.OphalenStudioViaId();

            switch (Helper.studioId)
            {
                case 1:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Eight_Bit_logo.png", UriKind.Relative));
                    break;
                case 2:
                    PosterBleach.Source = new BitmapImage(new Uri("images/MadHouseLogo.jpg", UriKind.Relative));
                    break;
                case 3:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Toei_Animation_logo.png", UriKind.Relative));
                    break;
                case 4:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Studio_Pierrot.jpg", UriKind.Relative));
                    break;
                case 5:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Tms_logo.jpg", UriKind.Relative));
                    break;
                case 6:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Production_I.G_Logo.jpg", UriKind.Relative));
                    break;
                case 7:
                    PosterBleach.Source = new BitmapImage(new Uri("images/studio_gallop.jpg", UriKind.Relative));
                    break;
                case 8:
                    PosterBleach.Source = new BitmapImage(new Uri("images/studio_bones.jpg", UriKind.Relative));
                    break;
                case 9:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Ufotable_Logo.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Anime anime = (Anime)dataAnime.SelectedItem;

            Helper.animeId = anime.animeId;

            AnimeInfoWindow animeInfoWindow = new AnimeInfoWindow();
            animeInfoWindow.Show();
        }
    }
}
