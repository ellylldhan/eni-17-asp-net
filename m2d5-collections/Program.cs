using System;
using System.Collections.Generic;

namespace m2d5_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("m2d5 - Les Collections");
            
            // on crée une liste d'entier avec une capacité initiale de 100 éléments
            var list = new List<int>(100);
            
            // on affiche le nombre d'éléments actuellement dans la liste (0)
            Console.WriteLine(list.Count);
            
            // on affiche la capacité actuelle de la liste (100)
            Console.WriteLine(list.Capacity);
            
            // on ajoute des nombres à la liste
            list.Add(10);
            list.Add(99);
            list.Add(250);
            list.Add(701);
            
            // on affiche le nombre d'éléments actuellement dans la liste (4)
            Console.WriteLine(list.Count);
            
            // on vérifie si l'élément 250 est contenu dans la liste
            if (list.Contains(250))
            {
                Console.WriteLine("L'élément 250 est bien dans la liste");
            }
            
            // on retire l'élément 10 de la liste
            list.Remove(10);
            
        }
    }
}