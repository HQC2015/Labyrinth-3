High-Quality Programming Code – Team 'Labyrinth-3'
=============================================

#### [More detailed information about the Assignment](https://github.com/TelerikAcademy/High-Quality-Code/tree/master/Teamwork "TelerikAcademy High-Quality-Code")

Team Members
--------

* kossov - Огнян Коссов
* tabula - Тошко Попов
* half.human - Радослав Ангелов
* ventsislav.a.ivanov - Венцислав Иванов
* StanimiraHK - Станимира Кормева
* tomi.hristov.5 - Томи Христов

Refactoring Documentation
------------------------------------------------------
1.  Redesigned the project structure: Team "Labyringth-3"
	-   Renamed the project solution from `kursov_proekt` to `Labyrinth-3`.
	-   Extracted from the main file `Program.cs`, each class in separate file - `Game.cs`, `Player.cs` etc.
2.  Reformatted the source code:
	-   Removed all unneeded empty lines, e.g. in the method TypeCommand().
	-   Inserted empty lines between the methods.
	-   Split the lines containing several statements into several simple lines, e.g.:
	
	Before:
	
		if (labyrinth[i, j] == "0") { labyrinth[i, j] = "-"; } else { labyrinth[i, j] = "x"; }
		
	After:

		if (labyrinth[i, j] == "0")
        {
            labyrinth[i, j] = "-";
        }
        else
        {
            labyrinth[i, j] = "x";
        }
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
3.  Extracted constants:
	-   In class `Game.cs`
        * WelcomeMessage = "Welcome to \"Labyrinth\" game, where you try to escape!\nUse 'top' to view the top players\n'restart' to start a new game\n'exit' to quit the game.\n "
        * PlayerStartPositionX = 3
        * PlayerStartPositionY = 3
        * LabyrinthSize = 7
        * PlayerSymbol = "*"
        * EmptySpaceSymbol = "-"
        * FilledSpaceSymbol = "x"
        * EnterMoveMessage = "Enter your move (L=left, R=right, D=down, U=up): "
        * InvalidMoveMessage = "Invalid move!"
        * ScoreboardEnterNicknameMessage = "Please enter your nickname"
        * ScoreboardEmptyMessage = "The Scoreboard is empty!"
        * ExitMessage = "GoodBye!"
4.  Changed DisplayLabyrinth() logic
	
5.  Added **Creational patterns**
	- **Singleton**
		-  used for `Board.cs`
        ```c#
        public class Board
        {
            private static readonly Lazy<Board> InstanceOfBoard = new Lazy<Board>(() => new Board(GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol));

            private Board(int labyrinthSizeRow, int labyrinthSizeCol)
            {
                this.Field = new ISymbol[labyrinthSizeRow, labyrinthSizeCol];
            }

            public static Board Instance
            {
                get
                {
                    return InstanceOfBoard.Value;
                }
            }
        ```
		-  used for `Scoreboard.cs`
        ```c#
        public class Scoreboard
        {
            private static readonly Lazy<Scoreboard> InstanceOfScoreboard = new Lazy<Scoreboard>(() => new Scoreboard());
            private List<IPlayer> playersWithScore = new List<IPlayer>();

            public static Scoreboard Instance
            {
                get
               {
                    return InstanceOfScoreboard.Value;
                }
            }
        ```
    - **Lazy Load**
        - used for `Board.cs`
        ```c#
        private static readonly Lazy<Board> InstanceOfBoard = new Lazy<Board>(() => new Board(GlobalConstants.LabyrinthSizeRow, GlobalConstants.LabyrinthSizeCol));
        ```
        - used for `Scoreboard.cs`
        ```c#
        private static readonly Lazy<Scoreboard> InstanceOfScoreboard = new Lazy<Scoreboard>(() => new Scoreboard());
        ```
    - **Lazy Initialization**
        - used in class `SymbolFactory.cs` for GetSymbol() method
        ```c#
        public static class SymbolFactory
        {
            private static readonly Dictionary<SymbolsEnum, ISymbol> Symbols = new Dictionary<SymbolsEnum, ISymbol>();

            public static ISymbol GetSymbol(SymbolsEnum key)
            {
                // Uses "lazy initialization"
                ISymbol symbol = null;
                if (Symbols.ContainsKey(key))
                {
                    symbol = Symbols[key];
                }
                else
                {
                    switch (key)
                    {
                        case SymbolsEnum.EmptySpace:
                            symbol = new EmptySpaceSymbol();
                            break;
                        case SymbolsEnum.FilledSpace:
                            symbol = new FilledSpaceSymbol();
                            break;
                        case SymbolsEnum.Player:
                            symbol = new PlayerSymbol();
                            break;
                        case SymbolsEnum.Check:
                            symbol = new CheckSymbol();
                            break;
                        default:
                            throw new InvalidOperationException("Wrong key for the SymbolFactory.GetSymbol(SymbolsEnum)");
                    }

                    Symbols.Add(key, symbol);
                }

                return symbol;
            }
        }
        ```
	- **Fluent Interface**
    	- on `Player.cs` using `PlayerContext.cs`
        ```c#
        public class Player : IPlayer
        {
            private readonly PlayerContext context;

            public Player()
            {
                this.context = new PlayerContext();
            }

            public Player(PlayerContext context)
            {
                this.context = context;
            }

            public Player SetName(string name)
            {
                this.context.Name = name;
                return this;
            }

            public Player SetX(int x)
            {
                this.context.X = x;
                return this;
            }

            public Player SetY(int y)
            {
                this.context.Y = y;
                return this;
            }

            public Player SetScore(int score)
            {
                this.context.Score = score;
                return this;
            }

            public string GetName()
            {
                return this.context.Name;
            }

            public int GetX()
            {
                return this.context.X;
            }

            public int GetY()
            {
                return this.context.Y;
            }

            public int GetScore()
            {
                return this.context.Score;
            }
        ```

6.  Added **Behaivor patterns**
	- Command
		- added new class `CommandController.cs`
			- private List<string> commands - field for saving coomands 
			- ProcessCommand
			- Undo( ) and Redo( ) functionality - works with commands field to get the right command, then passes it to the commandExecutors chain calling the first commandExecutor.ProcessCommand( )
			- ProcessCommand( ) - processes command to CommandExecutor or throw exception if it is invalid
			- Compute () - process the command to CommandExecutor

		- added new class CommandExecutor.cs
			- Execute(), UnExecute() - Process the right command to MoveLogic 
        	- Undo() - replace the command with it oposite command for back move
		- added new interfase ICommndExecutor - for more abstraction

		- added new class MoveLogic.cs
			- class where we put all move logic and it is inherit IMoveLogic so we can implement new kind of 

MoveLogic in any time
			
	- Observer

		- added new class PlayerObserver.cs
			- class for observing player coordinates, used for removing dependency between MoveLogic and 

Renderer.
			- List<IObservered> listeners - save all objects who need player coordinates.
			- Attach(IObservered listener), Dettach(IObservered listener) - methods for adding and removing 

listeners 
			- Notify() - method who inform listeners for changing any player coordinates or current score, work in 

all properties setters
			- <set
                this.playerY = value;
                this.Notify();>

		- added new interface IObservered - strange name because of conflict with the c# IObservable
			- Update() - set new coordinates and current score in listeners 
	- Memento
		- added class Save.cs

7.  Added **Structural Patterns**

8.  Unit tests
	





