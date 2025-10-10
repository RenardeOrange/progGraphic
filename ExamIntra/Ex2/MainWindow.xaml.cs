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
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ex2
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

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            tbkNom.Text = tbkAdresse.Text = tbkReservation.Text = tbkType.Text = tbkPaiement.Text = tbkPrestataire.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(tbxNom.Text))
            {
                tbkNom.Text = "Le nom est obligatoire.";
            }
            else if (tbxNom.Text.Length < 5)
            {
                tbkNom.Text = "Le nom doit contenir au moins 5 caractères.";
            }
            else if (tbxNom.Text.Length > 50)
            {
                tbkNom.Text = "Le nom doit contenir moins de 50 caractères.";
            }

            if (string.IsNullOrWhiteSpace(tbxAdresse.Text))
            {
                tbkAdresse.Text = "L'adresse est obligatoire.";
            }

            if (string.IsNullOrWhiteSpace(tbxReservation.Text))
            {
                tbkReservation.Text = "La date de réservation est obligatoire.";
            }
            else if (!Regex.IsMatch(tbxReservation.Text, "^(0[1-9]|[12][0-9]|3[01])\\/(0[1-9]|1[0-2])\\/([1-9]\\d\\d\\d)$"))
            {
                tbkReservation.Text = "La date de réservation doit être au format JJ/MM/AAAA";
            }

            if (cmbType.SelectedIndex == -1)
            {
                tbkType.Text = "Un type de service est requis.";
            }

            if (rbtnPaiement.SelectedIndex == -1)
            {
                tbkPaiement.Text = "Un type de paiement est requis.";
            }

            if (cmbPrestataire.SelectedIndex == -1)
            {
                tbkPrestataire.Text = "Un prestataire est requis.";
            }

            if (string.IsNullOrWhiteSpace(tbkNom.Text) &&
                string.IsNullOrWhiteSpace(tbkAdresse.Text) &&
                string.IsNullOrWhiteSpace(tbkReservation.Text) &&
                string.IsNullOrWhiteSpace(tbkType.Text) &&
                string.IsNullOrWhiteSpace(tbkPaiement.Text) &&
                string.IsNullOrWhiteSpace(tbkPrestataire.Text))
            {
                tblNom.Text = "Nom du client: " + tbxNom.Text;
                tblAdresse.Text = "Adresse: " + tbxAdresse.Text;
                tblReservation.Text = "Date: " + tbxReservation.Text;
                tblType.Text = "Type de service: " + (cmbType.SelectedItem as String).ToString();
                tblPaiement.Text = "Prestataire: " + (rbtnPaiement.SelectedItem as String).ToString();
                tblPrestataire.Text = "Paiement par " + (cmbPrestataire.SelectedItem as String).ToString();

                tbxNom.Text = tbxAdresse.Text = tbxReservation.Text = string.Empty;
                cmbType.SelectedIndex = rbtnPaiement.SelectedIndex = cmbPrestataire.SelectedIndex = -1;
                stkPanelDetails.Visibility = Visibility.Visible;
            }
        }
    }
}
