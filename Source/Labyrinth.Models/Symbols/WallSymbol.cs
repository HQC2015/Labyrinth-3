namespace Labyrinth.Models.Symbols
{
    using System;

    public class WallSymbol : Symbol
    {
        private string val;

        public WallSymbol ()
        {
            this.Print = "x";
        }

        public  string Print
        {
            get
            {
                return this.val;
            }
            private set
            {
                this.val = "x";
            }
        }

        public override string ToString()
        {
            return this.val;
        }
    }
}
