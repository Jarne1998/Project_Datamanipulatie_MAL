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
    /// Interaction logic for VerwijderenLijstWindow.xaml
    /// </summary>
    public partial class VerwijderenLijstWindow : Window
    {
        public VerwijderenLijstWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataLijsten.DisplayMemberPath = "name";
            dataLijsten.ItemsSource = DatabaseOperations.OphalenCollectie();

            dataLijsten.Items.Refresh();
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("name");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Collection collection = dataLijsten.SelectedItem as Collection;

                int ok = DatabaseOperations.VerwijderenLijst(collection);
                if (ok > 0)
                {
                    MessageBox.Show("Verwijderen van lijst is gelukt!");
                }
                else
                {
                    MessageBox.Show("Lijst is niet verwijderd!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private string Valideer(string colmName)
        {
            if (colmName == "dataLijsten" && dataLijsten.SelectedItem == null)
            {
                return "Selecteer een gebruiker!" + Environment.NewLine;
            }

            return "";
        }
    }
}
