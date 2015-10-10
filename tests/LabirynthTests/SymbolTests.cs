namespace LabirynthTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Common.Enum;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Models.Contracts;

    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void IsSybolFactoryReturnFilledSymbol()
        {
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace);
            Assert.ReferenceEquals(new FilledSpaceSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnCheckSymbol()
        {
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.Check);
            Assert.ReferenceEquals(new CheckSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnEmptySpaceSymbol()
        {
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace);
            Assert.ReferenceEquals(new EmptySpaceSymbol(), symbol);
        }

        [TestMethod]
        public void IsSybolFactoryReturnPlayerSymbol()
        {
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.Player);
            Assert.ReferenceEquals(new PlayerSymbol(), symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Wrong key for the SymbolFactory.GetSymbol(SymbolsEnum)")]
        public void IfSymbolFaltoryRecieveWrongTypeOfSymbol()
        {
            ISymbol symbol = SymbolFactory.GetSymbol(SymbolsEnum.Test);
        }
    }
}
