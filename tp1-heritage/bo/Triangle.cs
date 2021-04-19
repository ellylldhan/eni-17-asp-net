using System;

namespace tp_heritage.bo
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }


        public override double Aire()
        {
            // (base * hauteur) / 2  Pour Triangle Rectangle
            // sqrt(p(p-a)(p-b)(p-c)) avec p le demi-périmètre
            var p = (A + B + C) / 2d;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double Perimetre()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return "Triangle de côtés A=" + A + ", B=" + B + ", C=" + C + "\nAire=" + Aire() + "\nPérimètre=" +
                   Perimetre() + "\n";
        }
    }
}