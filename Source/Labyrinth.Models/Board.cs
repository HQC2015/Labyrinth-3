namespace Labyrinth.Models
{
    using System;
    using Contracts;

    public class Board
    {
        private static readonly Lazy<Board> InstanceOfBoard = new Lazy<Board>(() => new Board(GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol));

        private Board(int labyrinthSizeRow, int labyrinthSizeCol)
        {
            this.Field = new ISymbol[labyrinthSizeRow, labyrinthSizeCol];
        }

        public static Board Instance
        {
            get
            {
                return InstanceOfBoard.Value;
            }
        }

        public ISymbol[,] Field { get; private set; }

        public bool AreSymbolsEqual(int x, int y, ISymbol symbolToCheck)
        {
            return this.Field[x, y].GetValue() == symbolToCheck.GetValue();
        }

        public void ReplaceSymbol(int x, int y, ISymbol newSymbol)
        {
            this.Field[x, y] = newSymbol;
        }
    }
}
