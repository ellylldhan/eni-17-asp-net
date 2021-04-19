using System;

namespace tp_heritage.bo
{
    public class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }


        public override double Aire()
        {
            return Longueur * Largeur;
        }

        public override double Perimetre()
        {
            return (Longueur + Largeur) * 2;
        }
        
        public override string ToString()
        {
            return "Rectangle de largeur="+Largeur + ", longueur=" + Longueur + "\nAire=" + Aire() + "\nPérimètre=" + Perimetre() + "\n";
        }
    }
}