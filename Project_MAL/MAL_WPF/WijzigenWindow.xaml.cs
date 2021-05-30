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
    /// Interaction logic for WijzigenWindow.xaml
    /// </summary>
    public partial class WijzigenWindow : Window
    {
        public WijzigenWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deze methode laad alle data in.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbUser.DisplayMemberPath = "name";
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();
            cmbCollection.DisplayMemberPath = "name";

            cmbUser.Items.Refresh();
            cmbCollection.Items.Refresh();
        }

        /// <summary>
        /// Deze methode sluit het huidge scherm.
        /// </summary>
        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Deze methode maakt het mogelijk om namen aan te passen van lijsten.
        /// </summary>
        private void BtnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("name");

            foutmelding += Valideer("cmbCollectie");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Collection collection = cmbCollection.SelectedItem as Collection;
                User user = datagridLijstInhoud.SelectedItem as User;

                collection.name = txtNaamLijst.Text;

                if (collection.IsGeldig())
                {
                    int ok = DatabaseOperations.AanpassenNaamLijst(collection);
                    if (ok > 0)
                    {
                        datagridLijstInhoud.ItemsSource = DatabaseOperations.OphalenAnimes();

                    }
                    else
                    {
                        MessageBox.Show("Inhoud is niet aangepast!");
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
        /// Deze methode zorgt voor de validatie op de combobox.
        /// </summary>
        private string Valideer(string columnName)
        {
            if (columnName == "cmbuser" && cmbUser.SelectedItem == null)
            {
                return "Selecteer een gebruiker";
            }

            return "";
        }

        /// <summary>
        /// Deze mthode laad alle animes in.
        /// </summary>
        private void DatagridLijstInhoud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagridLijstInhoud.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        /// <summary>
        /// Deze methode zorgt voor het ophalen vand e bijhorende lijsten van elke user.
        /// </summary>
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
    }
}
