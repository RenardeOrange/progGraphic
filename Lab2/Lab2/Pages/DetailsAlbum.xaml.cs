using Lab2.Classes;
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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lab2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsAlbum : Page
    {
        Album album;

        public DetailsAlbum()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            album = (Album)e.Parameter;

            if (album != null)
            {
                TbxAuteur.Text = album.Auteur;
                TbxLabel.Text = album.Label;
                TbxNom.Text = album.Nom;
                TbxCouverture.Text = album.Couverture;

                AlbumCover.Source = new BitmapImage(new Uri(album.Couverture));
                BtnValider.Content = "Modifier";
            }
        }


        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            TbkNom.Text = TbkNom.Text = TbkAuteur.Text = TbkLabel.Text = TbkCouverture.Text = "";

            if (string.IsNullOrWhiteSpace(TbxNom.Text))
            {
                TbkNom.Text = "Le nom ne peut pas être vide.";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(TbxAuteur.Text))
            {
                TbkAuteur.Text = "L'auteur ne peut pas être vide.";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(TbxLabel.Text))
            {
                TbkLabel.Text = "Le label ne peut pas être vide.";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(TbxCouverture.Text))
            {
                TbkCouverture.Text = "La couverture ne peut pas être vide.";
                valid = false;
            }
            else if (!Uri.IsWellFormedUriString(TbxCouverture.Text, UriKind.Absolute))
            {
                TbkCouverture.Text = "La couverture doit être une URL valide.";
                valid = false;
            }

            if (valid)
            {
                if (album != null)
                {
                    // Modification de l'album existant
                    album.Nom = TbxNom.Text;
                    album.Auteur = TbxAuteur.Text;
                    album.Label = TbxLabel.Text;
                    album.Couverture = TbxCouverture.Text;
                }
                else
                {
                    // Ajout d'un nouvel album
                    ObservableCollection<Album> listeAlbum = singletonListeAlbum.GetInstance().ListeAlbums;
                    Album newAlbum = new Album(TbxNom.Text, TbxAuteur.Text, TbxLabel.Text, TbxCouverture.Text);

                    listeAlbum.Add(newAlbum);
                }
                this.Frame.Navigate(typeof(VueAlbums));
            }
        }
    }
}
