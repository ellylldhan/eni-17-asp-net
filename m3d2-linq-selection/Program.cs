using System;
using System.Collections.Generic;
using System.Linq;

namespace m3d2_linq_selection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M3 D2 - Linq : Selection");
            Console.WriteLine("Exemples des méthodes Linq permettant de sélectionner certains éléments dans une collection.");
            
            var personnes = new List<Personne>
            {
                new Personne{Age=32,Prenom="Marc"},
                new Personne{Age=33,Prenom="Jean"},
                new Personne{Age=28,Prenom="Mélanie"},
                new Personne{Age=32,Prenom="Simon"},
                new Personne{Age=33,Prenom="Hélène"},
                new Personne{Age=28,Prenom="Francis"}
            };
            
            // methode WHERE
            var moinsDeTrente = personnes.Where(p => p.Age < 30);
            
            // methode DISTINCT
            var agesUnique = personnes.Select(p => p.Age).Distinct();
            
            // methode TAKE
            var troisPremiers = personnes.Take(3);
        }
    }
}