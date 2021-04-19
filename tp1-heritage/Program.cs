using System;
using System.Collections.Generic;
using tp_heritage.bo;

namespace tp_heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module 2 TP1 - Heritage");

            var formes = new List<Forme>();
            formes.Add(new Cercle {Rayon = 3});
            formes.Add(new Rectangle {Largeur = 3, Longueur = 4});
            formes.Add(new Carre {Longueur = 3});
            formes.Add(new Triangle {A = 4, B = 5, C = 6});

            foreach (var forme in formes)
            {
                Console.WriteLine(forme);
            }
        }
    }
}