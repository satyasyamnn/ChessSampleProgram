namespace ChessLib.V2
{
    public class Spot
    {
        public Spot(Position position, Piece piece)
        {
            Position = position;
            Piece = piece;
        }

        public Position Position { get; }

        public Piece Piece { get; }
    }
}
