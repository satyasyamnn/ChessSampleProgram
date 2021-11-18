using System;
using System.Collections.Generic;

namespace ChessLib.V2
{
    public abstract class Piece 
    {
        public Piece(Position position)
        {
            CurrentPosition = position;
        }

        public int[,] PossibleMoves { get; protected set; }

        public virtual Position CurrentPosition { get; protected set; }

        public abstract IEnumerable<Position> GetValidMoves(int dimension1, int dimension2);

        public void SetNewPosition(Position newPosition)
        {
            CurrentPosition = newPosition;
        }

        protected Func<Position, int, int, bool> CheckForBoundaries = (position, dimension1, dimension2) =>
        {
            if (position.X > dimension2 || position.X < dimension1 || position.Y > dimension2 || position.Y < dimension1)
                return true;
            return false;
        };
    }
}
