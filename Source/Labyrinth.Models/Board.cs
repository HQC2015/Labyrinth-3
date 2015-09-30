namespace Labyrinth.Models
{
    using System;

    public class Board
    {
        private static Board instance;

        private string[,] board = new string[GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol];

        protected Board()
        {
        }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }

                return instance;
            }
        }

        public void FillBoard()
        {
            var randomInt = new Random();

            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    this.board[i, j] = randomInt.Next(2).ToString();
                    if (this.board[i, j] == "0")
                    {
                        this.board[i, j] = GlobalConstants.EmptySpaceSymbol;
                    }
                    else
                    {
                        this.board[i, j] = GlobalConstants.FilledSpaceSymbol;
                    }
                }
            }

            this.board[GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY] = GlobalConstants.PlayerSymbol;
        }

        public bool Check(int x, int y, string checkSymbol)
        {
            return this.board[x, y] == checkSymbol;
        }

        public void Replace(int x, int y, string newSymbol)
        {
            this.board[x, y] = newSymbol;
        }

        public void Display()
        {
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    Console.Write(this.board[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
