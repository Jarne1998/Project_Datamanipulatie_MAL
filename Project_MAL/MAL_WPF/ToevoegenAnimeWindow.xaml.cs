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
            dataAnime.DisplayMemberPath = "name";
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
