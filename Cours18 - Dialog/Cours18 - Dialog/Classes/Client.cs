using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours18___Dialog.Classes
{
    internal class Client
    {
        int id;
        string nom;
        string prenom;
        string email;

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

        public string StringCSV()
        {
            return $"{id};{nom};{prenom};{email}";
        }

        public override string ToString()
        {
            return $"{id};{nom};{prenom};{email}";
        }
    }
}
