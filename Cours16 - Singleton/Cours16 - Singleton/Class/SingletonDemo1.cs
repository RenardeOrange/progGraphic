using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours16___Singleton.Class
{
    internal class SingletonDemo1
    {
        string texte;
        static SingletonDemo1? instance;

        public SingletonDemo1()
        {
            texte = "Texte par défaut";
        }

        public static SingletonDemo1 GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonDemo1();
            }
            return instance;
        }

        public string Texte 
        { 
            get { return texte; } 
            set { texte = value; }
        }
    }
}
