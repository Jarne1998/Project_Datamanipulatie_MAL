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
    /// Interaction logic for AnimeInfoWindow.xaml
    /// </summary>
    public partial class AnimeInfoWindow : Window
    {
        public AnimeInfoWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Known bugs:
        /// - Data wordt getoond alleen niet de specifieke data over de 
        ///   anime en de studio die hier bij hoord.
        /// </summary>

        /// <summary>
        /// De DatabaseOperations: OphalenStudioViaId, OphalenAnimes, OphalenStudio en OphalenAnimesViaId zorgen 
        /// voor het inladen van de huidige data.De switch methode wordt gebruikt om de juiste afbeelding bij de juiste Anime
        /// te tonen.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Studio studio = DatabaseOperations.OphalenStudioViaId();

            dataAnimeInfo.DisplayMemberPath = "name";
            dataAnimeInfo.ItemsSource = DatabaseOperations.OphalenAnimes();

            dataStudio.DisplayMemberPath = "name";
            dataStudio.ItemsSource = DatabaseOperations.OphalenStudio();

            Anime anime = DatabaseOperations.OphalenAnimesViaId();

            switch (Helper.animeId)
            {
                case 1:
                    PosterBleach.Source = new BitmapImage(new Uri("images/That-Time-I-Got-Reincarnated-as-a-Slime.jpg", UriKind.Relative));
                    break;
                case 2:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Overlord.jpg", UriKind.Relative));
                    break;
                case 3:
                    PosterBleach.Source = new BitmapImage(new Uri("images/OnePiece.jpg", UriKind.Relative));
                    break;
                case 4:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Naruto.jpg", UriKind.Relative));
                    break;
                case 5:
                    PosterBleach.Source = new BitmapImage(new Uri("images/DetectiveConan.jpg", UriKind.Relative));
                    break;
                case 6:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Haikyuu.jpg", UriKind.Relative));
                    break;
                case 7:
                    PosterBleach.Source = new BitmapImage(new Uri("images/5ds-yu-gi-oh.jpg", UriKind.Relative));
                    break;
                case 8:
                    PosterBleach.Source = new BitmapImage(new Uri("images/FullmetalAlchemist.jpg", UriKind.Relative));
                    break;
                case 9:
                    PosterBleach.Source = new BitmapImage(new Uri("images/DeamonSlayer.jpg", UriKind.Relative));
                    break;
                case 10:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Bleach.jpg", UriKind.Relative));
                    break;

                default:
                    break;
            }            
        }

        /// <summary>
        /// Deze methode sluit het huidige scherm.
        /// </summary>
        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataAnimeInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Deze methode zorgt voor het selecteren van data in de databse en opend de bijhorende window.
        /// </summary>
        private void DataStudio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Studio studio = dataStudio.SelectedItem as Studio;

            Helper.studioId = studio.studioId;

            StudioWindow studioWindow = new StudioWindow();
            studioWindow.Show();
        }
    }
}
