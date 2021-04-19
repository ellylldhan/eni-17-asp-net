namespace m2d3_heritage
{
    public class Cereale : Aliment,Emballage
    {
        public override void Conserver()
        {
            RangerDansLePlacard();
        }

        private void RangerDansLePlacard()
        {
            throw new System.NotImplementedException();
        }

        public void Ouvrir()
        {
        }

        public void Fermer()
        {
        }
        
        
    }
}