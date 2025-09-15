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
            if (tbxNom.Text != "" && cbxCat.SelectedItem is not null)
            {
                btnAjout.Content = "Ajouter";
                string nom = tbxNom.Text;
                string cat = (string)cbxCat.SelectedItem;

                switch (cat)
                {
                    case "Informatique":
                        if (lvInfo.Items.Count < 5)
                        {
                            lvInfo.Items.Add(nom);
                        }
                        else
                        {
                            btnAjout.Content = "Limite atteinte";
                        }

                            break;
                    case "Meubles":
                        if (lvMeub.Items.Count < 5)
                        {
                            lvMeub.Items.Add(nom);
                        }
                        else
                        {
                            btnAjout.Content = "Limite atteinte";
                        }
                        break;
                    case "Électroménager":
                        if (lvElec.Items.Count < 5)
                        {
                            lvElec.Items.Add(nom);
                        }
                        else
                        {
                            btnAjout.Content = "Limite atteinte";
                        }
                        break;
                }
            }
            else
            {
                btnAjout.Content = "Paramètres incomplets";
            }
        }

        private void lvInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvInfo.SelectedItem is not null)
            {
                lvInfo.Items.Remove(lvInfo.SelectedItem);
                lvInfo.SelectedItem = null;
            }
        }

        private void lvMeub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvMeub.SelectedItem is not null)
            {
                lvMeub.Items.Remove(lvMeub.SelectedItem);
                lvMeub.SelectedItem = null;
            }
        }

        private void lvElec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvElec.SelectedItem is not null)
            {
                lvElec.Items.Remove(lvElec.SelectedItem);
                lvElec.SelectedItem = null;
            }
        }
    }
}
