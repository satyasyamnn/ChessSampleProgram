using ChessLib;
using ChessLib.V2;
using ChessLib.V2.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SampleProgram.Test
{
    [TestClass]
    public class TestFixture1Old
    {
        [TestMethod]
        public void TestKnightMoveFromInsideBoard()
        {
            Board board = new Board(8, 8);
            Position ps1 = new Position(4, 3);
            board.AddPieceAtPosition(ps1, new Knight(ps1));

            Position ps2 = new Position(1, 1);
            board.AddPieceAtPosition(ps2, new Bishop(ps2));

            Position ps3 = new Position(8, 8);
            board.AddPieceAtPosition(new Position(8, 8), new Queen(ps3));


            var knight = board.GetPieceAtPosition(new Position(4, 3));
            var bishop = board.GetPieceAtPosition(new Position(1, 1));
            var queen = board.GetPieceAtPosition(new Position(8, 8));

            var moves = knight.GetValidMoves(board.MaxDimension, board.MinDimension).ToArray();
            Assert.IsNotNull(moves);
            Assert.AreEqual(8, moves.Length);

            moves = bishop.GetValidMoves(board.MaxDimension, board.MinDimension).ToArray();
            Assert.IsNotNull(moves);
            Assert.AreEqual(8, moves.Length);

            moves = queen.GetValidMoves(board.MaxDimension, board.MinDimension).ToArray();
            Assert.IsNotNull(moves);
            Assert.AreEqual(8, moves.Length);

            //Assert.AreEqual(11, moves.Length);
            //Assert.AreEqual(27, moves.Length);

            //foreach (var move in moves)
            //{
            //    switch (Math.Abs(move.X - pos.X))
            //    {
            //        case 1:
            //            Assert.AreEqual(2, Math.Abs(move.Y - pos.Y));
            //            break;
            //        case 2:
            //            Assert.AreEqual(1, Math.Abs(move.Y - pos.Y));
            //            break;
            //        default:
            //            Assert.Fail();
            //            break;
            //    }
            //}
        }

        [TestMethod]
        public void TestKnightMoveFromCorner()
        {
            //var pos = new Position(1, 1);
            //var knight = new Knight();

            //var moves = new HashSet<Position>(knight.GetValidMoves(1, 8, pos));

            //Assert.IsNotNull(moves);
            //Assert.AreEqual(2, moves.Count);

            //var possibles = new[] {new Position(2, 3), new Position(3, 2)};

            //foreach (var possible in possibles)
            //{
            //    Assert.IsTrue(moves.Contains(possible));
            //}
        }

        [TestMethod]
        public void TestPosition()
        {
            var pos = new Position(1, 1);
            Assert.AreEqual(1, pos.X);
            Assert.AreEqual(1, pos.Y);

            var pos2 = new Position(1, 1);

            Assert.AreEqual(pos, pos2);
        }
    }
}
