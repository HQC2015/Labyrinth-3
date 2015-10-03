namespace Labyrinth.Models.Symbols
{
    using Labyrinth.Models.Contracts;

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
