using m2d4_generiques.interfaces;

namespace m2d4_generiques.bo
{
    public static class Zoo
    {
        public static bool NourrirAnimal<A, N>(A animal, N aliment) where N : Nourriture where A : Animal<N>
        {
            return animal.SeNourrir(aliment);
        }
    }
}