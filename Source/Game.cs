namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using Players;

    public class Game
    {
        private const int PlayerStartPositionX = 3;
        private const int PlayerStartPositionY = 3;
        private const int LabyrinthSize = 7;
        private const string PlayerSymbol = "*";
        private const string EmptySpaceSymbol = "-";
        private const string FilledSpaceSymbol = "x";

        private const string WelcomeMessage = "Welcome to \"Labyrinth\" game, where you try to escape!\nUse 'top' to view the top players\n'restart' to start a new game\n'exit' to quit the game.\n ";
        private const string EnterMoveMessage = "Enter your move (L=left, R=right, D=down, U=up): ";
        private const string InvalidMoveMessage = "Invalid move!";
        private const string ScoreboardEnterNicknameMessage = "Please enter your nickname";
        private const string ScoreboardEmptyMessage = "The Scoreboard is empty!";
        private const string ExitMessage = "GoodBye!";

        private static readonly List<Player> scores = new List<Player>();

        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; // waiting for input.

        private static bool playing; // game in progress.
        private static bool flag; // used to prevent adding scores when restarting the game.

        private static int currentScore;

        public static void Start()
        {
            commandListener = playing = true;
            var labyrinth = new string[LabyrinthSize, LabyrinthSize];

            while (playing)
            {
                Console.WriteLine(WelcomeMessage);

                mazeHasSolution = flag = false;

                while (mazeHasSolution == false)
                {
                    LabyrinthGenerator(labyrinth, PlayerStartPositionX, PlayerStartPositionY);
                    SolutionChecker(labyrinth, PlayerStartPositionX, PlayerStartPositionY);
                }

                DisplayLabyrinth(labyrinth);
                TypeCommand(labyrinth, commandListener, PlayerStartPositionX, PlayerStartPositionY);

                // used for adding score only when game is finished naturally and not by the restart command.
                while (flag)
                {
                    AddScore(scores, currentScore);
                }
            }
        }

        private static void SolutionChecker(string[,] labyrinth, int playerX, int playerY)
        {
            bool checking = true;
            if (labyrinth[playerX + 1, playerY] == FilledSpaceSymbol && labyrinth[playerX, playerY + 1] == FilledSpaceSymbol &&
                labyrinth[playerX - 1, playerY] == FilledSpaceSymbol && labyrinth[playerX, playerY - 1] == FilledSpaceSymbol)
            { // player is trapped
                checking = false;
            }

            while (checking)
            {
                try
                {
                    if (labyrinth[playerX + 1, playerY] == EmptySpaceSymbol)
                    {
                        labyrinth[playerX + 1, playerY] = "0";
                        playerX++;
                    }
                    else if (labyrinth[playerX, playerY + 1] == EmptySpaceSymbol)
                    {
                        labyrinth[playerX, playerY + 1] = "0";
                        playerY++;
                    }
                    else if (labyrinth[playerX - 1, playerY] == EmptySpaceSymbol)
                    {
                        labyrinth[playerX - 1, playerY] = "0";
                        playerX--;
                    }
                    else if (labyrinth[playerX, playerY - 1] == EmptySpaceSymbol)
                    {
                        labyrinth[playerX, playerY - 1] = "0";
                        playerY--;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                catch (Exception)
                {
                    for (int i = 0; i < LabyrinthSize; i++)
                    {
                        for (int j = 0; j < LabyrinthSize; j++)
                        {
                            if (labyrinth[i, j] == "0")
                            {
                                labyrinth[i, j] = EmptySpaceSymbol;
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
                    Console.WriteLine(ScoreboardEnterNicknameMessage);
                    string name = Console.ReadLine();
                    scores.Add(new Player(currentScore, name));
                    ShowPlayer(scores);
                }
            }

            if (scores.Count < 5)
            {
                Console.WriteLine(ScoreboardEnterNicknameMessage);
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
                Console.WriteLine(ScoreboardEmptyMessage);
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

        private static void TypeCommand(string[,] labyrinth, bool flag, int x, int y)
        {
            currentScore = 0;

            while (flag)
            {
                Console.Write(EnterMoveMessage);
                string inputCommand = string.Empty;
                inputCommand = Console.ReadLine();
                switch (inputCommand.ToLower())
                {
                    case "d":
                        if (labyrinth[x + 1, y] == EmptySpaceSymbol)
                        {
                            labyrinth[x, y] = EmptySpaceSymbol;
                            labyrinth[x + 1, y] = PlayerSymbol;
                            x++;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(InvalidMoveMessage);
                        }

                        if (x == LabyrinthSize - 1)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "u":
                        if (labyrinth[x - 1, y] == EmptySpaceSymbol)
                        {
                            labyrinth[x, y] = EmptySpaceSymbol;
                            labyrinth[x - 1, y] = PlayerSymbol;
                            x--;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(InvalidMoveMessage);
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "r":
                        if (labyrinth[x, y + 1] == EmptySpaceSymbol)
                        {
                            labyrinth[x, y] = EmptySpaceSymbol;
                            labyrinth[x, y + 1] = PlayerSymbol;
                            y++;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(InvalidMoveMessage);
                        }

                        if (y == LabyrinthSize - 1)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "l":
                        if (labyrinth[x, y - 1] == EmptySpaceSymbol)
                        {
                            labyrinth[x, y] = EmptySpaceSymbol;
                            labyrinth[x, y - 1] = PlayerSymbol;
                            y--;
                            currentScore++;
                        }
                        else
                        {
                            Console.WriteLine(InvalidMoveMessage);
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} Score.\n", currentScore);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "top":
                        ShowPlayer(scores);
                        Console.WriteLine("\n");
                        DisplayLabyrinth(labyrinth);
                        break;
                    case "restart":
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine(ExitMessage);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        private static void LabyrinthGenerator(string[,] labyrinth, int playerX, int playerY)
        {
            var randomInt = new Random();

            for (int i = 0; i < LabyrinthSize; i++)
            {
                for (int j = 0; j < LabyrinthSize; j++)
                {
                    labyrinth[i, j] = randomInt.Next(2).ToString();
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = EmptySpaceSymbol;
                    }
                    else
                    {
                        labyrinth[i, j] = FilledSpaceSymbol;
                    }
                }
            }

            labyrinth[playerX, playerY] = PlayerSymbol;
        }

        private static void DisplayLabyrinth(string[,] labyrinth)
        {
            for (int i = 0; i < LabyrinthSize; i++)
            {
                for (int j = 0; j < LabyrinthSize; j++)
                {
                    string currentCell = labyrinth[i, j];
                    Console.Write(currentCell + ' ');
                }

                Console.WriteLine();
            }
        }
    }
}
