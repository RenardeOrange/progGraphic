using Cours_17___BD.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
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
            chargerDonnees();
        }

        private void btnAfficher_Click(object sender, RoutedEventArgs e)
        {
            chargerDonnees();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string email = tbxEmail.Text;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO client VALUES (null, @nom, @prenom, @email);";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine(i + " ligne(s) insérée(s).");
                con.Close();
            }
            catch (MySqlException)
            {
                // Messages d'erreurs
            }
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            chargerDonnees();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = lvListeClients.SelectedItem as Client;
                if (client is not null)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    int id = client.Id;
                    string email = tbxEmail.Text;

                    cmd.Connection = con;
                    cmd.CommandText = "update client set email = @email where id = @id";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine(i + " ligne(s) modifiée(s).");
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                //message d'erreur éventuel
            }
            if (con.State == System.Data.ConnectionState.Open) {
                con.Close();
            }
            chargerDonnees();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = lvListeClients.SelectedItem as Client;
                if (client is not null)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    int id = client.Id;
                    cmd.Connection = con;

                    cmd.CommandText = "delete from client where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                //message d'erreur éventuel
            }
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            chargerDonnees();
        }

        private void chargerDonnees()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM client;";

                listeClients.Clear();

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
            }
            catch (MySqlException)
            {
                // Messages d'erreurs
            }
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void tbxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string recherche = tbxRecherche.Text;

                cmd.CommandText = "SELECT * FROM client WHERE nom LIKE @recherche;";
                cmd.Parameters.AddWithValue("@recherche", "%" + recherche + "%");

                listeClients.Clear();

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
            }
            catch (MySqlException)
            {
                // Messages d'erreurs
            }
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
