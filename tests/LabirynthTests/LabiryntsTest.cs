namespace LabirynthTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Models;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common.Enum;

    [TestClass]
    public class LabiryntsTest
    {
        [TestMethod]
        public void IsBoardInstaceIsSingle()
        {
            var board = Board.Instance;
            var board2 = Board.Instance;
            Assert.AreSame(board, board2);
        }

        [TestMethod]
        public void IsBoardAreSameSymbolReturnsRight()
        {
            var board = Board.Instance;
            Symbol symbol = new EmptySpaceSymbol();
            board.Field.SetValue(symbol, 2, 2);
            bool result = board.AreSymbolsEqual(2, 2, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsBoardReplaceSymbols()
        {
            var board = Board.Instance;
            Symbol symbolToReplace = new EmptySpaceSymbol();
            Symbol newSymbol = new FilledSpaceSymbol();
            board.Field.SetValue(symbolToReplace, 2, 2);
            board.ReplaceSymbol(2, 2, newSymbol);
            Assert.AreEqual(board.Field.GetValue(2, 2), newSymbol);
        }
    }
}
