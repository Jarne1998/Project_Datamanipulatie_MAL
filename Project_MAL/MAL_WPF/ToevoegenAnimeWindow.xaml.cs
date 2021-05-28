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
    /// Interaction logic for ToevoegenAnimeWindow.xaml
    /// </summary>
    public partial class ToevoegenAnimeWindow : Window
    {
        public ToevoegenAnimeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();
            cmbCollection.DisplayMemberPath = "name";

            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbUser.DisplayMemberPath = "name";

            dataAnime.DisplayMemberPath = "name";
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnToevoegenAnimeAanLijst_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("cmbuser");
            foutmelding += Valideer("cmbCollection");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Anime anime = dataAnime.SelectedItem as Anime;

                int ok = DatabaseOperations.ToevoegenBestaandeAnime(anime);
                if (ok > 0)
                {
                    MessageBox.Show("Toevoegen huidige Anime is geluk!");
                }
                else
                {
                    MessageBox.Show("Toevoegen huidige Anime niet geluk!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void BtnToevoegenNieuweAnime_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("cmbUser");

            foutmelding += Valideer("cmbCollection");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                User user = cmbUser.SelectedItem as User;
                Collection collection = cmbCollection.SelectedItem as Collection;

                Anime anime = new Anime();
                anime.name = txtAnimeNaam.Text;
                anime.status = txtStatus.Text;
                anime.animeId = collection.collectionId;
                anime.animeId = user.userId;

                if (anime.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenNieuweAnime(anime);
                    MessageBox.Show("Nieuwe Anime is toegevoegd!");
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Nieuwe Anime is niet toegevoegd!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void DataAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataAnime.SelectedItem is Anime anime)
            {
                Helper.animeId = anime.animeId;

                AnimeInfoWindow animeInfoWindow = new AnimeInfoWindow();
                animeInfoWindow.Show();
            }
            else
            {
                MessageBox.Show("Kan Anime niet weergeven!");
            }
           
        }

        private void Wissen()
        {
            txtAnimeNaam.Text = "";
            txtStatus.Text = "";
        }

        private void CmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bntverwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("name");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Anime anime = dataAnime.SelectedItem as Anime;

                int ok = DatabaseOperations.VerwijderenAnime(anime);
                if (ok > 0)
                {
                    MessageBox.Show("Verwijderen van Anime is gelukt!");
                }
                else
                {
                    MessageBox.Show("Anime is niet verwijderd!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private string Valideer(string columName)
        {
            if (columName == "cmbCollection" && cmbCollection.SelectedItem == null)
            {
                return "Selecteer een lijst!" + Environment.NewLine;
            }
            else if (columName == "cmbUser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }

            return "";
        }
    }
}
