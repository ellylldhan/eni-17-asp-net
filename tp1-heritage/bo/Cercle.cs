using System;
using System.Xml;

namespace tp_heritage.bo
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire()
        {
            return Math.PI * (Rayon * Rayon);
        }

        public override double Perimetre()
        {
            return 2 * Rayon * Math.PI;
        }
        
        public override string ToString()
        {
            return "Cercle de rayon=" + Rayon + "\nAire=" + Aire() + "\nPérimètre=" + Perimetre() + "\n";
        }
    }
}