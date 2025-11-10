using Cours18___Dialog.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours18___Dialog
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

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.MyButton.XamlRoot;
            dialog.Title = " Titre de la boite de dialogue ";
            dialog.PrimaryButtonText = "Oui";
            dialog.SecondaryButtonText = "Non";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.Content = " Le message à afficher ";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
                Debug.WriteLine("bouton primaire sélectionné");
            else if (resultat == ContentDialogResult.Secondary)
                Debug.WriteLine("bouton secondaire sélectionné");
            else
                Debug.WriteLine("bouton par défaut sélectionné");

        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            //sélectionne le fichier à lire
            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();
            //ouvre le fichier et lit le contenu
            if (monFichier != null)
            {
                var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);
                List<Client> liste = new List<Client>();
                /*boucle permettant de lire chacune des lignes du fichier
                * et de remplir une liste d'objets de type Client
                */
                foreach (var ligne in lignes)
                {
                    var v = ligne.Split(";");
                    if (v.Length > 0)
                    {
                        int id = Convert.ToInt32(v[0]); //colonne 0
                        string nom = v[1]; //colonne 1
                        string prenom = v[2]; //colonne 2
                        string email = v[3]; //colonne 3
                        liste.Add(new Client(id, nom, prenom, email));
                    }
                }
                lvClients.ItemsSource = liste;
            }

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //création de la boite de dialogue pour le choix de l’emplacement
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            picker.SuggestedFileName = "test";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            List<Client> liste = new List<Client>();
            liste.Add(new Client(1, "Line", "Savoie", "line.Savoie@mail.com"));
            liste.Add(new Client(2, "Marie", "Marcotte", "marie.marcotte@mail.com"));
            liste.Add(new Client(3, "Liam", "Gélinas", "liam.gelinas@mail.com"));

            //écrit dans le fichier s'il n'est pas null
           if (monFichier != null)
                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }
    }
}
