using System;

namespace m2d6_extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M2 D6 - Les Extensions");
            Console.WriteLine(
                "Cette démonstration permet de comprendre la création et l’utilisation des méthodes d’extension.");

            // Utilisation de la méthode d'extension
            var unNombre = 10;
            Console.WriteLine(unNombre + " est-il pair ? " + unNombre.EstPair());

            unNombre = 5;
            Console.WriteLine(unNombre + " est-il pair ? " + unNombre.EstPair());
        }
    }
}