namespace Labyrinth.Models.Manufacturers
{
    using Symbols;

    public class WallSymbolFactory : Manufacturer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new FilledSpaceSymbol();
            return symbol;
        }
    }
}
