﻿using MAL_DAL;
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
    /// Interaction logic for AnimeInfoWindow.xaml
    /// </summary>
    public partial class AnimeInfoWindow : Window
    {
        public AnimeInfoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Anime anime = DatabaseOperations.OphalenAnimesViaId();

            //dataAnimeInfo.ItemsSource = anime.AnimeGenre;

            switch (Helper.animeId)
            {
                case 1:
                    PosterBleach.Source = new BitmapImage(new Uri("images/That-Time-I-Got-Reincarnated-as-a-Slime.jpg", UriKind.Relative));
                    break;
                case 2:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Overlord.jpg", UriKind.Relative));
                    break;
                case 3:
                    PosterBleach.Source = new BitmapImage(new Uri("images/OnePiece.jpg", UriKind.Relative));
                    break;
                case 4:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Naruto.jpg", UriKind.Relative));
                    break;
                case 5:
                    PosterBleach.Source = new BitmapImage(new Uri("images/DetectiveConan.jpg", UriKind.Relative));
                    break;
                case 6:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Haikyuu.jpg", UriKind.Relative));
                    break;
                case 7:
                    PosterBleach.Source = new BitmapImage(new Uri("images/5ds-yu-gi-oh.jpg", UriKind.Relative));
                    break;
                case 8:
                    PosterBleach.Source = new BitmapImage(new Uri("images/FullmetalAlchemist.jpg", UriKind.Relative));
                    break;
                case 9:
                    PosterBleach.Source = new BitmapImage(new Uri("images/DeamonSlayer.jpg", UriKind.Relative));
                    break;
                case 10:
                    PosterBleach.Source = new BitmapImage(new Uri("images/Bleach.jpg", UriKind.Relative));
                    break;

                default:
                    break;
            }

            
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataAnimeInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}