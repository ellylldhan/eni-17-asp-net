namespace m3d3_linq_ranger
{
    public class Piece
    {
        public string TypePiece { get; set; }
        public int Surface { get; set; }

        public override string ToString()
        {
            return $"{TypePiece}, Surface: {Surface}m2";
        }
    }
}