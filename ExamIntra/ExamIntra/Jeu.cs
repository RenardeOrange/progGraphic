using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamIntra
{
    internal class Jeu
    {
        string titre;
        string compagnie;
        string sortie;
        string url;

        public Jeu()
        {
            titre = "Inconnu";
            compagnie = "Inconnu";
            sortie = "Inconnu";
            url = "Inconnu";
        }

        public Jeu(string titre, string compagnie, string sortie, string url)
        {
            this.titre = titre;
            this.compagnie = compagnie;
            this.sortie = sortie;
            this.url = url;
        }

        public string Titre { get => titre; set => titre = value; }
        public string Compagnie { get => compagnie; set => compagnie = value; }
        public string Sortie { get => sortie; set => sortie = value; }
        public string Url { get => url; set => url = value; }

        public override string ToString()
        {
            return $"{titre} - {compagnie} - {sortie} - {url}";
        }
    }
}
