using System;
using m2d4_generiques.interfaces;

namespace m2d4_generiques.bo
{
    public class Fruit : Nourriture
    {
        public DateTime DateCueillette { get; set; }

        public bool EstPerime()
        {
            return (DateTime.Now - DateCueillette).Days > 10;
        }
    }
}