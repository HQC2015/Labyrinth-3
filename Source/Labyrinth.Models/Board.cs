namespace Labyrinth.Models
{
    using System;
    using Symbols;
    using Contracts;
    using Common.Enum;

    public class Board
    {
        private static readonly Lazy<Board> instance = new Lazy<Board>(() => new Board());

        private readonly ISymbol[,] board = new ISymbol[GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol];

        private readonly SymbolFactory symbolFactory = new SymbolFactory();

        private Board()
        {
        }

        public static Board Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public void FillBoard()
        {
            var randomInt = new Random();
            string reminder;

            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    reminder = randomInt.Next(2).ToString();
                    //Console.WriteLine(reminder);
                    if (reminder == "0")
                    {
                        this.board[i, j] = symbolFactory.GetSymbol(SymbolsEnum.EmptySpace);
                    }
                    else
                    {
                        this.board[i, j] = symbolFactory.GetSymbol(SymbolsEnum.FilledSpace);
                    }
                }
            }

            this.board[GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY] = symbolFactory.GetSymbol(SymbolsEnum.Player);
        }

        public bool Check(int x, int y, ISymbol checkSymbol)
        {
            bool rem = this.board[x, y].GetValue() == checkSymbol.GetValue();
            return rem;
        }

        public void Replace(int x, int y, ISymbol newSymbol)
        {
            this.board[x, y] = newSymbol;
        }

        public void Display()
        {
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    Console.Write(this.board[i, j].GetValue() + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
