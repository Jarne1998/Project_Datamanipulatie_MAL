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

        /// <summary>
        /// Known bugs:
        /// - Bestaande animes kunnen toegevoegd worden aan een lijst maar deze
        ///   animes worden ook terug toegevoegd aan de database en worden meerdere keren getoond.
        ///   (Dit geld niet voor nieuwe animes die worden toegevoegd)
        /// </summary>

        /// <summary>
        /// Laad alle data in de juiste combobox of datagrid in.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();
            cmbCollection.DisplayMemberPath = "name";

            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbUser.DisplayMemberPath = "name";

            dataAnime.DisplayMemberPath = "name";
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /// <summary>
        /// Sluit de huidige window.
        /// </summary>
        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// CUD:
        /// Voegt huidige naime toe aan een bestaande of nieuwe lijst.
        /// </summary>
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

        /// <summary>
        /// CUD:
        /// Voegt een nieuwe anime toe aan de database en deze kan na het sluiten van huidig venster getoont worden in het datagrid.
        /// </summary>
        private void BtnToevoegenNieuweAnime_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("cmbUser");

            foutmelding += Valideer("cmbCollection");

            foutmelding += Valideer("txtDuur");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                User user = cmbUser.SelectedItem as User;

                Anime anime = new Anime();
                anime.name = txtAnimeNaam.Text;
                anime.status = txtStatus.Text;
                anime.aired = DateTime.Now;
                anime.duration = int.Parse(txtDuur.Text);
                anime.type = txtType.Text;

                if (anime.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenNieuweAnime(anime);

                    if (ok > 0)
                    {
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
                    MessageBox.Show("Nieuwe Anime is niet toegevoegd!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        /// <summary>
        /// Toont alle animes in het datagrid.
        /// </summary>
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

        /// <summary>
        /// Maakt de textvelden leeg
        /// </summary>
        private void Wissen()
        {
            txtAnimeNaam.Text = "";
            txtStatus.Text = "";
            txtAired.Text = "";
            txtDuur.Text = "";
            txtType.Text = "";
        }

        /// <summary>
        /// Laad de users in de combobox in en laat alle lijsten van deze user zien.
        /// </summary>
        private void CmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbUser.Items.Refresh();

            string foutmelding = Valideer("cmbUser");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                User user = cmbUser.SelectedItem as User;

                cmbCollection.ItemsSource = DatabaseOperations.OphalenLijstenPerGebruiker(user.userId);
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void CmbCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbCollection.Items.Refresh();
        }

        /// <summary>
        /// CUD:
        /// Zorgt voor het verwijderen van de geselecteerde anime.
        /// </summary>
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

        /// <summary>
        /// Valideer methode.
        /// </summary>
        private string Valideer(string columName)
        {
            int parsedValue;

            if (columName == "cmbCollection" && cmbCollection.SelectedItem == null)
            {
                return "Selecteer een lijst!" + Environment.NewLine;
            }
            else if (columName == "cmbUser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }
            else if (columName == "txtDuur" && !int.TryParse(txtDuur.Text, out parsedValue))
            {
                return "Dit is een numeriek veld!";
            }

            return "";
        }
    }
}
