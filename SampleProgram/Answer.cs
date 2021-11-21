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
        Position knightPosition;
        Position bishopPosition;
        Position queenPosition;

        private readonly Random _rnd = new Random();

        public ComplexGame()
        {
            Setup();
        }

        public void Setup()
        {
            board = new Board(8, 8);

            knightPosition = new Position(3, 3);
            bishopPosition = new Position(6, 8);
            queenPosition = new Position(3, 5);

            board.AddPieceAtPosition(knightPosition, new Knight(knightPosition));
            board.AddPieceAtPosition(bishopPosition, new Bishop(bishopPosition));
            board.AddPieceAtPosition(queenPosition, new Queen(queenPosition));
        }

        public void Play(int moves)
        {
            Piece knight = board.GetPieceAtPosition(knightPosition);
            Piece bishop = board.GetPieceAtPosition(bishopPosition);
            Piece queen = board.GetPieceAtPosition(queenPosition);

            for (var move = 1; move <= moves; move++)
            {
                Move(knight);
                Move(bishop);
                Move(queen);
            }
        }

        private void PrintPossiblePositions(Piece piece)
        {
            var possibleMoves = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Console.WriteLine("======================================================");
            Console.WriteLine("Possible Moves");
            foreach (Position pos in possibleMoves)
            {
                Console.WriteLine("{1}: My position is {0}", pos, piece.GetType());
            }
            Console.WriteLine("======================================================");
        }

        private void Move(Piece piece)
        {
            PrintPossiblePositions(piece);
            var possibleMoves = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            bool retry = true;
            while (retry)
            {
                Position newPosition = possibleMoves[_rnd.Next(possibleMoves.Length)];

                if (piece.IsCurrentPositionSameAsNewPosition(newPosition))
                    continue;

                if (board.IsBoardSpotEmpty(newPosition))
                {
                    Console.WriteLine("======================================================");
                    Console.WriteLine("{1}: Current position {0}", piece.CurrentPosition, piece.GetType());
                    Console.WriteLine("{1}: Moving to position {0}", newPosition, piece.GetType());
                    board.MovePieceToPosition(piece.CurrentPosition, newPosition, piece);
                    Console.WriteLine("{1}: After movement new position {0}", piece.CurrentPosition, piece.GetType());
                    Console.WriteLine("======================================================");
                    retry = false;
                }
                else
                {
                    Console.WriteLine(" Retrying as spot is occupied by {0}", piece.GetType());
                    retry = true;
                }
            }
        }
    }
}
