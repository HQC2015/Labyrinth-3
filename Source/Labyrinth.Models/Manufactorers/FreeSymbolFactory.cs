namespace Labyrinth.Models.Manufactorers
{
    using System;
    using Labyrinth.Models.Symbols;

    public class FreeSymbolFactory : Manufactorer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new FreeSymbol();
            return symbol;
        }
    }
}
