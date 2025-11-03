using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cours_17___BD.Classes
{
    internal class Client
    {
        int id;
        string nom, prenom, email;

        public Client(int id, string nom, string prenom, string email)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }

        public String toString()
        {
            return $"{id} - {nom} {prenom} ({email})";
        }
    }
}
