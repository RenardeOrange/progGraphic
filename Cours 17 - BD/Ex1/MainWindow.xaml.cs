using Ex1.Classes;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ex1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        SingletonBD SingletonBD = Classes.SingletonBD.getInstance();
        public MainWindow()
        {
            InitializeComponent();
            lvListeMaisons.ItemsSource = SingletonBD.Liste;
            SingletonBD.getAllMaisons();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string categorie = cmbCat.SelectedItem as string;
            double prix = Convert.ToDouble(nbxPrix.Text);
            string ville = tbxVille.Text;
            SingletonBD.ajouter(categorie, prix, ville);
        }

        private void tbxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            string recherche = tbxRecherche.Text;
            SingletonBD.rechercheParVille(recherche);
        }

        private void cmbRecherche_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cat = cmbRecherche.SelectedItem as string;
            if (cat != null)
            {
                if (cat == "Tout")
                {
                    SingletonBD.getAllMaisons();
                }
                else
                {
                    SingletonBD.rechercheParcategorie(cat);
                }
            }
        }
    }
}
