namespace LabirynthTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Models;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Models.Contracts;
    using Labyrinth.Common.Enum;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void IsBoardInstaceIsSingle()
        {
            Board board = Board.Instance;
            Board board2 = Board.Instance;
            Assert.AreSame(board, board2);
        }

        [TestMethod]
        public void IsBoardAreSameSymbolForEmptySymbol()
        {
            Board board = Board.Instance;
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.Player);
            board.Field.SetValue(symbol, 2, 2);
            bool result = board.AreSymbolsEqual(2, 2, SymbolFactory.GetSymbol(SymbolsEnum.Player));
            Assert.AreEqual(true, result);
        }

        //public void IsBoardAreSameSymbolForFilledSymbol()
        //{
        //    var board = Board.Instance;
        //    Symbol symbol = new FilledSpaceSymbol();
        //    board.Field.SetValue(symbol, 2, 2);
        //    bool result = board.AreSymbolsEqual(2, 2, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
        //    Assert.AreEqual(true, result);
        //}

        [TestMethod]
        public void IsBoardReplaceSymbols()
        {
            Board board = Board.Instance;
            Symbol symbolToReplace = new EmptySpaceSymbol();
            Symbol newSymbol = new FilledSpaceSymbol();
            board.Field.SetValue(symbolToReplace, 2, 2);
            board.ReplaceSymbol(2, 2, newSymbol);
            Assert.AreEqual(board.Field.GetValue(2, 2), newSymbol);
        }

        [TestMethod]
        public void IsScoreboardInstaceIsSingle()
        {
            Scoreboard board = Scoreboard.Instance;
            Scoreboard board2 = Scoreboard.Instance;
            Assert.AreSame(board, board2);
        }
    }
}