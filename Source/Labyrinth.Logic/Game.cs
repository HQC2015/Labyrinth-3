namespace Labyrinth.Logic
{
    using System;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Models;
    using Labyrinth.Models.Players;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common;
    using Labyrinth.Common.Enum;
    using Models.Interfaces;
    using Commands;

    public class Game
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly IBoardSetup boardSetupRules;

        private CommandController commandController;
        private IPlayer player;
        private bool mazeHasSolution;
        private bool playing;

        public Game(IRenderer renderer, IInputHandler inputHandler, IBoardSetup boardSetupRules)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.boardSetupRules = boardSetupRules;
            this.player = new Player();
            this.commandController = new CommandController(this.player);
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
                this.SolutionChecker(Board.Instance, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
            }

            this.renderer.RenderBoard(Board.Instance);
            this.playing = true;
            while (this.playing)
            {
                this.renderer.RenderMessage(Messages.AvailableCommandsMessage);
                this.renderer.RenderMessage(this.commandController.GetAvailableCommands());
                this.renderer.RenderMessage(Messages.EnterMoveMessage);
                string userInput = this.inputHandler.GetInput();
                if (userInput.Length > 2)
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
                        this.renderer.RenderMessage(Messages.InvalidCommandMessage);
                    }
                }
                else
                {
                    try
                    {
                        this.commandController.ProcessCommand(userInput);
                    }
                    catch (InvalidGameCommandException)
                    {
                        this.renderer.RenderMessage(Messages.InvalidCommandMessage);
                    }
                    finally
                    {
                        this.renderer.RenderBoard(Board.Instance);
                    }

                    if (this.player.GetX() == 0 || this.player.GetX() == GlobalConstants.LabyrinthSizeRow - 1 ||
                        this.player.GetY() == 0 || this.player.GetY() == GlobalConstants.LabyrinthSizeCol - 1)
                    {
                        this.playing = false;
                    }
                }
            }

            this.renderer.RenderMessage(Messages.ScoreboardEnterNicknameMessage);
            string name = Console.ReadLine();
            this.player.SetName(name);
            Scoreboard.Instance.AddScore(this.player);
            this.renderer.RenderMessage(string.Format(Messages.ShowPlayerScoreMessage, this.player.GetScore()));
            this.renderer.RenderScoreboard(Scoreboard.Instance);

            this.renderer.RenderMessage(Messages.StartANewGameMessage);
            string userInputToPlayAgain = this.inputHandler.GetInput();
            if (userInputToPlayAgain.ToLower() == "yes")
            {
                this.RestartGame();
            }
            else
            {
                this.renderer.RenderMessage(Messages.ThanksForPlayingMessage);
            }
        }

        private void RestartGame()
        {
            this.player = new Player();
            this.mazeHasSolution = false;
            this.commandController = new CommandController(this.player);
            this.Start();
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
