namespace Labyrinth.Logic
{
    using System;

    public class InvalidGameCommandException : Exception
    {
        public InvalidGameCommandException(string msg)
            : base(msg)
        {
        }
    }
}
