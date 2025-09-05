using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ex3
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
        private void btnCalcul_Click(object sender, RoutedEventArgs e)
        {
            double prix = Convert.ToDouble(tbxPrix.Text);
            prix = Math.Round(prix, 2);
            double frais = Math.Round(prix * 0.02, 2);
            double profit = Math.Round(prix * 0.12, 2);
            double prixAvantTaxes = prix + frais + profit;
            prixAvantTaxes = Math.Round(prixAvantTaxes * (chkOccasion.IsChecked == true ? 0.80 : 1), 2);
            double TPS = Math.Round(prixAvantTaxes * 0.05, 2);
            double TVQ = Math.Round(prixAvantTaxes * 0.09975, 2);
            double prixTotal = Math.Round(prixAvantTaxes + TPS + TVQ, 2);

            tblReponse.Text = 
                $" Frais : {frais}" +
                $"\n Profit : {profit}" +
                $"\n Prix avant taxes : {prixAvantTaxes}" +
                $"\n TPS : {TPS}" +
                $"\n TVQ : {TVQ}" +
                $"\n Prix total : {prixTotal}";
        }
    }
}
