using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;
using tp2_linq.bo;
using Console = System.Console;

namespace tp2_linq
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));

            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(
                new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010",
                ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1),
                216));

            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Module 3 TP2 - Linq");
            Console.WriteLine("Le but de ce TP est de réaliser différentes statistiques sur un jeu de donnée au " +
                              "moyen de requêtes Linq.");
            Console.WriteLine("*************************************");

            InitialiserDatas();

            // Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            Console.WriteLine("---------------------------------------------------------");

            var auteurCommenceParG = ListeAuteurs.Where(a => a.Nom.StartsWith("G")); //.Select(a=> a.Prenom);
            foreach (var auteur in auteurCommenceParG)
            {
                Console.WriteLine($"Prénom d'un auteur dont le nom commence par G : {auteur.Prenom} ({auteur.Nom})");
            }

            Console.WriteLine();

            // Afficher l’auteur ayant écrit le plus de livres
            Console.WriteLine("---------------------------------------------------------");

            var auteurPlusProlifique = ListeLivres
                .GroupBy(l => l.Auteur)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()
                .Key;
            Console.WriteLine(
                $"Auteur le plus prolifique : {auteurPlusProlifique.Prenom} {auteurPlusProlifique.Nom}\n");

            // Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine("---------------------------------------------------------");

            var livresParAuteur = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine("Nombre moyen de pages par livre, par auteur : ");
            foreach (var item in livresParAuteur)
            {
                Console.WriteLine($"\t{item.Key.Prenom} {item.Key.Nom}\t: " +
                                  $"{item.Average(l => l.NbPages)} pages en moyenne");
            }

            Console.WriteLine();

            // Afficher le titre du livre avec le plus de pages
            Console.WriteLine("---------------------------------------------------------");

            var livreMaxPages = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine($"Livre avec le plus de pages : " +
                              $"\"{livreMaxPages.Titre}\" ({livreMaxPages.NbPages} pages)\n");

            // Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            Console.WriteLine("---------------------------------------------------------");

            var moyenne = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine($"Les auteurs ont gagné en moyenne {moyenne} brouzoufs");
            Console.WriteLine();

            // Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Bibliographie de chaque auteur :".ToUpper());

            var livresParAuteurs = ListeLivres
                .OrderBy(l => l.Titre)
                .ThenBy(l => l.Synopsis)
                .GroupBy(l => l.Auteur);

            foreach (var livres in livresParAuteurs)
            {
                Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom}");
                foreach (var livre in livres)
                {
                    Console.WriteLine($"\t\"{livre.Titre} - {livre.Synopsis}\"");
                }
            }

            Console.WriteLine();

            // Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine("---------------------------------------------------------");

            var livresTriAlpha = ListeLivres.OrderBy(l => l.Titre).ThenBy(l => l.Synopsis);
            Console.WriteLine("Livres triés par titre :");
            foreach (var livre in livresTriAlpha)
            {
                Console.WriteLine($"\t\"{livre.Titre} - {livre.Synopsis}\"");
            }

            // Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            Console.WriteLine("---------------------------------------------------------");
            var moyennePage = ListeLivres.Average(l => l.NbPages);
            var livresSupMoyenne = ListeLivres
                .Where(l => l.NbPages > moyennePage)
                .OrderBy(l => l.Titre)
                .ThenBy(l => l.Synopsis);

            Console.WriteLine(
                $"Livres dont le nombre de pages est supérieur à la moyenne, soit env. {Math.Round(moyennePage)} pages : ");
            foreach (var livre in livresSupMoyenne)
            {
                Console.WriteLine($"\t\"{livre.Titre} - {livre.Synopsis}\" ({livre.NbPages} pages)");
            }

            Console.WriteLine();

            // Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("---------------------------------------------------------");

            /* MARCHE PAS
             ************
            var moinsPublie = ListeLivres
                .GroupBy(l => l.Auteur)
                .OrderBy(l => l.Count())
                .FirstOrDefault();
            
                foreach (var livre in moinsPublie)
                {
                    Console.WriteLine(livre.Key.Nom);
                }
            */

            /*
             * select a.nom, count(l.titre) from auteur a 
             * left outer join livre l on a.id = l.id_auteur
             * group by a.nom
             * order by count(l.titre)
             * limit 1
             */

            // SOLUTION
            var auteurMoinsProlifique = ListeAuteurs
                .OrderBy(a => ListeLivres.Count(l => l.Auteur == a))
                .FirstOrDefault();
            Console.WriteLine("SOLUTION Auteur le moins prolifique : " +
                              $"{auteurMoinsProlifique.Nom} {auteurMoinsProlifique.Prenom}");
            Console.WriteLine("(le 5 en a ZERO !!)");
        }
    }
}