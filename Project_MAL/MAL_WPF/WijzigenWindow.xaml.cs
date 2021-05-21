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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbUser.DisplayMemberPath = "name";
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();
            cmbCollection.DisplayMemberPath = "name";
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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
                        datagridLijstInhoud.ItemsSource = DatabaseOperations.OphalenAnimesViaId();

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

        private string Valideer(string columnName)
        {
            return "";
        }

        private void DatagridLijstInhoud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagridLijstInhoud.ItemsSource = DatabaseOperations.OphalenAnime();
        }
    }
}
