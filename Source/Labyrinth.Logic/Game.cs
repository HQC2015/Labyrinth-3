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

    public class Game : IObservered
    {
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly IGameRule gameRules;
        //private readonly ICommandExecutor commandExecutor;

        // .............................................................

        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; // waiting for input.

        private static bool playing; // game in progress.
        private static bool flag; // used to prevent adding scores when restarting the game.

        private int currentScore;
        private int playerX;
        private int playerY;
        private PlayerCoordinates coordinates;
        private MoveLogic moveLogic;

        public Game(IRenderer renderer, IGameRule gameRules, IInputHandler inputHandler, PlayerCoordinates coordinates)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.gameRules = gameRules;
            this.coordinates = coordinates;
            this.moveLogic = new MoveLogic(coordinates);
        }

        public void Start()
        {
            coordinates.Attach(this);
            coordinates.Attach(moveLogic);
            coordinates.CurrentScore = this.currentScore;
            coordinates.PlayerX = GlobalConstants.PlayerStartPositionX;
            coordinates.PlayerY = GlobalConstants.PlayerStartPositionY;

            commandListener = playing = true;

            this.renderer.RenderMessage(Messages.WelcomeMessage);


            this.renderer.RenderMessage(Messages.GameCommandsMessage);

            //mazeHasSolution = flag = false;
            while (mazeHasSolution == false)
            {
                this.gameRules.SetGame(Board.Instance);
                this.SolutionChecker(Board.Instance, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
            }

            this.renderer.RenderBoard(Board.Instance);

            while (playing)
            {
                this.renderer.RenderMessage(Messages.EnterMoveMessage);
                var command = new Command(inputHandler);
                command.Start(moveLogic);
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

        //private void TypeCommand(Board labyrinth, bool flag, int x, int y)
        //{
        //    currentScore = 0;
        //
        //    while (flag)
        //    {
        //        Console.Write(Messages.EnterMoveMessage);
        //        string inputCommand = string.Empty;
        //        inputCommand = Console.ReadLine();
        //        switch (inputCommand.ToLower())
        //        {
        //            case "d":
        //                if (labyrinth.AreSymbolsEqual(x + 1, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
        //                {
        //                    labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
        //                    labyrinth.ReplaceSymbol(x + 1, y, SymbolFactory.GetSymbol(SymbolsEnum.Player));
        //                    x++;
        //                    currentScore++;
        //                }
        //                else
        //                {
        //                    this.renderer.RenderMessage(Messages.InvalidMoveMessage);
        //                }
        //
        //                if (x == GlobalConstants.LabyrinthSizeRow - 1)
        //                {
        //                    this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
        //                    flag = false;
        //                    Game.flag = true;
        //                }
        //
        //                this.renderer.RenderBoard(labyrinth);
        //                break;
        //            case "u":
        //                if (labyrinth.AreSymbolsEqual(x - 1, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
        //                {
        //                    labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
        //                    labyrinth.ReplaceSymbol(x - 1, y, SymbolFactory.GetSymbol(SymbolsEnum.Player));
        //                    x--;
        //                    currentScore++;
        //                }
        //                else
        //                {
        //                    this.renderer.RenderMessage(Messages.InvalidMoveMessage);
        //                }
        //
        //                if (x == 0)
        //                {
        //                    this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
        //                    flag = false;
        //                    Game.flag = true;
        //                }
        //
        //                this.renderer.RenderBoard(labyrinth);
        //                break;
        //            case "r":
        //                if (labyrinth.AreSymbolsEqual(x, y + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
        //                {
        //                    labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
        //                    labyrinth.ReplaceSymbol(x, y + 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
        //                    y++;
        //                    currentScore++;
        //                }
        //                else
        //                {
        //                    this.renderer.RenderMessage(Messages.InvalidMoveMessage);
        //                }
        //
        //                if (y == GlobalConstants.LabyrinthSizeCol - 1)
        //                {
        //                    this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
        //                    flag = false;
        //                    Game.flag = true;
        //                }
        //
        //                this.renderer.RenderBoard(labyrinth);
        //                break;
        //            case "l":
        //                if (labyrinth.AreSymbolsEqual(x, y - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
        //                {
        //                    labyrinth.ReplaceSymbol(x, y, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
        //                    labyrinth.ReplaceSymbol(x, y - 1, SymbolFactory.GetSymbol(SymbolsEnum.Player));
        //                    y--;
        //                    currentScore++;
        //                }
        //                else
        //                {
        //                    this.renderer.RenderMessage(Messages.InvalidMoveMessage);
        //                }
        //
        //                if (y == 0)
        //                {
        //                    this.renderer.RenderMessage(string.Format("\nCongratulations you escaped with {0} Score.\n", currentScore));
        //                    flag = false;
        //                    Game.flag = true;
        //                }
        //
        //                this.renderer.RenderBoard(labyrinth);
        //                break;
        //            case "top":
        //                this.renderer.RenderScoreboard(Scoreboard.Instance);
        //                this.renderer.RenderMessage("\n");
        //                this.renderer.RenderBoard(labyrinth);
        //                break;
        //            case "restart":
        //                flag = false;
        //                break;
        //            case "exit":
        //                this.renderer.RenderMessage(Messages.ExitMessage);
        //                Environment.Exit(0);
        //                break;
        //            default:
        //                this.renderer.RenderMessage("Invalid command!");
        //                break;
        //        }
        //    }
        //}

        private void SolutionChecker(Board labyrinth, int playerX, int playerY)
        {
            bool checking = true;

            if (labyrinth.AreSymbolsEqual(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                labyrinth.AreSymbolsEqual(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                labyrinth.AreSymbolsEqual(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)) &&
                labyrinth.AreSymbolsEqual(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace)))
            { // player is trapped
                checking = false;
            }

            while (checking)
            {
                try
                {
                    if (labyrinth.AreSymbolsEqual(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        labyrinth.ReplaceSymbol(playerX + 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerX++;
                    }
                    else if (labyrinth.AreSymbolsEqual(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        labyrinth.ReplaceSymbol(playerX, playerY + 1, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerY++;
                    }
                    else if (labyrinth.AreSymbolsEqual(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        labyrinth.ReplaceSymbol(playerX - 1, playerY, SymbolFactory.GetSymbol(SymbolsEnum.Check));
                        playerX--;
                    }
                    else if (labyrinth.AreSymbolsEqual(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                    {
                        labyrinth.ReplaceSymbol(playerX, playerY - 1, SymbolFactory.GetSymbol(SymbolsEnum.Check));
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
                            if (labyrinth.AreSymbolsEqual(i, j, SymbolFactory.GetSymbol(SymbolsEnum.Check)))
                            {
                                labyrinth.ReplaceSymbol(i, j, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace));
                            }
                        }

                        checking = false;
                        mazeHasSolution = true;
                    }
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
