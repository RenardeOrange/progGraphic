using Exercice.Pages;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<Produit> _listProduits;
        private ObservableCollection<Commande> _listCommandes;

        public MainWindow()
        {
            InitializeComponent();
            _listProduits = new ObservableCollection<Produit>()
            {
                new Produit("Tronçonneuse", 130.22, false, "jardin", "https://www.tronconneuse-electrique.net/wp-content/uploads/2024/01/Comment-fonctionne-une-tronconneuse-electrique-Black-et-Decker-vue-eclatee-.png"),
                new Produit("Ordinateur Portable", 299.99, true, "informatique", "https://th.bing.com/th/id/R.167666ddade74bd852dbc6520c0d9492?rik=rXVPHdta3nkJmg&pid=ImgRaw&r=0"),
            };
            _listCommandes = new ObservableCollection<Commande>()
            {
                new Commande(new DateTime(2025, 5, 1), "Alice Dupont", "alice@dupont.com", false),
                new Commande(new DateTime(2024, 2, 25), "Bob Martin", "bob@martin.com", true),
            };
            mainFrame.Navigate(typeof(listProduits));
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            if (item != null)
            {
                switch (item.Tag)
                {
                    case "importer":
                        Debug.WriteLine("importer");
                        //code pour ouverture
                        break;
                    case "exporter":
                        Debug.WriteLine("exporter");
                        //code pour sauvegarde
                        break;
                    case "quitter":
                        Application.Current.Exit();
                        break;
                    default:
                        Debug.WriteLine("probleme");
                        Debug.WriteLine("tag : " + (item.Tag ?? "null"));
                        Debug.WriteLine("text : " + item.Text);
                        break;
                }
            }
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                var selectedItem = args.SelectedItem as NavigationViewItem;
                switch (selectedItem.Tag)
                {
                    case "ajouterProduit":
                        mainFrame.Navigate(typeof(ajouterProduit), new navData
                        {
                            listProduits = _listProduits,
                            listCommandes = null,
                            Produit = null,
                            Commande = null
                        });
                        break;
                    case "listProduits":
                        mainFrame.Navigate(typeof(listProduits), new navData
                        {
                            listProduits = _listProduits,
                            listCommandes = null,
                            Produit = null,
                            Commande = null
                        });
                        break;
                    case "ajouterCommande":
                        mainFrame.Navigate(typeof(ajouterCommande), new navData
                        {
                            listProduits = null,
                            listCommandes = null,
                            Produit = null,
                            Commande = null
                        });
                        break;
                    case "listCommandes":
                        mainFrame.Navigate(typeof(listCommandes), new navData
                        {
                            listProduits = null,
                            listCommandes = null,
                            Produit = null,
                            Commande = null
                        });
                        break;
                    default:
                        Debug.WriteLine("probleme de navigation");
                        Debug.WriteLine("tag : " + (selectedItem.Tag ?? "null"));
                        Debug.WriteLine("content : " + selectedItem.Content);
                        break;
                }
            }
        }
    }
}
