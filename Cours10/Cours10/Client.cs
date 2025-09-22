using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours10
{
    internal class Client: IEquatable<Client>, IComparable<Client>, INotifyPropertyChanged
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

        public string Nom { 
            get => nom; 
            set {
                nom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("nom"));
            }
        }
        public int Age
        {
            get => age;
            set {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("age"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public int CompareTo(Client? other)
        {
            return this.nom.CompareTo(other?.nom);
        }

        public bool Equals(Client? other)
        {
            if (this.nom.Equals(other?.Nom) && this.age == other?.Age)
                return true;
            else
                return false;
        }

        public override string? ToString()
        {
            return $"{nom} - {age}";
        }
    }
}
