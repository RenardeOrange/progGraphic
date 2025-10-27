using Exercice.Class;
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
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class listProduits : Page
    {
        ObservableCollection<Produit> listproduits;
        public listProduits()
        {
            InitializeComponent();
            listproduits = SingletonProduits.GetInstance().ListProduits;
            lvProduits.ItemsSource = listproduits;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            //Récupération du bouton qui a lancé l'évènement
            Button button = sender as Button;

            //DataContext représente le type d'objet lié à l'item 
            Produit produit = button.DataContext as Produit;

            //On supprime l'objet lié à l'item
            listproduits.Remove(produit);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
