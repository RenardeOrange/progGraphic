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
using MySql.Data.MySqlClient;
using Cours_17___BD.Classes;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours_17___BD
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MySqlConnection con;

        ObservableCollection<Client> listeClients = new ObservableCollection<Client>();
        public MainWindow()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2025_420345ri_gr1_2483585-collin-gauthier;Uid=2483585;Pwd=2483585;");
            lvListeClients.ItemsSource = listeClients;
        }

        private void btnAfficher_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM client;";

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string nom = reader.GetString("nom");
                string prenom = reader.GetString("prenom");
                string email = reader.GetString("email");

                Client client = new Client(id, nom, prenom, email);
                listeClients.Add(client);
            }
            reader.Close();
            con.Close();
        }
    }
}
