using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Classes
{
    internal class Album
    {
        string nom;
        string auteur;
        string label;
        string couverture;

        public Album(string nom, string auteur, string label, string couverture)
        {
            this.nom = nom;
            this.auteur = auteur;
            this.label = label;
            this.couverture = couverture;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Label { get => label; set => label = value; }
        public string Couverture { get => couverture; set => couverture = value; }

    }
}
