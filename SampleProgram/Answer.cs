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

            var possibleMoves1 = piece1.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            foreach(Position pos in possibleMoves1)
            {
                Console.WriteLine("{1}: My position is {0}", pos, piece1.GetType());
            }
            Console.WriteLine("=================");

            var possibleMoves2 = piece2.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            foreach (Position pos in possibleMoves2)
            {
                Console.WriteLine("{1}: My position is {0}", pos, piece2.GetType());
            }

            Console.WriteLine("=================");
            var possibleMoves3 = piece3.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            foreach (Position pos in possibleMoves3)
            {
                Console.WriteLine("{1}: My position is {0}", pos, piece3.GetType());
            }
            Console.WriteLine("=================");

            for (var move = 1; move <= moves; move++)
            {
                pos1 = possibleMoves1[_rnd.Next(possibleMoves1.Length)];
                if (board.CanMoveToNewSpot(pos1))
                {
                    board.MovePieceToPosition(piece1.CurrentPosition, pos1, piece1);
                }
                else
                { 

                }
                pos2 = possibleMoves2[_rnd.Next(possibleMoves2.Length)];
                pos3 = possibleMoves3[_rnd.Next(possibleMoves3.Length)];
            }


            /*

            for (var move = 1; move <= moves; move++)
            {
                pos1 = possibleMoves1[_rnd.Next(possibleMoves1.Length)];
                Console.WriteLine("{2}-{1}: My position is {0}", pos1, move, piece1.GetType());
            }
            Console.WriteLine("=================");
            for (var move = 1; move <= moves; move++)
            {
                pos2 = possibleMoves2[_rnd.Next(possibleMoves2.Length)];
                Console.WriteLine("{2}-{1}: My position is {0}", pos2, move, piece2.GetType());
            }
            Console.WriteLine("=================");
            for (var move = 1; move <= moves; move++)
            {
                pos3 = possibleMoves3[_rnd.Next(possibleMoves3.Length)];
                Console.WriteLine("{2}-{1}: My position is {0}", pos3, move, piece3.GetType());
            }
            Console.WriteLine("=================");
            */
        }
    }

}
