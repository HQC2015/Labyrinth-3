using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Common.Enum;
using Labyrinth.Models.Symbols;

namespace LabirynthTests
{
    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void IsSybolFactoryReturnFilledSymbol()
        {
            var symbol = SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace);
            Assert.ReferenceEquals(new FilledSpaceSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnCheckSymbol()
        {
            var symbol = SymbolFactory.GetSymbol(SymbolsEnum.Check);
            Assert.ReferenceEquals(new CheckSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnEmptySpaceSymbol()
        {
            var symbol = SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace);
            Assert.ReferenceEquals(new EmptySpaceSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnPlayerSymbol()
        {
            var symbol = SymbolFactory.GetSymbol(SymbolsEnum.Player);
            Assert.ReferenceEquals(new PlayerSymbol(), symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Wrong key for the SymbolFactory.GetSymbol(SymbolsEnum)")]
        public void IfSymbolFaltoryRecieveWrongTypeOfSymbol()
        {
            var symbol = SymbolFactory.GetSymbol(SymbolsEnum.Test);
        }
    }
}
