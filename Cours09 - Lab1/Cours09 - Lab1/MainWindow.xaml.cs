using Cours09___Lab1;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
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
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours08
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection<Recette> listeRecettes;

        public MainWindow()
        {
            InitializeComponent();

            listeRecettes = new ObservableCollection<Recette>()
            {
                new Recette("Poutine au homard", "Plat principal", "1h10",
                "Inspirés par la poutine au homard des îles de la Madeleine, on a créé une version irrésitible avec une sauce maison, onctueuse comme une bisque, à l’agréable fumet de poisson rehaussé de fenouil et de piment de Cayenne. Le homard, qu’on peut cuire soi-même ou acheter frais cuit (ou encore qui a été cuit, congelé, puis emballé sous vide), doit être de qualité, sinon il sera caoutchouteux. Pour simplifier la suite de l’opération, on utilise des frites surgelées. On saute ainsi les étapes du pelage de pommes de terre et de la cuisson à la friteuse. Et le résultat sera tout aussi bon.",
                "https://images.ricardocuisine.com/services/recipes/496x670_poutine.jpg"),
            };
            lvRecettes.ItemsSource = listeRecettes;
        }
        /*
        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNom.Text != "" && cbxCat.SelectedItem is not null && nbPrix is not null)
            {
                string nom = tbxNom.Text;
                string cat = (string)cbxCat.SelectedItem;
                double prix = (double)nbPrix.Value;
                bool dispo = (bool)swDisponible.IsOn;
                int qualite = (int)sldQualite.Value;
                bool solde = (bool)chkSolde.IsChecked;

                btnAjout.Content = "Ajouter produit";
                Produit produit = new Produit(nom, cat, prix, dispo, qualite, solde);

                lvProduits.Items.Add(produit);
                tblProduits.Text = $"Nombre de produits: {lvProduits.Items.Count}";
            }
            else
            {
                btnAjout.Content = "Paramètres incomplets";
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduits.SelectedItem is not null)
            {
                btnDel.Content = "Supprimer le produit sélectionné" +
                    "";
                lvProduits.Items.Remove(lvProduits.SelectedItem);
                tblProduits.Text = $"Nombre de produits: {lvProduits.Items.Count}";
            }
            else
            {
                btnDel.Content = "Aucun produit sélectionné";
            }
        }
        */
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            tbkDesc.Text = tbkDuree.Text = tbkTitre.Text = tbkUrl.Text = tbkCat.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(tbxTitre.Text))
            {
                tbkTitre.Text = "Le titre est obligatoire.";
            }
            else if (tbxTitre.Text.Length < 3)
            {
                tbkTitre.Text = "Le titre doit contenir au moins 3 caractères.";
            }
            else if (tbxTitre.Text.Length > 100)
            {
                tbkTitre.Text = "Le titre doit contenir moins de 100 caractères.";
            }

            if (cmbCat.SelectedIndex == -1)
            {
                tbkCat.Text = "La catégorie est obligatoire.";
            }

            if (string.IsNullOrWhiteSpace(tbxDuree.Text))
            {
                tbkDuree.Text = "La durée est obligatoire.";
            }
            else if (!Regex.IsMatch(tbxDuree.Text, "^((\\d{1,2}h([0-5]?\\dmn)?)|(\\d{1,3}mn))$"))
            {
                tbkDuree.Text = "Le format de la durée doit être 1h20mn ou 35mn";
            }

            if (string.IsNullOrWhiteSpace(tbxUrl.Text))
            {
                tbkUrl.Text = "L'URL de l'image est obligatoire.";
            }
            else if (!Uri.IsWellFormedUriString(tbxUrl.Text, UriKind.Absolute))
            {
                tbkUrl.Text = "Le format de l'URL est invalide.";
            }

            if (string.IsNullOrWhiteSpace(tbxDesc.Text))
            {
                tbkDesc.Text = "La description est obligatoire.";
            }

            if (string.IsNullOrWhiteSpace(tbkTitre.Text) &&
                string.IsNullOrWhiteSpace(tbkDesc.Text) &&
                string.IsNullOrWhiteSpace(tbkDuree.Text) &&
                string.IsNullOrWhiteSpace(tbkUrl.Text) &&
                string.IsNullOrWhiteSpace(tbkCat.Text))
            {
                Recette recette = new Recette(
                    tbxTitre.Text,
                    cmbCat.SelectedItem.ToString(),
                    tbxDuree.Text,
                    tbxDesc.Text,
                    tbxUrl.Text
                    );
                listeRecettes.Add(recette);
                tbxTitre.Text = tbxDuree.Text = tbxDesc.Text = tbxUrl.Text = string.Empty;
                cmbCat.SelectedIndex = -1;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            //Récupération du bouton qui a lancé l'évènement
            Button button = sender as Button;

            //DataContext représente le type d'objet lié à l'item 
            Recette recette = button.DataContext as Recette;

            //On supprime l'objet lié à l'item
            listeRecettes.Remove(recette);
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            //Récupération du bouton qui a lancé l'évènement
            Button button = sender as Button;

            //DataContext représente le type d'objet lié à l'item 
            Recette recette = button.DataContext as Recette;

            tbkDesc.Text = tbkDuree.Text = tbkTitre.Text = tbkUrl.Text = tbkCat.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(tbxTitre.Text))
            {
                tbkTitre.Text = "Le titre est obligatoire.";
            }
            else if (tbxTitre.Text.Length < 3)
            {
                tbkTitre.Text = "Le titre doit contenir au moins 3 caractères.";
            }
            else if (tbxTitre.Text.Length > 100)
            {
                tbkTitre.Text = "Le titre doit contenir moins de 100 caractères.";
            }

            if (cmbCat.SelectedIndex == -1)
            {
                tbkCat.Text = "La catégorie est obligatoire.";
            }

            if (string.IsNullOrWhiteSpace(tbxDuree.Text))
            {
                tbkDuree.Text = "La durée est obligatoire.";
            }
            else if (!Regex.IsMatch(tbxDuree.Text, "^((\\d{1,2}h([0-5]?\\dmn)?)|(\\d{1,3}mn))$"))
            {
                tbkDuree.Text = "Le format de la durée doit être 1h20mn ou 35mn";
            }

            if (string.IsNullOrWhiteSpace(tbxUrl.Text))
            {
                tbkUrl.Text = "L'URL de l'image est obligatoire.";
            }
            else if (!Uri.IsWellFormedUriString(tbxUrl.Text, UriKind.Absolute))
            {
                tbkUrl.Text = "Le format de l'URL est invalide.";
            }

            if (string.IsNullOrWhiteSpace(tbxDesc.Text))
            {
                tbkDesc.Text = "La description est obligatoire.";
            }

            if (string.IsNullOrWhiteSpace(tbkTitre.Text) &&
                string.IsNullOrWhiteSpace(tbkDesc.Text) &&
                string.IsNullOrWhiteSpace(tbkDuree.Text) &&
                string.IsNullOrWhiteSpace(tbkUrl.Text) &&
                string.IsNullOrWhiteSpace(tbkCat.Text))
            {
                recette.Titre = tbxTitre.Text;
                recette.Categorie = cmbCat.SelectedItem.ToString();
                recette.Duree = tbxDuree.Text;
                recette.Description = tbxDesc.Text;
                recette.UrlImage = tbxUrl.Text;
                tbxTitre.Text = tbxDuree.Text = tbxDesc.Text = tbxUrl.Text = string.Empty;
                cmbCat.SelectedIndex = -1;
            }
        }
    }
}
