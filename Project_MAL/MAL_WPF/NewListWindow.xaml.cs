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
    /// Interaction logic for NewListWindow.xaml
    /// </summary>
    public partial class NewListWindow : Window
    {
        public NewListWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Laad de gebruikers in de combobox in.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.Items.Refresh();

            cmbUser.DisplayMemberPath = "name";
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
        }

        /// <summary>
        /// CUD:
        ///  Maakt nieuwe lijst aan.
        /// </summary>
        private void BtnCreateList_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("cmbUser");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Collection collection = new Collection();

                collection.name = txtLijst.Text;

                if (collection.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenLijst(collection);
                    if (ok > 0)
                    {
                        MessageBox.Show("Lijst is toegevoegd!");
                    }
                    else
                    {
                        MessageBox.Show("Lijst is niet toegevoegd");
                    }
                }
                else
                {
                    MessageBox.Show(collection.ErrorMessages);
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        /// <summary>
        /// Sluit de huidige window.
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Valideer methode
        /// </summary>
        private string Valideer(string columName)
        {
            if (columName == "cmbUser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }

            return "";
        }

        /// <summary>
        /// CUD:
        ///  Gaat naar CUD operatie voor animes toe te voegen.
        /// </summary>
        private void BtnToevoegenAnime_Click(object sender, RoutedEventArgs e)
        {
            ToevoegenAnimeWindow toevoegenAnimeWindow = new ToevoegenAnimeWindow();
            toevoegenAnimeWindow.Show();
        }
    }
}
