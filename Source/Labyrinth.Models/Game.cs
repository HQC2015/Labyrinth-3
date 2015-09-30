﻿namespace Labyrinth.Models
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Common;

    public class Game
    {
        private static readonly List<Player> scores = new List<Player>();

        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; // waiting for input.

        private static bool playing; // game in progress.
        private static bool flag; // used to prevent adding scores when restarting the game.

        private static int currentScore;

        public static void Start()
        {
            commandListener = playing = true;
            var labyrinth = Board.Instance;

            while (playing)
            {
                Console.WriteLine(Messages.WelcomeMessage);

                mazeHasSolution = flag = false;

                while (mazeHasSolution == false)
                {
                    //LabyrinthGenerator(labyrinth, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
                    labyrinth.FillBoard();
                    SolutionChecker(labyrinth, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);
                }

                labyrinth.Display();
                TypeCommand(labyrinth, commandListener, GlobalConstants.PlayerStartPositionX, GlobalConstants.PlayerStartPositionY);

                // used for adding score only when game is finished naturally and not by the restart command.
                while (flag)
                {
                    AddScore(scores, currentScore);
                }
            }
        }

        private static void SolutionChecker(Board labyrinth, int playerX, int playerY)
        {
            bool checking = true;
            if (labyrinth.Check(playerX + 1, playerY, GlobalConstants.FilledSpaceSymbol) && labyrinth.Check(playerX, playerY + 1, GlobalConstants.FilledSpaceSymbol) &&
                labyrinth.Check(playerX - 1, playerY, GlobalConstants.FilledSpaceSymbol) && labyrinth.Check(playerX, playerY - 1, GlobalConstants.FilledSpaceSymbol))
            { // player is trapped
                checking = false;
            }

            while (checking)
            {
                try
                {
                    if (labyrinth.Check(playerX + 1, playerY, GlobalConstants.EmptySpaceSymbol))
                    {
                        labyrinth.Replace(playerX + 1, playerY, "0");
                        playerX++;
                    }
                    else if (labyrinth.Check(playerX, playerY + 1, GlobalConstants.EmptySpaceSymbol))
                    {
                        labyrinth.Replace(playerX, playerY + 1, "0");
                        playerY++;
                    }
                    else if (labyrinth.Check(playerX - 1, playerY, GlobalConstants.EmptySpaceSymbol))
                    {
                        labyrinth.Replace(playerX - 1, playerY, "0");
                        playerX--;
                    }
                    else if (labyrinth.Check(playerX, playerY - 1, GlobalConstants.EmptySpaceSymbol))
                    {
                        labyrinth.Replace(playerX, playerY - 1, "0");
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
                            if (labyrinth.Check(i, j, "0"))
                            {
                                labyrinth.Replace(i, j, GlobalConstants.EmptySpaceSymbol);
                            }
                        }

                        checking = false;
                        mazeHasSolution = true;
                    }
                }
            }
        }

        private static void AddScore(List<Player> scores, int currentScore)
        {
            if (scores.Count != 0)
            {
                scores.Sort(delegate (Player s1, Player s2)
                {
                    return s1.Score.CompareTo(s2.Score);
                });
            }

            if (scores.Count == 5)
            {
                if (scores[4].Score > currentScore)
                {
                    scores.Remove(scores[4]);
                    Console.WriteLine(Messages.ScoreboardEnterNicknameMessage);
                    string name = Console.ReadLine();
                    scores.Add(new Player(currentScore, name));
                    ShowPlayer(scores);
                }
            }

            if (scores.Count < 5)
            {
                Console.WriteLine(Messages.ScoreboardEnterNicknameMessage);
                string name = Console.ReadLine();
                scores.Add(new Player(currentScore, name));
                ShowPlayer(scores);
            }

            flag = false;
        }

        private static void ShowPlayer(List<Player> scores)
        {
            Console.WriteLine();
            if (scores.Count == 0)
            {
                Console.WriteLine(Messages.ScoreboardEmptyMessage);
            }
            else
            {
                scores.Sort(delegate (Player s1, Player s2)
                {
                    return s1.Score.CompareTo(s2.Score);
                });

                Console.WriteLine("Top 5: \n");
                int i = 1;
                scores.ForEach(delegate (Player s)
                {
                    Console.WriteLine(string.Format(i + ". {1} ---> {0} Score", s.Score, s.Name));
                    i++;
                });
                Console.WriteLine();
            }
        }

        private static void TypeCommand(Board labyrinth, bool flag, int x, int y)
        {
            currentScore = 0;

            while (flag)
            {
                Console.Write(Messages.EnterMoveMessage);
                string inputCommand = string.Empty;
                inputCommand = Console.ReadLine();
                switch (inputCommand.ToLower())
                {
                    case "d":
                        if (labyrinth.Check(x + 1, y, GlobalConstants.EmptySpaceSymbol))
                        {
                            labyrinth.Replace(x, y, GlobalConstants.EmptySpaceSymbol);
                            labyrinth.Replace(x + 1, y, GlobalConstants.PlayerSymbol);
                            x++;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(Messages.InvalidMoveMessage);
                        }

                        if (x == GlobalConstants.LabyrinthSizeRow - 1)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        labyrinth.Display();
                        break;
                    case "u":
                        if (labyrinth.Check(x - 1, y, GlobalConstants.EmptySpaceSymbol))
                        {
                            labyrinth.Replace(x, y, GlobalConstants.EmptySpaceSymbol);
                            labyrinth.Replace(x - 1, y, GlobalConstants.PlayerSymbol);
                            x--;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(Messages.InvalidMoveMessage);
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        labyrinth.Display();
                        break;
                    case "r":
                        if (labyrinth.Check(x, y + 1, GlobalConstants.EmptySpaceSymbol))
                        {
                            labyrinth.Replace(x, y, GlobalConstants.EmptySpaceSymbol);
                            labyrinth.Replace(x, y + 1, GlobalConstants.PlayerSymbol);
                            y++;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(Messages.InvalidMoveMessage);
                        }

                        if (y == GlobalConstants.LabyrinthSizeCol - 1)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        labyrinth.Display();
                        break;
                    case "l":
                        if (labyrinth.Check(x, y - 1, GlobalConstants.EmptySpaceSymbol))
                        {
                            labyrinth.Replace(x, y, GlobalConstants.EmptySpaceSymbol);
                            labyrinth.Replace(x, y - 1, GlobalConstants.PlayerSymbol);
                            y--;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(Messages.InvalidMoveMessage);
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        labyrinth.Display();
                        break;
                    case "top":
                        ShowPlayer(scores);
                        Console.WriteLine("\n");
                        labyrinth.Display();
                        break;
                    case "restart":
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine(Messages.ExitMessage);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}