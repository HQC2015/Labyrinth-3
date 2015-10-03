namespace Labyrinth.Models.Symbols
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Models.Contracts;
    using Labyrinth.Common.Enum;

    public static class SymbolFactory
    {
        private static readonly Dictionary<SymbolsEnum, ISymbol> symbols = new Dictionary<SymbolsEnum, ISymbol>();

        public static ISymbol GetSymbol(SymbolsEnum key)
        {
            // Uses "lazy initialization"
            ISymbol symbol = null;
            if (symbols.ContainsKey(key))
            {
                symbol = symbols[key];
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

                symbols.Add(key, symbol);
            }

            return symbol;
        }
    }
}
