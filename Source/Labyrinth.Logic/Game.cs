namespace Labyrinth.Logic
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Models;
    using Labyrinth.Models.Players;
    using Labyrinth.Models.Symbols;
    using Labyrinth.Common;
    using Labyrinth.Common.Enum;
    using Labyrinth.Logic.Commands;
    using Labyrinth.Logic.Observer;
    using Interfaces;

    public class Game : IObservered
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly IBoardSetup gameRules;

        // .............................................................

        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; // waiting for input.

        private static bool playing; // game in progress.
        private static readonly bool flag; // used to prevent adding scores when restarting the game.

        private int currentScore;
        private int playerX;
        private int playerY;
        private readonly MoveLogic moveLogic;
        private readonly Command command;

        public Game(IRenderer renderer, IInputHandler inputHandler, IBoardSetup gameRules, MoveLogic moveLogic)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.gameRules = gameRules;
            this.moveLogic = moveLogic;
            this.moveLogic.Observer = new PlayerObserver();
            this.command = new Command(this.moveLogic);
        }

        public void Start()
        {
            this.moveLogic.Observer.Attach(this);
            this.moveLogic.Observer.Attach(moveLogic);
            this.moveLogic.Observer.CurrentScore = this.currentScore;
            this.moveLogic.Observer.PlayerX = GlobalConstants.PlayerStartPositionX;
            this.moveLogic.Observer.PlayerY = GlobalConstants.PlayerStartPositionY;

            commandListener = playing = true;

            this.renderer.RenderMessage(Messages.WelcomeMessage);
            this.renderer.RenderMessage(Messages.GameCommandsMessage);
            
            while (mazeHasSolution == false)
            {
                this.gameRules.SetGame(Board.Instance);
                SolutionChecker(Board.Instance, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
            }

            this.renderer.RenderBoard(Board.Instance);

            while (playing)
            {
                this.renderer.RenderMessage(Messages.EnterMoveMessage);
                var userInput = this.inputHandler.GetInput();
                this.command.ProcessCommand(userInput);
                if (command.GetType() == typeof(string))
                {
                    if (command.ToString() == "restart")
                    {
                        playing = false;
                    }
                    else if (command.ToString() == "top")
                    {
                        this.renderer.RenderScoreboard(Scoreboard.Instance);
                        this.renderer.RenderMessage("\n");
                        this.renderer.RenderBoard(Board.Instance);
                    }
                    else if (command.ToString() == "exit")
                    {
                        this.renderer.RenderMessage(Messages.ExitMessage);
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.renderer.RenderMessage("Invalid command!");
                    }
                }
                else
                {
                    this.renderer.RenderBoard(Board.Instance);
                    if (playerX == 0 || playerX == GlobalConstants.LabyrinthSizeRow - 1 ||
                        playerY == 0 || playerY == GlobalConstants.LabyrinthSizeCol - 1)
                    {
                        playing = false;
                    }
                }
            }

            //this.renderer.RenderBoard(Board.Instance);
            //TypeCommand(Board.Instance, commandListener, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);


            // used for adding score only when game is finished naturally and not by the restart command.
            while (flag)
            {
                this.renderer.RenderMessage(Messages.ScoreboardEnterNicknameMessage);
                string name = Console.ReadLine();
                Player player = new Player()
                                .SetName(name)
                                .SetScore(currentScore);
                Scoreboard.Instance.AddScore(player);
                //this.renderer.RenderMessage(string.Format(Messages.ShowPlayerScoreMessage,player.GetScore()));
                break;
            }
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
                mazeHasSolution = false;
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

                    mazeHasSolution = true;
                    checking = false;
                }
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
