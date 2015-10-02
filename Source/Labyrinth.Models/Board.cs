namespace Labyrinth.Models
{
    using System;
    using Manufacturers;
    using Symbols;

    public class Board
    {
        private static Board instance;

        private WallSymbolFactory wallFactory = new WallSymbolFactory();
        private FreeSymbolFactory freeFactory = new FreeSymbolFactory();
        private CheckSymbolFactory checkFactory = new CheckSymbolFactory();
        private PlayerSymbolFactory playerFactory = new PlayerSymbolFactory();

        private Symbol[,] board = new Symbol[GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol];

        private Board()
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
            string reminder;

            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    reminder = randomInt.Next(2).ToString();
                    //Console.WriteLine(reminder);
                    if (reminder == "0")
                    {
                        this.board[i, j] = freeFactory.ManufactureSymbol();
                    }
                    else
                    {
                        this.board[i, j] = wallFactory.ManufactureSymbol();
                    }
                }
            }

            this.board[GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY] = playerFactory.ManufactureSymbol();
        }

        public bool Check(int x, int y, Symbol checkSymbol)
        {
            bool rem = this.board[x, y].ToString() == checkSymbol.ToString();
            return rem;
        }

        public void Replace(int x, int y, Symbol newSymbol)
        {
            this.board[x, y] = newSymbol;
        }

        public void Display()
        {
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    Console.Write(this.board[i, j].ToString() + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
