namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using Scoreboard;

    public class Game
    {
        private const string WelcomeMessage = "Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nBoard,'restart' to start a new game and 'exit' to quit the game.\n ";

        private static readonly List<Board> scores = new List<Board>(4);

        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; // waiting for input.

        private static bool playing; // game in progress.
        private static bool flag; // used to prevent adding scores when restarting the game.

        private static int positionX;  // used for coordinates. rows.
        private static int positionY;  // used for coordinates. columns.

        private static int currentMoves;

        public static void Start()
        {
            positionX = positionY = 3;  // player position
            commandListener = playing = true;
            var labyrinth = new string[7, 7];

            while (playing)
            {
                Console.WriteLine(WelcomeMessage);

                mazeHasSolution = flag = false;

                while (mazeHasSolution == false)
                {
                    LabyrinthGenerator(labyrinth, positionX, positionY);
                    SolutionChecker(labyrinth, positionX, positionY);
                }

                DisplayLabyrinth(labyrinth);
                TypeCommand(labyrinth, commandListener, positionX, positionY);

                // used for adding score only when game is finished naturally and not by the restart command.
                while (flag)
                {
                    AddScore(scores, currentMoves);
                }
            }
        }

        private static void AddScore(List<Board> scores, int currentMoves)
        {
            if (scores.Count != 0)
            {
                scores.Sort(delegate(Board s1, Board s2)
                {
                    return s1.Moves.CompareTo(s2.Moves);
                });
            }

            if (scores.Count == 5)
            {
                if (scores[4].Moves > currentMoves)
                {
                    scores.Remove(scores[4]);
                    Console.WriteLine("Please enter your nickname");
                    string name = Console.ReadLine();
                    scores.Add(new Board(currentMoves, name));
                    ShowBoard(scores);
                }
            }

            if (scores.Count < 5)
            {
                Console.WriteLine("Please enter your nickname");
                string name = Console.ReadLine();
                scores.Add(new Board(currentMoves, name));
                ShowBoard(scores);
            }

            flag = false;
        }

        private static void ShowBoard(List<Board> scores)
        {
            Console.WriteLine("\n");
            if (scores.Count == 0)
            {
                Console.WriteLine("The Board is empty! ");
            }
            else
            {
                scores.Sort(delegate(Board s1, Board s2)
                {
                    return s1.Moves.CompareTo(s2.Moves);
                });

                Console.WriteLine("Top 5: \n");
                int i = 1;
                scores.ForEach(delegate(Board s)
                {
                    Console.WriteLine(string.Format(i + ". {1} ---> {0} moves", s.Moves, s.Name));
                    i++;
                });

                Console.WriteLine("\n");
            }
        }

        private static void TypeCommand(string[,] labyrinth, bool flag, int x, int y)
        {
            currentMoves = 0;

            while (flag)
            {
                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string i = string.Empty;
                i = Console.ReadLine();
                switch (i)
                {
                    case "d":
                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "D":
                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "u":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "U":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "r":
                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "R":
                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "l":
                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "L":
                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");
                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag = false;
                            Game.flag = true;
                        }

                        DisplayLabyrinth(labyrinth);
                        break;
                    case "top":
                        ShowBoard(scores);
                        Console.WriteLine("\n");
                        DisplayLabyrinth(labyrinth);
                        break;
                    case "restart":
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        private static void LabyrinthGenerator(string[,] labyrinth, int x, int y)
        {
            var randomInt = new Random();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    labyrinth[i, j] = Convert.ToString(randomInt.Next(2));
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = "-";
                    }
                    else
                    {
                        labyrinth[i, j] = "x";
                    }
                }
            }

            labyrinth[positionX, positionY] = "*";
        }

        private static void SolutionChecker(string[,] labyrinth, int x, int y)
        {
            bool checking = true;
            if (labyrinth[x + 1, y] == "x" && labyrinth[x, y + 1] == "x" && labyrinth[x - 1, y] == "x" && labyrinth[x, y - 1] == "x")
            {
                checking = false;
            }

            while (checking)
            {
                try
                {
                    if (labyrinth[x + 1, y] == "-")
                    {
                        labyrinth[x + 1, y] = "0";
                        x++;
                    }
                    else if (labyrinth[x, y + 1] == "-")
                    {
                        labyrinth[x, y + 1] = "0";
                        y++;
                    }
                    else if (labyrinth[x - 1, y] == "-")
                    {
                        labyrinth[x - 1, y] = "0";
                        x--;
                    }
                    else if (labyrinth[x, y - 1] == "-")
                    {
                        labyrinth[x, y - 1] = "0";
                        y--;
                    }
                    else
                    {
                        checking = false;
                    }
                }
                catch (Exception)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (labyrinth[i, j] == "0")
                            {
                                labyrinth[i, j] = "-";
                            }
                        }

                        checking = false;
                        mazeHasSolution = true;
                    }
                }
            }
        }

        private static void DisplayLabyrinth(string[,] labyrinth)
        {
            for (int i = 0; i < 7; i++)
            {
                string s1 = labyrinth[i, 0];
                string s2 = labyrinth[i, 1];
                string s3 = labyrinth[i, 2];
                string s4 = labyrinth[i, 3];
                string s5 = labyrinth[i, 4];
                string s6 = labyrinth[i, 5];
                string s7 = labyrinth[i, 6];

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", s1, s2, s3, s4, s5, s6, s7);
            }

            Console.WriteLine();
        }
    }
}
