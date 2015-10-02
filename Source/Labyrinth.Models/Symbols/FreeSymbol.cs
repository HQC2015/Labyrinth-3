namespace Labyrinth.Models.Symbols
{
    using System;

    public class FreeSymbol : Symbol
    {
        private string val = "-";

        public FreeSymbol()
        {
        }

        public string Print
        {
            get
            {
                return this.val;
            }
        }

        public override string ToString()
        {
            return this.val;
        }
    }
}
