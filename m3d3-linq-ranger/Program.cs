using System;
using System.Collections.Generic;
using System.Linq;

namespace m3d3_linq_ranger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(
                "Exemples des méthodes Linq permettant de ranger une collection, transformer une collection et vérifier des conditions sur une collection");

            // jeu de data
            var listeDeRues = new List<Rue>
            {
                new Rue {Nom = "Rue des Lilas", Numero = 1},
                new Rue {Nom = "Rue des Monts", Numero = 3},
                new Rue {Nom = "Rue des Monts", Numero = 24},
                new Rue {Nom = "Rue des Lilas", Numero = 50},
                new Rue {Nom = "Rue des Lilas", Numero = 110},
                new Rue {Nom = "Rue des Asperges", Numero = 5},
                new Rue {Nom = "Rue des Xylophones", Numero = 48}
            };

            // tri por ordre alpha des noms de rue
            var orderedByName = listeDeRues.OrderBy(r => r.Nom);

            // tri par ordre desc des numeros de rues
            var orderedByNumber = listeDeRues.OrderByDescending(r => r.Numero);

            // tri par ordre alpha des noms de rue puis par numéro de rue croissant
            var orderedStreet = listeDeRues.OrderBy(r => r.Nom).ThenBy(r => r.Numero);

            // tri par ordre asc des numeros de rue
            listeDeRues.Sort((r1, r2) => r1.Numero - r2.Numero);

            // Tests 
            // Tous les numéros de rues sont-ils inférieurs à 200 ?
            if (listeDeRues.All(r => r.Numero < 200)) ;
            {
                Console.WriteLine("Tous les numéros de rues sont inférieurs à 200");
            }

            // Au moins une rue répondant à la condition donnée ?
            if (listeDeRues.All(r => r.Numero < 100 && r.Numero > 50))
            {
                Console.WriteLine("Il y a des rues entre 50 et 100");
            }

            // Transformation de la collection
            var numeros = listeDeRues.Select(r => r.Numero).Distinct();

            // Test
            var appartements = new List<Appartement>
            {
                new Appartement
                {
                    Numero = 1,
                    Pieces = new List<Piece>
                    {
                        new Piece {TypePiece = "Cuisine", Surface = 5},
                        new Piece {TypePiece = "Salon", Surface = 15},
                        new Piece {TypePiece = "Chambre", Surface = 10}
                    }
                },
                new Appartement
                {
                    Numero = 2,
                    Pieces = new List<Piece>
                    {
                        new Piece {TypePiece = "Cuisine", Surface = 4},
                        new Piece {TypePiece = "Salon", Surface = 21},
                        new Piece {TypePiece = "Chambre", Surface = 9}
                    }
                },
                new Appartement
                {
                    Numero = 3,
                    Pieces = new List<Piece>
                    {
                        new Piece {TypePiece = "Cuisine", Surface = 6},
                        new Piece {TypePiece = "Salon", Surface = 19},
                        new Piece {TypePiece = "Chambre", Surface = 8}
                    }
                },
                new Appartement
                {
                    Numero = 4,
                    Pieces = new List<Piece>
                    {
                        new Piece {TypePiece = "Cuisine", Surface = 8},
                        new Piece {TypePiece = "Salon", Surface = 30},
                        new Piece {TypePiece = "Chambre", Surface = 12}
                    }
                }
            };

            // Extraction
            // Renvoie la liste de toutes les pieces indépendamment de l'appartement
            var pieces = appartements.SelectMany(a => a.Pieces);

            foreach (var piece in pieces)
            {
                Console.WriteLine(piece);
            }
        }
    }
}