using ChessLib;
using ChessLib.V2;
using ChessLib.V2.Pieces;
using System;
using System.Linq;

namespace SampleProgram
{

    public class ComplexGame
    {
        IBoard board;
        Position pos1;
        Position pos2;
        Position pos3;

        private readonly Random _rnd = new Random();

        public ComplexGame()

        {
            board = new Board(8, 8);
            pos1 = new Position(3, 3);
            pos2 = new Position(1, 3);
            pos3 = new Position(3, 1);
            board.ResetBoard();
        }

        public void Setup()
        {
            board.AddPieceAtPosition(pos1, new Knight(pos1));
            board.AddPieceAtPosition(pos2, new Bishop(pos2));
            board.AddPieceAtPosition(pos3, new Queen(pos3));
        }

        public void Play(int moves)
        {
            Piece piece1 = board.GetPieceAtPosition(pos1);
            Piece piece2 = board.GetPieceAtPosition(pos2);
            Piece piece3 = board.GetPieceAtPosition(pos3);

            PrintPossiblePositions(piece1);
            PrintPossiblePositions(piece2);
            PrintPossiblePositions(piece3);


            for (var move = 1; move <= moves; move++)
            {
                Move(piece1);
                Move(piece2);
                Move(piece3);
            }
        }

        private void PrintPossiblePositions(Piece piece)
        {
            var possibleMoves = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            foreach (Position pos in possibleMoves)
            {
                Console.WriteLine("{1}: My position is {0}", pos, piece.GetType());
            }
            Console.WriteLine("=================");
        }

        private void Move(Piece piece)
        {
            var possibleMoves = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            bool retry = true;
            while (retry)
            {
                Position newPosition = possibleMoves[_rnd.Next(possibleMoves.Length)];
                if (board.CanMoveToNewSpot(newPosition))
                {
                    board.MovePieceToPosition(piece.CurrentPosition, newPosition, piece);
                    retry = false;
                }
                else
                {
                    Console.WriteLine(" Retrying as spot is blocked for {0}", piece.GetType());
                    retry = true;
                }
            }
        }
    }
}
