namespace Labyrinth.Logic
{
    using System;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Logic.Commands;
    using Labyrinth.Models;
    using Labyrinth.Models.Players;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common;
    using Labyrinth.Common.Enum;
    using Models.Interfaces;

    public class Game
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly IBoardSetup boardSetupRules;
        
        private readonly Command command;
        private readonly IPlayer player;
        // .............................................................

        private bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private readonly bool commandListener; // waiting for input.

        private bool playing; // game in progress.
        private readonly bool flag; // used to prevent adding scores when restarting the game
        
        private bool gameend;

        public Game(IRenderer renderer, IInputHandler inputHandler, IBoardSetup boardSetupRules)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.boardSetupRules = boardSetupRules;
            this.player = new Player();
            this.command = new Command(this.player);
        }

        public void Start()
        {
            this.player
                .SetScore(0)
                .SetX(GlobalConstants.PlayerStartPositionX)
                .SetY(GlobalConstants.PlayerStartPositionY);

            this.renderer.RenderMessage(Messages.WelcomeMessage);
            this.renderer.RenderMessage(Messages.GameCommandsMessage);
            
            while (this.mazeHasSolution == false)
            {
                this.boardSetupRules.SetGame(Board.Instance);
                SolutionChecker(Board.Instance, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
            }

            this.renderer.RenderBoard(Board.Instance);

            this.playing = true;
            while (this.playing)
            {
                this.renderer.RenderMessage(Messages.EnterMoveMessage);
                var userInput = this.inputHandler.GetInput();
                if (userInput.Length > 1)
                {
                    if (userInput == "restart")
                    {
                        this.playing = false;
                    }
                    else if (userInput == "top")
                    {
                        this.renderer.RenderScoreboard(Scoreboard.Instance);
                        this.renderer.RenderMessage("\n");
                        this.renderer.RenderBoard(Board.Instance);
                    }
                    else if (userInput == "exit")
                    {
                        this.renderer.RenderMessage(Messages.ExitMessage);
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.renderer.RenderMessage(Messages.InvalidMoveMessage);
                    }
                }
                else 
                {
                    try
                    {
                        this.command.ProcessCommand(userInput);
                    }
                    catch (ArgumentException)
                    {
                        this.renderer.RenderMessage("Invalid command!");
                    }
                    finally
                    {
                        this.renderer.RenderBoard(Board.Instance);
                    }

                    if (this.player.GetX() == 0 || this.player.GetX() == GlobalConstants.LabyrinthSizeRow - 1 ||
                        this.player.GetY() == 0 || this.player.GetY() == GlobalConstants.LabyrinthSizeCol - 1)
                    {
                        this.playing = false;
                        ////this.gameend = true;
                    }
                }
            }
            //// used for adding score only when game is finished naturally and not by the restart command.
            ////while (this.gameend)
            ////{
            this.renderer.RenderMessage(Messages.ScoreboardEnterNicknameMessage);
                string name = Console.ReadLine();
                this.player.SetName(name);
                Scoreboard.Instance.AddScore(this.player);
                this.renderer.RenderMessage(string.Format(Messages.ShowPlayerScoreMessage, player.GetScore()));
                this.renderer.RenderScoreboard(Scoreboard.Instance);
            //}
        }

        private void SolutionChecker(Board board, int playerX, int playerY)
        {
            bool checking = true;

            if (board.AreSymbolsEqual(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                board.AreSymbolsEqual(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                board.AreSymbolsEqual(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                board.AreSymbolsEqual(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)))
            { // player is trapped
                checking = false;
                this.mazeHasSolution = false;
            }

            while (checking)
            {
                try
                {
                    if (board.AreSymbolsEqual(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        board.ReplaceSymbol(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerX++;
                    }
                    else if (board.AreSymbolsEqual(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        board.ReplaceSymbol(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerY++;
                    }
                    else if (board.AreSymbolsEqual(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        board.ReplaceSymbol(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerX--;
                    }
                    else if (board.AreSymbolsEqual(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        board.ReplaceSymbol(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerY--;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                catch (Exception)
                {
                    for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
                    {
                        for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
                        {
                            if (board.AreSymbolsEqual(i, j, SymbolFactory.GetSymbol(SymbolsEnum.Check)))
                            {
                                board.ReplaceSymbol(i, j, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            }
                        }
                    }

                    this.mazeHasSolution = true;
                    checking = false;
                }
            }
        }
    }
}
