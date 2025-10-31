using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Lab2.Classes
{
    internal class singletonListeAlbum
    {
        ObservableCollection<Album> listeAlbums;
        static singletonListeAlbum? instance;

        public singletonListeAlbum()
        {
            listeAlbums = new ObservableCollection<Album>{
                new Album("Album1", "Auteur1", "Label1", "https://th.bing.com/th/id/R.4eefb5a291d4f75b6a9511b27758c453?rik=1ODJBGXV791SaA&pid=ImgRaw&r=0"),
                new Album("Album2", "Auteur2", "Label2", "https://i.pinimg.com/736x/92/8c/6f/928c6f82c7aa0dd5d0807188106642ed.jpg"),
                new Album("Album3", "Auteur3", "Label3", "https://img.freepik.com/vecteurs-libre/modele-couverture-album-design-plat_52683-124189.jpg"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),
                new Album("Your new boyfriend", "Wilbur Soot", "Made with L O V E", "https://th.bing.com/th/id/OIP.jCUUzUcG9N9hP1fOxvSFDgHaHa?w=177&h=180&c=7&r=0&o=7&pid=1.7&rm=3"),

            };
        }

        public static singletonListeAlbum GetInstance()
        {
            if (instance == null)
            {
                instance = new singletonListeAlbum();
            }
            return instance;
        }

        public ObservableCollection<Album> ListeAlbums
        {
            get { return listeAlbums; }
            set { listeAlbums = value; }
        }

    }
}
