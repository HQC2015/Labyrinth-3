namespace Labyrinth.Models.Manufacturers
{
    using Symbols;

    public class PlayerSymbolFactory : Manufacturer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new PlayerSymbol();
            return symbol;
        }
    }
}
