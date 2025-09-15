using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours08
{
    internal class Client
    {
        string nom;
        int age;

        public Client()
        {
            nom = "Inconnu";
            age = 0;
        }

        public Client(string nom, int age)
        {
            this.nom = nom;
            this.age = age;
        }

        public string Nom { get => nom; set => nom = value; }
        public int Age { get => age; set => age = value; }

        public override string? ToString()
        {
            return $"{nom} - {age}";
        }
    }
}
