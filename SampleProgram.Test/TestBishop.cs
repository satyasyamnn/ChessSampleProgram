using ChessLib;
using ChessLib.V2;
using ChessLib.V2.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SampleProgram.Test
{
    [TestClass]
    public class TestBishop
    {
        [TestMethod]
        public void TestBishopValidMoves()
        {
            IBoard board = new Board(8, 8);
            Piece piece = new Bishop(new Position(3, 3));
            Position[] positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(11, positions.Length);

            piece = new Bishop(new Position(8, 8));
            positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(7, positions.Length);

            piece = new Bishop(new Position(1, 1));
            positions = piece.GetValidMoves(board.MinDimension, board.MaxDimension).ToArray();
            Assert.IsNotNull(positions);
            Assert.AreEqual(7, positions.Length);
        }
    }
}
