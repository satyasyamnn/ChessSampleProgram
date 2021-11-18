using System.Collections.Generic;

namespace ChessLib.V2.Pieces
{
    public class Knight : Piece
    {
        private KnightMove _knightMove;

        public Knight(Position position): base(position)
        {
            _knightMove = new KnightMove();
            PossibleMoves = KnightMove.Moves;
        }

        public override IEnumerable<Position> GetValidMoves(int dimension1, int dimension2)
        {
            return _knightMove.ValidMovesFor(CurrentPosition);
        }
    }
}