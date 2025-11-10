using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using MySql.Data.MySqlClient;

namespace Ex1.Classes
{
    internal class SingletonBD
    {
        string connectionString;
        ObservableCollection<Maison> listeMaisons;
        static SingletonBD instance = null;
        private SingletonBD()
        {
            connectionString = "Server=cours.cegep3r.info;Database=a2025_420345ri_gr1_2483585-collin-gauthier;Uid=2483585;Pwd=2483585;";
            listeMaisons = new ObservableCollection<Maison>();
        }
        //retourne l’instance du singleton
        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();
            return instance;
        }
        //Propriété qui retourne la liste des Maisons
        public ObservableCollection<Maison> Liste { get => listeMaisons; }

        public void getAllMaisons() //charge la liste avec tous les Maisons
        {
            listeMaisons.Clear(); //permet de vider la liste avant de la recharger
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = con.CreateCommand();
                commande.CommandText = "Select * from Maison";
                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int id = r.GetInt32("id");
                    string categorie = r.GetString("categorie");
                    double prix = r.GetDouble("prix");
                    string ville = r.GetString("ville");
                    Maison Maison = new Maison(id, categorie, prix, ville);
                    listeMaisons.Add(Maison);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public int getcategoriebreMaisons()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "select count(*) from Maison";
                con.Open();
                var res = commande.ExecuteScalar();
                con.Close();
                if (res is not null)
                    return Convert.ToInt32(res);
                else
                    return 0;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return 0;
            }
        }
        //ajoute un Maison dans la liste
        public void ajouter(string categorie, double prix, string ville)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into Maison values(null, @categorie, @prix, @ville) ";
                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@ville", ville);
                con.Open();
                int i = commande.ExecuteNonQuery();
                using MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;
                commande2.CommandText = "select LAST_INSERT_ID() ";
                var res = commande2.ExecuteScalar();
                getAllMaisons(); //permet de recharger la liste des Maisons après un ajout
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //modifie l’ville d’un Maison
        public void modifierville(int id, string ville)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "update Maison set ville = @ville where id = @id";
                commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@ville", ville);
                con.Open();
                int i = commande.ExecuteNonQuery();

                getAllMaisons(); //permet de recharger la liste des Maisons après un ajout
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //supprime un Maison en fonction de son id
        public void supprimer(int id)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from Maison where id = @id";
                commande.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = commande.ExecuteNonQuery();

                getAllMaisons(); //permet de recharger la liste des Maisons après un ajout
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //Effectue une recherche en fonction du categorie
        public void rechercheParcategorie(string recherche)
        {
            listeMaisons.Clear(); //permet de vider la liste avant de la recharger
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                commande.CommandText = "Select * from Maison where categorie like @recherche";
                commande.Parameters.AddWithValue("@recherche", recherche);

                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int id = r.GetInt32("id");
                    string categorie = r.GetString("categorie");
                    double prix = r.GetDouble("prix");
                    string ville = r.GetString("ville");
                    Maison Maison = new Maison(id, categorie, prix, ville);
                    listeMaisons.Add(Maison);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //Effectue une recherche en fonction du categorie
        public void rechercheParVille(string recherche)
        {
            listeMaisons.Clear(); //permet de vider la liste avant de la recharger
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                commande.CommandText = "Select * from Maison where ville like @recherche";
                commande.Parameters.AddWithValue("@recherche", "%"+recherche+"%");

                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int id = r.GetInt32("id");
                    string categorie = r.GetString("categorie");
                    double prix = r.GetDouble("prix");
                    string ville = r.GetString("ville");
                    Maison Maison = new Maison(id, categorie, prix, ville);
                    listeMaisons.Add(Maison);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
