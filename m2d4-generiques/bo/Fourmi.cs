using System;
using m2d4_generiques.interfaces;

namespace m2d4_generiques.bo
{
    public class Fourmi: Animal<Fruit>
    {
        public bool SeNourrir(Fruit aliment)
        {
            if (aliment.EstPerime())
            {
                return false;
            }

            Console.WriteLine("La fourmi mange un fruit");
            return true;
        }
    }
}