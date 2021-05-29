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

        /*
         Deze methode laad alle data in.
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.DisplayMemberPath = "name";
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbCollection.DisplayMemberPath = "name";
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();

            cmbCollection.Items.Refresh();

            List<User> users = DatabaseOperations.OphalenUsers();
        }

        /*
         Deze methode maakt het mogelijk om door te gaan naar een ander scherm.
         */
        private void BtnAnimeCollection_Click(object sender, RoutedEventArgs e)
        {
            AnimeWindow animeWindow = new AnimeWindow();
            animeWindow.Show();
        }

        /*
         CUD:
         Deze methode gaat door naar het scherm voor de namen van een lijst te wijwzigen.
         */
        private void BtnNewList_Click(object sender, RoutedEventArgs e)
        {
            NewListWindow newListWindow = new NewListWindow();
            newListWindow.Show();
        }

        /*
         CUD:
         Maakt het mogelijk om een lijst te verwijderen.
         */
        private void BtnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            VerwijderenLijstWindow verwijderenLijstWindow = new VerwijderenLijstWindow();
            verwijderenLijstWindow.Show();
        }

        /*
         Deze methode haalt alle animes binnen.
         */
        private void DataCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataCollection.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /*
         Laad alle lijsten in de combobox in van de bijhorende user.
         */
        private void CmbLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Collection collection = cmbCollection.SelectedItem as Collection;

            dataCollection.ItemsSource = DatabaseOperations.OphalenAnimeCollectie(collection.collectionId);
        }

        /*
         Laad alle gebruikers in de combobox in.
         */
        private void CmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        /*
         Valideer methode.
         */
        private string Valideer(string colmName)
        {
            if (colmName == "cmbUser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }
            if (colmName == "cmbCollection" && cmbCollection.SelectedItem == null)
            {
                return "Selceteer een lijst!" + Environment.NewLine;
            }

            return "";
        }

        /*
         * CUD:
         Gaat door naar wijzigenscherm
         */
        private void BtnWijzigenNaam_Click(object sender, RoutedEventArgs e)
        {
            WijzigenWindow wijzigenWindow = new WijzigenWindow();
            wijzigenWindow.Show();
        }
    }
}
