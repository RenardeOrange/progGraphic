using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Membre
    {
        string nom;
        int age;
        string password;
        string abonnement;
        bool actif;

        public Membre()
        {
            nom = "Inconnu";
            age = 0;
            password = "Secret1234";
            abonnement = "Mensuel";
            actif = false;
        }

        public Membre(string nom, int age, string password, string abonnement, bool actif)
        {
            this.nom = nom;
            this.age = age;
            this.password = password;
            this.abonnement = abonnement;
            this.actif = actif;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Age { get => age; set => age = value; }
        public string Password { get => password; set => password = value; }
        public string Abonnement { get => abonnement; set => abonnement = value; }
        public bool Actif { get => actif; set => actif = value; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return "Nom: " + nom + "\nAge: " + age + "\nPassword: " + password + "\nAbonnement: " + abonnement + "\nActif: " + actif;
        }
    }
}
