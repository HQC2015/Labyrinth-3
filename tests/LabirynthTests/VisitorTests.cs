namespace LabirynthTests
{
    using Labyrinth.Common.Enum;
    using Labyrinth.Models;
    using Labyrinth.Models.Players;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Models.Visitors;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VisitorTests
    {
        [TestMethod]
        public void IsStandartVisitorSetRightPlayerStatsWhenCoomandDown()
        {
            var visitor = new StandartMoveVisitor();
            visitor.SetVisitCommand("d");
            PrivateObject po = new PrivateObject(visitor);
            var result = po.GetField("command");
            Assert.AreEqual("d", result);
        }

        [TestMethod]
        public void IsDiagonalMoveVisitorSetRightPlayerStatsWhenCoomandDown()
        {
            var visitor = new DiagonalMoveVisitor();
            visitor.SetVisitCommand("dl");
            PrivateObject po = new PrivateObject(visitor);
            var result = po.GetField("command");
            Assert.AreEqual("dl", result);
        }

        [TestMethod]
        public void IsStandartVisitorVisitWithCommandDown()
        {
            var visitor = new StandartMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(4, 3, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("d");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(4, player.GetX());
        }

        [TestMethod]
        public void IsStandartVisitorVisitthCommandUp()
        {
            var visitor = new StandartMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(2, 3, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("u");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(2, player.GetX());
        }

        [TestMethod]
        public void IsStandartVisitorVisitthCommandRight()
        {
            var visitor = new StandartMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(3, 4, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("r");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(4, player.GetY());
        }

        [TestMethod]
        public void IsStandartVisitorVisitthCommandLeft()
        {
            var visitor = new StandartMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(3, 2, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("l");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(2, player.GetY());
        }

        [TestMethod]
        public void IsStandartVisitorVisitWithCommandUpLeft()
        {
            var visitor = new DiagonalMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(2, 2, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("ul");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(2, player.GetX());
            Assert.AreEqual(2, player.GetY());
        }

        [TestMethod]
        public void IsStandartVisitorVisitWithCommandUpRight()
        {
            var visitor = new DiagonalMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(2, 4, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("ur");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(2, player.GetX());
            Assert.AreEqual(4, player.GetY());
        }

        [TestMethod]
        public void IsStandartVisitorVisitWithCommandDownRight()
        {
            var visitor = new DiagonalMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(4, 2, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("dl");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(4, player.GetX());
            Assert.AreEqual(2, player.GetY());
        }

        [TestMethod]
        public void IsStandartVisitorVisitWithCommandDownLeft()
        {
            var visitor = new DiagonalMoveVisitor();
            var player = new Player();
            var board = Board.Instance;
            board.ReplaceSymbol(4, 4, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            player.SetScore(0);
            player.SetX(3);
            player.SetY(3);

            visitor.SetVisitCommand("dr");
            visitor.Visit(player);

            Assert.AreEqual(1, player.GetScore());
            Assert.AreEqual(4, player.GetX());
            Assert.AreEqual(4, player.GetY());
        }
    }
}
