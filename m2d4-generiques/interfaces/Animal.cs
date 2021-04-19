namespace m2d4_generiques.interfaces
{
    public interface Animal<T> where T : Nourriture
    {
        bool SeNourrir(T aliment);
    }
}