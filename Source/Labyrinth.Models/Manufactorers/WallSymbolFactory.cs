namespace Labyrinth.Models.Manufactorers
{
    using System;
    using Labyrinth.Models.Symbols;

    public class WallSymbolFactory : Manufactorer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new WallSymbol();
            return symbol;
        }
    }
}
