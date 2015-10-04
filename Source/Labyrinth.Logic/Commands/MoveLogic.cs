using Labyrinth.Common;
using Labyrinth.Common.Enum;
using Labyrinth.Logic.Contracts;
using Labyrinth.Models;
using Labyrinth.Models.Symbols;
using System;

namespace Labyrinth.Logic.Commands
{
    public class MoveLogic
    {
        private Board labyrinth = Board.Instance;
        private int x = GlobalConstants.PlayerStartPositionX;
        private int y = GlobalConstants.PlayerStartPositionY;
        private bool flag = true;
        private int currentScore = 0;
        private IRenderer renderer;

        public void MakeMove(string command)
        {
            while (flag)
            {
                switch (command.ToLower())
                {
                    case "d":
                        if (labyrinth.AreSymbolsEqual(x + 1, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            labyrinth.ReplaceSymbol(x + 1, y, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                            x++;
                            currentScore++;
                        }
                        else
                        {
                            this.renderer.RenderMessage(Messages.InvalidMoveMessage);
                        }

                        if (x == GlobalConstants.LabyrinthSizeRow - 1)
                        {
                            this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
                            flag = false;
                            //TODO: Observer for flag!!!
                        }

                        this.renderer.RenderBoard(labyrinth);
                        break;
                    case "u":
                        if (labyrinth.AreSymbolsEqual(x - 1, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            labyrinth.ReplaceSymbol(x - 1, y, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                            x--;
                            currentScore++;
                        }
                        else
                        {
                            this.renderer.RenderMessage(Messages.InvalidMoveMessage);
                        }

                        if (x == 0)
                        {
                            this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
                            flag = false;
                            //TODO: Observer for flag!!!
                        }

                        this.renderer.RenderBoard(labyrinth);
                        break;
                    case "r":
                        if (labyrinth.AreSymbolsEqual(x, y + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            labyrinth.ReplaceSymbol(x, y + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                            y++;
                            currentScore++;
                        }
                        else
                        {
                            this.renderer.RenderMessage(Messages.InvalidMoveMessage);
                        }

                        if (y == GlobalConstants.LabyrinthSizeCol - 1)
                        {
                            this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
                            flag = false;
                            //TODO: Observer for flag!!!
                        }

                        this.renderer.RenderBoard(labyrinth);
                        break;
                    case "l":
                        if (labyrinth.AreSymbolsEqual(x, y - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            labyrinth.ReplaceSymbol(x, y - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
                            y--;
                            currentScore++;
                        }
                        else
                        {
                            this.renderer.RenderMessage(Messages.InvalidMoveMessage);
                        }

                        if (y == 0)
                        {
                            this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
                            flag = false;
                            //TODO: Observer for flag!!!
                        }

                        this.renderer.RenderBoard(labyrinth);
                        break;
                        // Tuka 6te gi mahneme tezi 4e 6te sa izli6ni
                    case "top":
                        this.renderer.RenderScoreboard(Scoreboard.Instance);
                        this.renderer.RenderMessage("\n");
                        this.renderer.RenderBoard(labyrinth);
                        break;
                    case "restart":
                        flag = false;
                        break;
                    case "exit":
                        this.renderer.RenderMessage(Messages.ExitMessage);
                        Environment.Exit(0);
                        break;
                    default:
                        this.renderer.RenderMessage("Invalid command!");
                        break;
                }
            }
        }
    }
}
