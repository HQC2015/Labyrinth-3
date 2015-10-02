namespace Labyrinth.Models.Manufacturers
{
    using Symbols;

    public class FreeSymbolFactory : Manufacturer
    {
        public override Symbol ManufactureSymbol()
        {
            var symbol = new EmptySpaceSymbol();
            return symbol;
        }
    }
}
