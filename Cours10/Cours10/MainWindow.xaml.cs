using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
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

namespace Cours10
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        ObservableCollection<Client> listClients = new ObservableCollection<Client>()
            {
                new Client("Durand", 30),
                new Client("Dupont", 25),
                new Client("Martin", 40),
                new Client("Bernard", 35)
            };
        public MainWindow()
        {
            InitializeComponent();
            lvClients.ItemsSource = listClients;
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            listClients[1].Nom = "RATATATA";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Récupération du bouton qui a lancé l'évènement
            Button button = sender as Button;

            //DataContext représente le type d'objet lié à l'item 
            Client client = button.DataContext as Client;

            //On supprime l'objet lié à l'item
            listClients.Remove(client);
        }
    }
}
