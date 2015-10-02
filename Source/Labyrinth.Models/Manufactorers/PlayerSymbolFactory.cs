namespace Labyrinth.Models.Manufactorers
{
    using System;
    using Labyrinth.Models.Symbols;

    public class PlayerSymbolFactory : Manufactorer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new PlayerSymbol();
            return symbol;
        }
    }
}
