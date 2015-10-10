using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Models;
using Labyrinth.Logic.BoardSetupRules;

namespace LabirynthTests
{
    [TestClass]
    public class RulesTests
    {
        [TestMethod]
        public void IsStandartBoardSetupFillBoardWirhSymbols()
        {
            var board = Board.Instance;
            var rules = new StandartBoardSetup();
            rules.SetGame(board);
            bool result = true;
            for (int i = 0; i < board.Field.GetLength(0); i++)
            {
                for (int j = 0; j < board.Field.GetLength(1); j++)
                {
                    if (board.Field[i, j] == null)
                    {
                        result = false;
                        break;
                    }
                }
            }
            Assert.IsTrue(result);
        }
    }
}
