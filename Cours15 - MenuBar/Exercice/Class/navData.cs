using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Class
{
    internal class navData
    {
        public Commande Commande { get; set; }
        public Produit Produit { get; set; }
        public List<Commande> listCommandes { get; set; }
        public List<Produit> listProduits { get; set; }
    }
}
