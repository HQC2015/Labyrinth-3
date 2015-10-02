namespace Labyrinth.Models.Symbols
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Models.Contracts;
    using Labyrinth.Common.Enum;

    public class SymbolFactory
    {
        private readonly Dictionary<SymbolsEnum, ISymbol> symbols = new Dictionary<SymbolsEnum, ISymbol>();

        public int NumberOfSymbols
        {
            get
            {
                return this.symbols.Count;
            }
        }

        public ISymbol GetSymbol(SymbolsEnum key)
        {
            // Uses "lazy initialization"
            ISymbol symbol = null;
            if (this.symbols.ContainsKey(key))
            {
                symbol = this.symbols[key];
            }
            else
            {
                switch (key)
                {
                    case SymbolsEnum.EmptySpace:
                        symbol = new EmptySpaceSymbol();
                        break;
                    case SymbolsEnum.FilledSpace:
                        symbol = new FilledSpaceSymbol();
                        break;
                    case SymbolsEnum.Player:
                        symbol = new PlayerSymbol();
                        break;
                    case SymbolsEnum.Check:
                        symbol = new CheckSymbol();
                        break;
                    default:
                        throw new InvalidOperationException("Wrong key for the SymbolFactory.GetSymbol(SymbolsEnum)");
                }

                this.symbols.Add(key, symbol);
            }

            return symbol;
        }
    }
}
