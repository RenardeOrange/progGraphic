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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours15___MenuBar
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

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            if (item != null)
            {
                switch (item.Tag)
                {
                    case "nouveau":
                        Debug.WriteLine("NOUVEAU");
                        //code pour nouveau
                        break;
                    case "ouvrir":
                        Debug.WriteLine("OUVERTURE");
                        //code pour ouverture
                        break;
                    case "sauvegarder":
                        Debug.WriteLine("SAUVEGARDE");
                        //code pour sauvegarde
                        break;
                    case "quitter":
                        Application.Current.Exit();
                        break;
                    default:
                        Debug.WriteLine("probleme");
                        Debug.WriteLine("tag : "+(item.Tag ?? "null"));
                        Debug.WriteLine("text : "+item.Text);
                        break;
                }
            }
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem != null) {
                var selectedItem = args.SelectedItem as NavigationViewItem;
                switch (selectedItem.Tag)
                {
                    case "page1":
                        mainFrame.Navigate(typeof(page1));
                        break;
                    case "page2":
                        mainFrame.Navigate(typeof(page2));
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
