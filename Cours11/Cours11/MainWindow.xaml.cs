using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Isolation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours11
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

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            tbkErreurNom.Text = string.Empty;
            tbkErreurNombre.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(tbxNom.Text))
            {
                tbkErreurNom.Text = "Le nom est obligatoire.";
                tbxNom.Focus(FocusState.Programmatic);
                return;
            }
            else if (tbxNom.Text.Length < 5)
            {
                tbkErreurNom.Text = "Le nom doit contenir au moins 5 caractères.";
                tbxNom.Focus(FocusState.Programmatic);
                return;
            }

            if (Int32.TryParse(tbxNom.Text, out int nombre))
            {
                if (nombre < 1 || nombre > 100)
                {
                    tbkErreurNombre.Text = "Le nombre doit être entre 1 et 100.";
                    tbxNom.Focus(FocusState.Programmatic);
                    return;
                }
            }
            else
            {
                tbkErreurNombre.Text = "Le nombre doit être un entier valide.";
                tbxNom.Focus(FocusState.Programmatic);
                return;
            }
        }
    }
}
