namespace Labyrinth.Models.Symbols
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Common.Enum;
    using Labyrinth.Models.Contracts;

    public static class SymbolFactory
    {
        private static readonly Dictionary<SymbolsEnum, ISymbol> Symbols = new Dictionary<SymbolsEnum, ISymbol>();

        public static ISymbol GetSymbol(SymbolsEnum key)
        {
            // Uses "lazy initialization"
            ISymbol symbol = null;
            if (Symbols.ContainsKey(key))
            {
                symbol = Symbols[key];
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

                Symbols.Add(key, symbol);
            }

            return symbol;
        }
    }
}
