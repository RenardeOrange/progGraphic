using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExamIntra
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection<Jeu> listeJeux;
        Jeu jeu;

        public MainWindow()
        {
            InitializeComponent();

            listeJeux = new ObservableCollection<Jeu>()
            {
                new Jeu("Hollow Knight : Silksong", "Team Cherry", "04 sept. 2025", "https://image.jeuxvideo.com/medias-sm/175985/1759847000-8419-jaquette-avant.jpg"),
                new Jeu("Borderlands 4", "2K Games Gear - box Software", "12 sept. 2025", "https://image.jeuxvideo.com/medias-sm/175697/1756970746-5912-jaquette-avant.jpg"),
                new Jeu("EA Sports FC 26", "EA Sports", "26 sept. 2025", "https://image.jeuxvideo.com/medias-sm/175268/1752682779-9893-jaquette-avant.png"),
            };
            lvJeux.ItemsSource = listeJeux;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Jeu jeu = new Jeu(
                tbxTitre.Text,
                tbxCompagnie.Text,
                tbxSortie.Text,
                tbxUrl.Text
                );
            listeJeux.Add(jeu);
            tbxTitre.Text = tbxCompagnie.Text = tbxSortie.Text = tbxUrl.Text = string.Empty;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            //On supprime l'objet lié à l'item
            listeJeux.Remove(jeu);
        }

        private void lvJeux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvJeux.SelectedItem != null)
            {
                jeu = lvJeux.SelectedItem as Jeu;
                tblZoomTitre.Text = jeu.Titre;
                tblZoomCompagnie.Text = jeu.Compagnie;
                tblZoomSortie.Text = jeu.Sortie;
                ImgZoom.Source = new BitmapImage(new Uri(jeu.Url));
                btnDel.Visibility = Visibility.Visible;
            }
            else
            {
                tblZoomTitre.Text = tblZoomCompagnie.Text = tblZoomSortie.Text = string.Empty;
                btnDel.Visibility = Visibility.Collapsed;
                ImgZoom.Source = null;
            }
        }
    }
}
