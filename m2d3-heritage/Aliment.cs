using System;

namespace m2d3_heritage
{
    public abstract class Aliment
    {
        public DateTime DatePeremption { get; set; }

        public bool EstPerime()
        {
            return DateTime.Now > DatePeremption;
        }

        public abstract void Conserver();
    }
}