using ChessLib;
using ChessLib.V2;
using ChessLib.V2.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProgram.Test
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestInitialBoardSetup()
        {
            IBoard board = new Board(8, 8);
            IList<Piece> pieces = board.GetAllPieces();
            Assert.AreEqual(0, pieces.Count);
        }

        [TestMethod]
        public void TestInitialBoardSetupParameters()
        {
            IBoard board = new Board(8, 8);
            Assert.AreEqual(1, board.MinDimension);
            Assert.AreEqual(8, board.MaxDimension);
            Assert.AreEqual(8, board.Dimension1);
            Assert.AreEqual(8, board.Dimension2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDimensionsOfBoardAreSame()
        {
            IBoard board = new Board(1, 8);
        }

        [TestMethod]
        public void TestBoardSetupByAddingPieces()
        {
            IBoard board = new Board(8, 8);

            Position position = new Position(1, 3);
            board.AddPieceAtPosition(position, new Knight(position));

            Position position1 = new Position(3, 3);
            board.AddPieceAtPosition(position1, new Bishop(position1));

            Position position2 = new Position(8, 8);
            board.AddPieceAtPosition(position2, new Queen(position2));

            IList<Piece> pieces = board.GetAllPieces();
            Assert.AreEqual(3, pieces.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBoardWillThrowExceptionWhenAddingPieceAtSamePosition()
        {
            IBoard board = new Board(8, 8);

            Position position = new Position(1, 3);
            board.AddPieceAtPosition(position, new Knight(position));

            Position position1 = new Position(1, 3);
            board.AddPieceAtPosition(position1, new Bishop(position1));
        }

        [TestMethod]
        public void TestBoardSportEmpty()
        {
            IBoard board = new Board(8, 8);

            Position position = new Position(1, 3);
            board.AddPieceAtPosition(position, new Knight(position));

            Position position1 = new Position(3, 3);
            board.AddPieceAtPosition(position1, new Bishop(position1));

            Assert.IsFalse(board.IsBoardSpotEmpty(position));
            Assert.IsTrue(board.IsBoardSpotEmpty(new Position(4, 3)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBoardPieceCannotBeMovedIfOccupied()
        {
            IBoard board = new Board(8, 8);

            Position position = new Position(1, 3);
            board.AddPieceAtPosition(position, new Knight(position));

            Position position1 = new Position(3, 3);
            board.AddPieceAtPosition(position1, new Bishop(position1));

            board.MovePieceToPosition(position, position1, board.GetPieceAtPosition(position));
        }

        [TestMethod]
        public void TestBoardPieceCanBeMovedIfSpotIsEmpty()
        {
            IBoard board = new Board(8, 8);

            Position position = new Position(1, 3);
            board.AddPieceAtPosition(position, new Knight(position));

            Position position1 = new Position(3, 3);
            board.AddPieceAtPosition(position1, new Bishop(position1));

            Piece piece = board.GetPieceAtPosition(position1);
            Position[] validPositions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();

            board.MovePieceToPosition(position1, validPositions[2], board.GetPieceAtPosition(position1));

            piece = board.GetPieceAtPosition(validPositions[2]);
            Assert.AreEqual(typeof(Bishop), piece.GetType());
        }
    }
}
