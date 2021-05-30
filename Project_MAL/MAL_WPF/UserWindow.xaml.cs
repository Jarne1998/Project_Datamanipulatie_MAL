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
using MAL_DAL;

namespace MAL_WPF
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Known bugs:
        /// - User info wordt niet in het datagrid ingeladen.
        /// - Elke lijst wordt automatisch opgevuld met alle anims in de
        ///   database.
        /// - Lijsten worden aangemaakt maar worden niet altijd toegevoegd aan de
        ///   user die geslecteerd is. Deze kunnen wel getoond worden in de cmb
        ///   zonder een user te selecteren.
        /// </summary>

        /// <summary>
        /// Deze methode laad alle data in.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.Items.Refresh();
            cmbCollection.Items.Refresh();

            cmbUser.DisplayMemberPath = "name";
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbCollection.DisplayMemberPath = "name";
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();

            List<User> users = DatabaseOperations.OphalenUsers();
        }

        /// <summary>
        /// Deze methode maakt het mogelijk om door te gaan naar een ander scherm.
        /// </summary>
        private void BtnAnimeCollection_Click(object sender, RoutedEventArgs e)
        {
            AnimeWindow animeWindow = new AnimeWindow();
            animeWindow.Show();
        }

        /// <summary>
        /// CUD:
        /// Deze methode gaat door naar het scherm voor de namen van een lijst te wijwzigen.
        /// </summary>
        private void BtnNewList_Click(object sender, RoutedEventArgs e)
        {
            NewListWindow newListWindow = new NewListWindow();
            newListWindow.Show();
        }

        /// <summary>
        /// CUD:
        /// Maakt het mogelijk om een lijst te verwijderen.
        /// </summary>
        private void BtnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            VerwijderenLijstWindow verwijderenLijstWindow = new VerwijderenLijstWindow();
            verwijderenLijstWindow.Show();
        }

        /// <summary>
        /// Deze methode haalt alle animes binnen.
        /// </summary>
        private void DataCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataCollection.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /// <summary>
        /// Laad alle lijsten in de combobox in van de bijhorende user.
        /// </summary>
        private void CmbLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbCollection.Items.Refresh();

            string foutmelding = Valideer("cmbCollection");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Collection collection = cmbCollection.SelectedItem as Collection;

                dataCollection.ItemsSource = DatabaseOperations.OphalenAnimeCollectie(collection.collectionId);
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        /// <summary>
        /// Laad alle gebruikers in de combobox in.
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

        private void DataUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Valideer methode.
        /// </summary>
        private string Valideer(string colmName)
        {
            if (colmName == "cmbUser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }
            if (colmName == "cmbCollection" && cmbCollection.SelectedItem == null)
            {
                return "Selceteer eerst een gebruiker!" + Environment.NewLine;
            }

            return "";
        }

        /// <summary>
        /// CUD:
        /// Gaat door naar wijzigenscherm
        /// </summary>
        private void BtnWijzigenNaam_Click(object sender, RoutedEventArgs e)
        {
            WijzigenWindow wijzigenWindow = new WijzigenWindow();
            wijzigenWindow.Show();
        }
    }
}
