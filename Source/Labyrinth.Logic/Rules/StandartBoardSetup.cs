namespace Labyrinth.Logic.Rules
{
    using System;
    using Common.Enum;
    using Contracts;
    using Models;
    using Models.Symbols;

    public class StandartBoardSetup : IBoardSetup
    {
        private readonly int playerStartPositionX = GlobalConstants.PlayerStartPositionX;
        private readonly int playerStartPositionY = GlobalConstants.PlayerStartPositionY;

        public void SetGame(Board board)
        {
            this.FillBoard(board);
        }

        private void FillBoard(Board board)
        {
            var random = new Random();
        
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    int randomNumber = random.Next(maxValue: 2);
                    if (randomNumber == 0)
                    {
                        board.Field[i, j] = SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace);
                    }
                    else
                    {
                        board.Field[i, j] = SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace);
                    }
                }
            }

            board.Field[this.playerStartPositionX, this.playerStartPositionY] = SymbolFactory.GetSymbol(SymbolsEnum.Player);
        }
    }
}
