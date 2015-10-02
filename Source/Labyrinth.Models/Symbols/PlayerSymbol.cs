namespace Labyrinth.Models.Symbols
{
    using System;

    public class PlayerSymbol : Symbol
    {
        private string val = "*";

        public PlayerSymbol()
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
