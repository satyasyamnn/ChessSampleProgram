using System.Collections.Generic;

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
        bool IsBoardSpotEmpty(Position pos);
        Piece GetPieceAtPosition(Position pos);
        IList<Piece> GetAllPieces();
    }
}
