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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }

        private void BtnAnimeCollection_Click(object sender, RoutedEventArgs e)
        {
            AnimeWindow animeWindow = new AnimeWindow();
            animeWindow.Show();
        }

        private void BtnStudioCollection_Click(object sender, RoutedEventArgs e)
        {
            AnimeWindow animeWindow = new AnimeWindow();
            animeWindow.Show();
        }
    }
}
