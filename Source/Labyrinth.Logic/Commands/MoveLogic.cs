using Labyrinth.Common;
using Labyrinth.Common.Enum;
using Labyrinth.Logic.Contracts;
using Labyrinth.Models;
using Labyrinth.Models.Symbols;
using Labyrinth.Logic.Observer;
using System;

namespace Labyrinth.Logic.Commands
{
    public class MoveLogic : IObservered
    {
        //private Board labyrinth = Board.Instance;
        private int playerX;
        private int playerY;
        private int currentScore;
        PlayerCoordinates coordenates;

        public MoveLogic(PlayerCoordinates coord)
        {
            this.coordenates = coord;
        }

        public void MakeMove(string command)
        {
            switch (command.ToLower())
            {
                case "d":
                    if (Board.Instance.AreSymbolsEqual(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(playerX, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        //playerX++;
                        //currentScore++;
                        coordenates.PlayerX = playerX + 1;
                        coordenates.CurrentScore = currentScore + 1;
                    }
                    break;
                case "u":
                    if (Board.Instance.AreSymbolsEqual(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(playerX, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        //playerX--;
                        //currentScore++;
                        coordenates.PlayerX = playerX - 1;
                        coordenates.CurrentScore = currentScore + 1;
                    }
                    break;
                case "r":
                    if (Board.Instance.AreSymbolsEqual(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(playerX, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        //playerY++;
                        //currentScore++;
                        coordenates.PlayerY = playerY + 1;
                        coordenates.CurrentScore = currentScore + 1;
                    }
                    break;
                case "l":
                    if (Board.Instance.AreSymbolsEqual(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        Board.Instance.ReplaceSymbol(playerX, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                        Board.Instance.ReplaceSymbol(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                        //playerY--;
                        //currentScore++;
                        coordenates.PlayerY = playerY - 1;
                        coordenates.CurrentScore = currentScore + 1;
                    }
                    break;
                    // Tuka 6te gi mahneme tezi 4e 6te sa izli6ni
                    //case "top":
                    //    this.renderer.RenderScoreboard(Scoreboard.Instance);
                    //    this.renderer.RenderMessage("\n");
                    //    this.renderer.RenderBoard(labyrinth);
                    //    break;
                    //case "restart":
                    //    flag = false;
                    //    break;
                    //case "exit":
                    //    this.renderer.RenderMessage(Messages.ExitMessage);
                    //    Environment.Exit(0);
                    //    break;
                    //default:
                    //    this.renderer.RenderMessage("Invalid command!");
                    //    break;
            }
        }

        public void Update(int currentScore, int playerX, int playerY)
        {
            this.currentScore = currentScore;
            this.playerX = playerX;
            this.playerY = playerY;
        }
    }
}
