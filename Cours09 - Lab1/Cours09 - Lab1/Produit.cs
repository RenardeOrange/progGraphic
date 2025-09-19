using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours09___Lab1
{
    internal class Produit
    {
        string nom;
        string categorie;
        double prix;
        bool disponible;
        int qualite;
        bool enSolde;

        public Produit()
        {
            this.nom = "vide";
            this.categorie = "aucune";
            this.prix = 00.00;
            this.disponible = false;
            this.qualite = 1;
            this.enSolde = false;
        }

        public Produit(string nom, string categorie, double prix, bool disponible, int qualite, bool enSolde)
        {
            this.nom = nom;
            this.categorie = categorie;
            this.prix = prix;
            this.disponible = disponible;
            this.qualite = qualite;
            this.enSolde = enSolde;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public double Prix { get => prix; set => prix = value; }
        public bool Disponible { get => disponible; set => disponible = value; }
        public int Qualite { get => qualite; set => qualite = value; }
        public bool EnSolde { get => enSolde; set => enSolde = value; }


        public override string? ToString()
        {
            return $"{nom} - {categorie} - {prix}$ - {(disponible ? "disponible" : "non disponible")} - {qualite}/10 - {(enSolde ? "En solde" : "")}";
        }
    }
}
