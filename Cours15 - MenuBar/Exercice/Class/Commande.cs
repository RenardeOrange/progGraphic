using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Class
{
    internal class Commande
    {
        int id;
        DateTime date;
        string nomClient;
        string courrielClient;
        bool terminee;
        public static class GlobalCounter
        {
            public static int Counter = 0; // Global variable
        }

        public Commande(DateTime date, string nomClient, string courrielClient, bool terminee)
        {
            GlobalCounter.Counter++;
            this.id = GlobalCounter.Counter;
            this.date = date;
            this.nomClient = nomClient;
            this.courrielClient = courrielClient;
            this.terminee = terminee;
        }

        public int Id { set { if (value.ToString().Length == 5) id = value; } get => id; }
        public DateTime Date { set => date = value; get => date; }
        public string NomClient { set => nomClient = value; get => nomClient; }
        public string CourrielClient { set => courrielClient = value; get => courrielClient; }
        public bool Terminee { set => terminee = value; get => terminee; }
    }
}
