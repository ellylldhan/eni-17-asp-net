using System;
using System.Diagnostics;

namespace m2d7_function_action_lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("m2d7 - Function, Action & Expression Lambda");
            Console.WriteLine(
                "Cette démonstration permet de comprendre l’utilité des fonctions et actions, ainsi que le mécanisme des expressions lambda sous-jacent.");

            // Creation d'une function
            var joursAvantNoel = new Func<DateTime, int>(date =>
            {
                var noel = new DateTime(date.Year, 12, 25);
                return (noel - date).Days;
            });

            // Utilisation 
            var jours = joursAvantNoel(DateTime.Now);
            Console.WriteLine("FUNC   - Jours restant avant Noyel : " + jours);

            // Creation d'une Action pour le même objectif
            var joursAvantNoelAction = new Action<DateTime>(date =>
            {
                var noel = new DateTime(date.Year, 12, 25);
                Console.WriteLine("ACTION - Jours restant avant Noyel : " + (noel - date).Days);
            });
            joursAvantNoelAction(DateTime.Now);
        }
    }
}