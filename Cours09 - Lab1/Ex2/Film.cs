using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class Film
    {
        string titre;
        string affiche;

        public Film()
        {
            titre = "Inconnu";
            affiche = "inconnu.jpg";
        }
        public Film(string titre, string affiche)
        {
            this.titre = titre;
            this.affiche = affiche;
        }
        public string Titre { get => titre; set => titre = value; }
        public string Affiche { get => affiche; set => affiche = value; }

        public override string? ToString()
        {
            return Titre;
        }
    }
}
