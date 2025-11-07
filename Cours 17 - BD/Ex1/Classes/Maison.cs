using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1.Classes
{
    internal class Maison
    {
        int id;
        string categorie;
        double prix;
        string ville;

        public Maison(int id, string categorie, double prix, string ville)
        {
            this.id = id;
            this.categorie = categorie;
            this.prix = prix;
            this.ville = ville;
        }

        public int Id { get => id; set => id = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public double Prix { get => prix; set => prix = value; }
        public string Ville { get => ville; set => ville = value; }
    }
}
