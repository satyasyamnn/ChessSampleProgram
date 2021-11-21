using System;
using System.Collections.Generic;

namespace ChessLib.V2
{
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
            if (IsBoardSpotEmpty(newPosition))
            {
                currentPosition = GetAdjustedPosition(currentPosition);
                newPosition = GetAdjustedPosition(newPosition);
                _boxes[currentPosition.X, currentPosition.Y] = null;
                Spot spot = new Spot(newPosition, piece);
                _boxes[newPosition.X, newPosition.Y] = spot;
                piece.SetNewPosition(new Position(newPosition.X + 1, newPosition.Y + 1));
            }
            else
            {
                throw new ArgumentException("Spot is filled. Please use another spot");
            }
        }

        public Piece GetPieceAtPosition(Position pos)
        {
            pos = GetAdjustedPosition(pos);
            Spot currentSpot = _boxes[pos.X, pos.Y];
            if (currentSpot != null && currentSpot.Piece != null)
                return currentSpot.Piece;
            return null;
        }

        public bool IsBoardSpotEmpty(Position pos)
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

        public IList<Piece> GetAllPieces()
        {
            IList<Piece> pieces = new List<Piece>();
            for (int i = 0; i < Dimension1; i++)
            {
                for (int j = 0; j < Dimension2; j++)
                {
                    Spot spot = _boxes[i, j];
                    if (spot != null && spot.Piece != null)
                        pieces.Add(spot.Piece);
                }
            }
            return pieces;
        }
    }
}
