using System;
using m2d4_generiques.interfaces;

namespace m2d4_generiques.bo
{
    public class Chat : Animal<Pate>
    {
        public bool SeNourrir(Pate aliment)
        {
            if (aliment.EstPerime())
            {
                return false;
            }

            Console.WriteLine("Le chat mange le délicieux pâté.");
            return true;
        }
    }
}