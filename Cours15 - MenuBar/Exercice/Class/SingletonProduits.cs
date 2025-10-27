using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Class
{
    internal class SingletonProduits
    {
        ObservableCollection<Produit> listProduits;
        private static SingletonProduits? instance;

        private SingletonProduits()
        {
            listProduits = new ObservableCollection<Produit>()
            {
                new Produit("Tronçonneuse", 130.22, false, "jardin", "https://www.tronconneuse-electrique.net/wp-content/uploads/2024/01/Comment-fonctionne-une-tronconneuse-electrique-Black-et-Decker-vue-eclatee-.png"),
                new Produit("Ordinateur Portable", 299.99, true, "informatique", "https://th.bing.com/th/id/R.167666ddade74bd852dbc6520c0d9492?rik=rXVPHdta3nkJmg&pid=ImgRaw&r=0"),
            };
        }

        public static SingletonProduits GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonProduits();
            }
            return instance;
        }

        public ObservableCollection<Produit> ListProduits
        {
            get => listProduits;
            set => listProduits = value;
        }
    }
}
