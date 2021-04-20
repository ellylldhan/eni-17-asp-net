using System;
using System.Collections.Generic;

namespace tp2_linq_correction.Models
{
    public class Facture
    {
        public Facture(Decimal montant, Auteur auteur)
        {
            this.Montant = montant;
            this.Auteur = auteur;
        }

        public Decimal Montant { get; set; }
        public Auteur Auteur { get; set; }
    }
}
