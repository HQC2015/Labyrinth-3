namespace Labyrinth.Models.Symbols
{
    public abstract class Symbol //IComparable
    {
        private string symbolValue;

        protected Symbol(string val)
        {
            this.Value = val;
        }

        public string Value
        {
            get
            {
                return this.symbolValue;
            }
            private set
            {
                this.symbolValue = value;
            }
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
