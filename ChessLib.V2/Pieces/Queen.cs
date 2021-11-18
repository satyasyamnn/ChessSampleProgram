using System.Collections.Generic;

namespace ChessLib.V2.Pieces
{
    public class Queen : Piece
    {
        public Queen(Position position): base(position)
        {
            PossibleMoves = new[,] { { -1, -1 }, { -1, +1 }, { +1, -1 }, { +1, +1 }, { -1, 0 }, { +1, 0 }, { 0, -1 }, { 0, +1 } };
        }

        public override IEnumerable<Position> GetValidMoves(int dimension1, int dimension2)
        {
            for (var i = 0; i <= PossibleMoves.GetUpperBound(0); i++)
            {
                int newX = CurrentPosition.X;
                int newY = CurrentPosition.Y;
                while (true)
                {
                    newX += PossibleMoves[i, 0];
                    newY += PossibleMoves[i, 1];
                    Position position = new Position(newX, newY);
                    if (CheckForBoundaries(position, dimension1, dimension2))
                        break;
                    yield return new Position(newX, newY);
                }
            }
        }
    }
}
