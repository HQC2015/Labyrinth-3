namespace Labyrinth.Models.Symbols
{
    using Contracts;

    public abstract class Symbol : ISymbol
    {
        protected Symbol(char val)
        {
            this.Value = val;
        }

        private char Value { get; set; }

        public char GetValue()
        {
            return this.Value;
        }
    }
}
