using System;
using System.Collections.Generic;
using System.Linq;

namespace m3d1_linq_recuperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M3 D1 - Linq : Récupération ");
            Console.WriteLine("Exemples des méthodes Linq permettant de récupérer un seul élément.");

            // jeu de data
            var listeVide = new List<int>();
            var nombres = new List<int> {1, 2, 3, 4, 5, 5};

            // methode First
            var premier = nombres.First(); // premier=1
            var errorFirst = listeVide.First(); // System.InvalidOperationException
            var vide = nombres.FirstOrDefault(); // vide=null
            var deux = nombres.FirstOrDefault(n => n == 2); // deux=2
            var six = nombres.FirstOrDefault(n => n == 6); // six=null

            // methode Single
            var three = nombres.Single(n => n == 3); // three=3
            var errorSingle = nombres.Single(n => n == 5); // System.InvalidOperationException

            // methode Last
            var last = nombres.Last(); // last=5
        }
    }
}