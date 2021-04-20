using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using tp2_linq_correction.Models;
using tp2_linq_correction.Utils;

namespace tp2_linq_correction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module 3 TP Correction - Linq (TP2)");

            // Q1 : Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            // var auteursCommenceParG = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));
            Console.WriteLine("\nQ1 - commence par G");

            var q1 = FakeDb.Instance.Auteurs.Where(x => x.Nom.StartsWith("G")).Select(x => x.Prenom);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

            // Q2 : Afficher l’auteur ayant écrit le plus de livres
            // var auteurPlusProlifique = ListeLivres
            //     .GroupBy(l => l.Auteur)
            //     .OrderByDescending(g => g.Count())
            //     .FirstOrDefault()
            //     .Key;
            Console.WriteLine("\nQ2 - auteur le plus prolifique");

            IGrouping<Models.Auteur, Models.Livre> q2 = FakeDb.Instance.Livres
                .GroupBy(x => x.Auteur)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();

            Console.WriteLine($"{q2.Key.Nom} {q2.Key.Prenom}");

            // Methode 2
            Console.WriteLine("\nQ2 bis");

            List<IGrouping<Models.Auteur, Models.Livre>> dataQ2 = FakeDb.Instance.Livres
                .GroupBy(x => x.Auteur)
                .Where(x => x.Count() == FakeDb.Instance.Livres
                    .GroupBy(y => y.Auteur)
                    .Max(y => y.Count())
                ).ToList();

            foreach (var item in dataQ2)
            {
                Console.WriteLine($"{item.Key.Nom} {item.Key.Prenom}");
            }

            // Q3 : Afficher le nombre moyen de pages par livre par auteur
            // foreach (var item in livresParAuteur)
            // {
            //     Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} : {item.Average(l => l.NbPages)} pages en moyenne");
            // }
            Console.WriteLine("\nQ3 - nb pages moyen par auteur & livre");

            FakeDb.Instance.Livres
                .GroupBy(x => x.Auteur)
                .ToList()
                .ForEach(x =>
                {
                    Console.Write($"Moyenne {x.Key.Nom} {x.Key.Prenom} : ");
                    Console.WriteLine($"{x.Average(y => y.NbPages)} pages");
                });

            // Q4 : Afficher le titre du livre avec le plus de pages
            // var livreMaxPages = ListeLivres.OrderByDescending(l => l.NbPages).First();
            // Console.WriteLine($"Livre avec le plus de pages : \"{livreMaxPages.Titre}\" ({livreMaxPages.NbPages} pages)\n");
            Console.WriteLine("\nQ4 - livre avec le + de pages");

            var q4 = FakeDb.Instance.Livres
                .Where(l => l.NbPages == FakeDb.Instance.Livres
                    .Max(l2 => l2.NbPages));

            foreach (var item in q4)
            {
                Console.WriteLine($"{item.Titre}");
            }

            // Q5 : Afficher combien ont gagné les auteurs en moyenne(moyenne des factures)
            // var moyenne = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine("\nQ5 - gain moyen des auteurs, en moyenne (!)");

            Console.WriteLine(FakeDb.Instance.Auteurs
                .Where(a => a.Factures
                    .Count > 0)
                .Average(a => a.Factures
                    .Average(f => f.Montant)));

            // Q6 : Afficher les auteurs et la liste de leurs livres
            // var livresParAuteurs = ListeLivres
            //     .OrderBy(l => l.Titre)
            //     .ThenBy(l => l.Synopsis)
            //     .GroupBy(l => l.Auteur);
            //
            // foreach (var livres in livresParAuteurs)
            // {
            //     Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom}");
            //     foreach (var livre in livres)
            //     {
            //         Console.WriteLine($"\t\"{livre.Titre} - {livre.Synopsis}\"");
            //     }
            // }
            Console.WriteLine("\nQ6 - Biblio de chaque auteur");

            FakeDb.Instance.Livres
                .GroupBy(l => l.Auteur)
                .ToList()
                .ForEach((l) =>
                {
                    Console.WriteLine($"{l.Key.Nom} {l.Key.Prenom}");
                    l.ToList().ForEach((l2) => { Console.WriteLine($"\t{l2.Titre}"); });
                });

            // Q7 : Afficher les titres de tous les livres triés par ordre alphabétique
            // var livresTriAlpha = ListeLivres.OrderBy(l => l.Titre).ThenBy(l => l.Synopsis);
            Console.WriteLine("\nQ7 - Tri alpha des livres");

            FakeDb.Instance.Livres
                .Select(l => l.Titre)
                .OrderBy(l => l)
                .ToList()
                .ForEach(Console.WriteLine);

            // Q8 : Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            // var moyennePage = ListeLivres.Average(l => l.NbPages);
            // var livresSupMoyenne = ListeLivres
            //     .Where(l => l.NbPages > moyennePage)
            //     .OrderBy(l => l.Titre)
            //     .ThenBy(l => l.Synopsis);
            Console.WriteLine("\nQ8 - Livres dont nb pages est sup à la moyenne");

            FakeDb.Instance.Livres
                .Where(l => l.NbPages >= FakeDb.Instance.Livres
                    .Average(l2 => l2.NbPages))
                .Select(l => l.Titre)
                .ToList()
                .ForEach(Console.WriteLine);

            // Q9 : Afficher l'auteur ayant écrit le moins de livres
            // var auteurMoinsProlifique = ListeAuteurs
            //     .OrderBy(a => ListeLivres
            //         .Count(l => l.Auteur == a))
            //     .FirstOrDefault();
            // => (l'auteur avec 0 livres)
            Console.WriteLine("\nQ9 - Auteur avec le moins de livre (ayant au moins 1 livre)");

            FakeDb.Instance.Livres
                .GroupBy(l => l.Auteur)
                .Where(g => g.Count() == FakeDb.Instance.Livres
                    .GroupBy(l => l.Auteur)
                    .Min(g => g.Count()))
                .ToList()
                .ForEach(l => { Console.WriteLine($"{l.Key.Nom} {l.Key.Prenom}"); });
            Console.ReadLine();
        }
    }
}