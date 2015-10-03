namespace Labyrinth.Logic.Rules
{
    using System;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Models;
    using Labyrinth.Models.Contracts;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common.Enum;

    public class StandartGameRule : IGameRule
    {
        public void SetGame(Board board)
        {
            FillBoard(board);
        }

        private void FillBoard(Board board)
        {
            var randomInt = new Random();
            for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
            {
                for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                {
                    int randomNumber = randomInt.Next(2);
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

            board.Field[GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY] = SymbolFactory.GetSymbol(SymbolsEnum.Player);
        }
    }
}
