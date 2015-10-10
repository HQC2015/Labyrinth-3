namespace Labyrinth.Models.Symbols
{
    using Contracts;

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
