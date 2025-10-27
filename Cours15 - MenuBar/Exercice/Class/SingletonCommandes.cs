using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Class
{
    internal class SingletonCommandes
    {
        ObservableCollection<Commande> listCommandes;
        private static SingletonCommandes? instance;

        private SingletonCommandes()
        {
            listCommandes = new ObservableCollection<Commande>()
            {
                new Commande(new DateTime(2025, 5, 1), "Alice Dupont", "alice@dupont.com", false),
                new Commande(new DateTime(2024, 2, 25), "Bob Martin", "bob@martin.com", true),
            };
        }

        public static SingletonCommandes GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonCommandes();
            }
            return instance;
        }
        
        public ObservableCollection<Commande> ListCommandes {
            get => listCommandes;
            set => listCommandes = value;
        }
    }
}
