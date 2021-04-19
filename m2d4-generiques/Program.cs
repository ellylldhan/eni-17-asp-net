using System;
using m2d4_generiques.bo;

namespace m2d4_generiques
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M02 D04 - Les Génériques");
            Fourmi fourmi = new Fourmi();
            Fruit fruit = new Fruit {DateCueillette = DateTime.Now.AddDays(-5)};
            Zoo.NourrirAnimal(fourmi, fruit);

            Chat chat = new Chat();
            Pate pate = new Pate {DatePeremption = DateTime.Now.AddYears(1)};
            Zoo.NourrirAnimal(chat, pate);

            //Console.ReadKey();
        }
    }
}