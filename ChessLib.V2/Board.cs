using System;

namespace ChessLib.V2
{
    public interface IBoard
    {
        int Dimension1 { get; }
        int Dimension2 { get; }
        int MinDimension { get; }
        int MaxDimension { get; }
        void ResetBoard();
        void AddPieceAtPosition(Position pos, Piece piece);
        void MovePieceToPosition(Position currentPosition, Position newPosition, Piece piece);
        bool CanMoveToNewSpot(Position pos);
        Piece GetPieceAtPosition(Position pos);
    }

    public class Board : IBoard
    {
        private Spot[,] _boxes;

        public Board(int dim1, int dim2)
        {
            Dimension1 = dim1;
            Dimension2 = dim2;
            ResetBoard();
        }

        public void ResetBoard()
        {
            if (Dimension1 != Dimension2)
                throw new ArgumentException("Invalid dimensions passed. Dimensions should be same");
            MaxDimension = Dimension1;
            MinDimension = 1;
            _boxes = new Spot[Dimension1, Dimension2];
        }

        public void AddPieceAtPosition(Position pos, Piece piece)
        {
            pos = GetAdjustedPosition(pos);
            int x = pos.X;
            int y = pos.Y;
            Spot currentSpot = _boxes[x, y];
            if (currentSpot == null)
            {
                Spot spot = new Spot(pos, piece);
                _boxes[x, y] = spot;
            }
            else
            {
                throw new ArgumentException("Spot is filled. Please use another spot");
            }
        }

        public void MovePieceToPosition(Position currentPosition, Position newPosition, Piece piece)
        {
            currentPosition = GetAdjustedPosition(currentPosition);
            newPosition = GetAdjustedPosition(newPosition);
            _boxes[currentPosition.X, currentPosition.Y] = null;
            Spot spot = new Spot(newPosition, piece);
            _boxes[newPosition.X, newPosition.Y] = spot;
        }

        public Piece GetPieceAtPosition(Position pos)
        {
            pos = GetAdjustedPosition(pos);
            Spot currentSpot = _boxes[pos.X, pos.Y];
            return currentSpot.Piece;
        }

        public bool CanMoveToNewSpot(Position pos)
        {
            pos = GetAdjustedPosition(pos);
            int x = pos.X;
            int y = pos.Y;
            Spot currentSpot = _boxes[x, y];
            return currentSpot == null;
        }

        public int Dimension1 { get; private set; }

        public int Dimension2 { get; private set; }

        public int MinDimension { get; private set; }

        public int MaxDimension { get; private set; }

        private Position GetAdjustedPosition(Position pos)
        {
            int x = pos.X - 1;
            int y = pos.Y - 1;
            return new Position(x, y);
        }
    }
}
