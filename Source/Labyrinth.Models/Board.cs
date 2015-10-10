namespace Labyrinth.Models
{
    using System;
    using Labyrinth.Models.Contracts;

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

        public bool AreSymbolsEqual(int x, int y, ISymbol symbolToCheckSymbol)
        {
            return this.Field[x, y].GetValue() == symbolToCheckSymbol.GetValue();
        }

        public void ReplaceSymbol(int x, int y, ISymbol newSymbol)
        {
            this.Field[x, y] = newSymbol;
        }
    }
}
