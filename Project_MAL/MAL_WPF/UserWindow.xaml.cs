﻿using System;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUser.DisplayMemberPath = "name";
            cmbUser.ItemsSource = DatabaseOperations.OphalenUsers();
            cmbCollection.DisplayMemberPath = "name";
            cmbCollection.ItemsSource = DatabaseOperations.OphalenCollectie();

            cmbCollection.Items.Refresh();

            //dataCollection.ItemsSource = DatabaseOperations.OphalenAnimesViaId();

            //List<Collection> collection = DatabaseOperations.OphalenCollectie();

            List<User> users = DatabaseOperations.OphalenUsers();
        }

        private void BtnAnimeCollection_Click(object sender, RoutedEventArgs e)
        {
            AnimeWindow animeWindow = new AnimeWindow();
            animeWindow.Show();
        }

        private void BtnNewList_Click(object sender, RoutedEventArgs e)
        {
            NewListWindow newListWindow = new NewListWindow();
            newListWindow.Show();
        }

        private void BtnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            VerwijderenLijstWindow verwijderenLijstWindow = new VerwijderenLijstWindow();
            verwijderenLijstWindow.Show();
        }

        private void DataCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataCollection.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        private void CmbLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataCollection.ItemsSource = DatabaseOperations.OphalenAnimes();
        }

        private void CmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string foutmelding = Valideer("cmbUser");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                User user = cmbUser.SelectedItem as User;
                Collection collection = cmbCollection.SelectedItem as Collection;

                dataUser.ItemsSource = DatabaseOperations.OphalenUsersViaId(user.userId);
                dataCollection.ItemsSource = DatabaseOperations.OphalenLijstenPerGebruiker(collection.collectionId);
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void DataUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

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

        private void BtnWijzigenNaam_Click(object sender, RoutedEventArgs e)
        {
            WijzigenWindow wijzigenWindow = new WijzigenWindow();
            wijzigenWindow.Show();
        }
    }
}
