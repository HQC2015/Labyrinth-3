namespace Labyrinth.Models.Symbols
{
    using System;

    public class CheckSymbol : Symbol
    {
        private string val = "0";

        public CheckSymbol()
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
