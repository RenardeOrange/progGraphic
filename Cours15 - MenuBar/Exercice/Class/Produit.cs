using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Class
{
    internal class Produit
    {
        int id;
        string nom;
        double prix;
        bool neuf;
        string categorie;
        string image;
        public static class GlobalCounter
        {
            public static int Counter = 0; // Global variable
        }

        public Produit(string nom, double prix, bool neuf, string categorie, string image)
        {
            GlobalCounter.Counter++;
            this.id = GlobalCounter.Counter;
            this.nom = nom;
            this.prix = prix;
            this.neuf = neuf;
            this.categorie = categorie;
            this.image = image;
        }

        public int Id { set => id = value; get => id; }
        public string Nom { set => nom = value; get => nom; }
        public double Prix { 
            set { 
                if (value >= 10 && value <= 500) prix = value;
            }
            get => prix; }
        public bool Neuf { set => neuf = value; get => neuf; }
        public string Categorie { set => categorie = value; get => categorie; }
        public string Image { set => image = value; get => image; }

    }
}
