namespace Labyrinth.Models.Manufacturers
{
    using Symbols;

    public class CheckSymbolFactory : Manufacturer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new CheckSymbol();
            return symbol;
        }
    }
}
