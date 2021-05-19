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
    /// Interaction logic for AnimeWindow.xaml
    /// </summary>
    public partial class AnimeWindow : Window
    {
        public AnimeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataAnime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void BtnAnime_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenAnime();
        }

        private void BtnStudio_Click(object sender, RoutedEventArgs e)
        {
            dataAnime.ItemsSource = DatabaseOperations.OphalenStudio();
        }

        private void DataStudio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
