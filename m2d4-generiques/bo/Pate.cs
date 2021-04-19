using System;
using m2d4_generiques.interfaces;

namespace m2d4_generiques.bo
{
    public class Pate : Nourriture
    {
        public DateTime DatePeremption { get; set; }

        public bool EstPerime()
        {
            return DatePeremption < DateTime.Now;
        }
    }
}