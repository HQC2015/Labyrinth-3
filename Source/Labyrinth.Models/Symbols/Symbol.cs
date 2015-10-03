namespace Labyrinth.Models.Symbols
{
    using Labyrinth.Models.Contracts;

    public abstract class Symbol : ISymbol
    {
        private readonly char value;

        protected Symbol(char val)
        {
            this.value = val;
        }

        public char GetValue()
        {
            return this.value;
        }
    }
}
