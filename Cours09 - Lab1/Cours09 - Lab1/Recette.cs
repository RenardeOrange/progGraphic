using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours09___Lab1
{
    internal class Recette: INotifyPropertyChanged
    {

        string titre;
        string categorie;
        string duree;
        string description;
        string urlImage;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Recette() {
            this.titre = "Inconnu";
            this.categorie = "Inconnu";
            this.duree = "Inconnu";
            this.description = "Inconnu";
            this.urlImage = "https://booth.pximg.net/c/620x620/b111d495-44ec-4d5e-8b54-f1b3fd0e7c25/i/6665923/686f2da3-430e-43f2-97d8-0541c74cef2a_base_resized.jpg";
        }

        public Recette(string titre, string categorie, string duree, string description, string urlImage)
        {
            this.titre = titre;
            this.categorie = categorie;
            this.duree = duree;
            this.description = description;
            this.urlImage = urlImage;
        }

        public string Titre { get => titre; set
            {
                titre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Titre)));
            }
        }
        public string Categorie { get => categorie; set
            {
                categorie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categorie)));
            }
        }
        public string Duree { get => duree; set
            {
                duree = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Duree)));
            }
        }
        public string Description { get => description; set
            {
                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        public string UrlImage { get => urlImage; set
            {
                urlImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UrlImage)));
            }
        }

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
            return base.ToString();
        }
    }
}
