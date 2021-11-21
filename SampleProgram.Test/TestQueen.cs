using ChessLib;
using ChessLib.V2;
using ChessLib.V2.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SampleProgram.Test
{
    [TestClass]
    public class TestQueen
    {
        [TestMethod]
        public void TestQueenValidMoves()
        {
            IBoard board = new Board(8, 8);
            Piece piece = new Queen(new Position(3, 3));
            Position[] positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(25, positions.Length);

            piece = new Queen(new Position(8, 8));
            positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(21, positions.Length);

            piece = new Queen(new Position(1, 1));
            positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(21, positions.Length);
        }
    }
}
