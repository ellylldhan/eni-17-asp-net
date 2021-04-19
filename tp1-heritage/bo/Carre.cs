using System;
using System.Reflection.Metadata;

namespace tp_heritage.bo
{
    public class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double Aire()
        {
            return Longueur * Longueur;
        }

        public override double Perimetre()
        {
            return Longueur * 4;
        }
        
        public override string ToString()
        {
           return "Carré de côté=" + Longueur + "\nAire=" + Aire() + "\nPérimètre=" + Perimetre() + "\n";
        }
    }
}