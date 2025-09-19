using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Cours09___Lab1;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours08
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
    }
}
