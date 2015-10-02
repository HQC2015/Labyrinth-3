namespace Labyrinth.Models.Manufactorers
{
    using System;
    using Labyrinth.Models.Symbols;

    public class CheckSymbolFactory : Manufactorer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new CheckSymbol();
            return symbol;
        }
    }
}
