High-Quality Programming Code – Team 'Labyrinth-3'
=============================================

#### [More detailed information about the Assignment](https://github.com/TelerikAcademy/High-Quality-

Code/tree/master/Teamwork "TelerikAcademy High-Quality-Code")

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
#### Refactoring the entire project
---
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

#### Implementing Design Patterns
---
1.  Added **Creational patterns**
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

2.  Added **Behaviour patterns**
	- **Command** used to deal with the user input commands
	    - added new interface ICommndExecutor - for more abstraction
	    ```c#
        public interface ICommandExecutor
        {
            void ProcessCommand(string command, IPlayer player);

            void UnProcessCommand(string command, IPlayer player);

            string InvertCommand(string command);
        }
        ```
        - added new abstract class `CommandExecutor.cs` so all CommandExecutors should implement it, also it combines **Chain of Responsibility** design pattern using `CommandReceiver.cs`; AvailableCommands field is used so that every child should state its implemented commands
        ```c#
        public abstract class CommandExecutor : CommandReceiver, ICommandExecutor
        {
            protected abstract string AvailableCommands { get; }

            public abstract string InvertCommand(string command);

            public abstract void ProcessCommand(string command, IPlayer player);

            public abstract void UnProcessCommand(string command, IPlayer player);

            public override string ToString()
            {
                return this.AvailableCommands;
            }
        }
        ```
		- added new class `CommandController.cs`
			- field for saving coomands 
			```c#
            private readonly List<string> commands;
            ```
			- ProcessCommand method
			```c#
            public void ProcessCommand(string command)
            {
                this.currentCommand = command;
                switch (command)
                {
                    case "b":
                        this.Undo();
                        break;
                    case "f":
                        this.Redo();
                        break;
                    default:
                        this.Compute();
                        break;
                }
            }
            ```
			- *Undo()* and *Redo()* functionality, works with commands field to get the right command, then passes it to the commandExecutors chain calling on the first commandExecutor.ProcessCommand()
			```c#
		    private void Undo()
            {
                if (this.currentCommandIndex > 0)
                {
                    this.currentCommandIndex--;
                    string command = this.commands[this.currentCommandIndex];
                    this.commandExecutors[0].UnProcessCommand(command, this.player);
                }
            }
            ```
            ```c#
            private void Redo()
            {
                if (this.currentCommandIndex < this.commands.Count)
                {
                    string command = this.commands[this.currentCommandIndex];
                    this.commandExecutors[0].ProcessCommand(command, this.player);
                    this.currentCommandIndex++;
                }
            }
			```
			- also *Compute()* method for processing any command different to Undo and Redo, then passes it to the commandExecutors chain calling on the first commandExecutor.ProcessCommand()
			```c#
			private void Compute()
            {
                this.commandExecutors[0].ProcessCommand(this.currentCommand, this.player);
                this.commands.Add(this.currentCommand);
                this.currentCommandIndex++;
            }
			```
			- *GetAvailableCommands()* method which prints the commands of the CommandExecutors in the responsibility chain
			```c#
			public string GetAvailableCommands()
            {
                var result = new StringBuilder();
                foreach (var commandExecutor in this.commandExecutors)
                {
                    result.AppendLine(commandExecutor.ToString());
                }

                return result.ToString().TrimEnd();
            }
			```
		- added new class `StandartCommandExecutor.cs`
			- *ProcessCommand()* method to process the right command, using the **Visitor** to move player
			```c#
			public override void ProcessCommand(string command, IPlayer player)
            {
                switch (command)
                {
                    case "d":
                        this.Execute(command, player);
                        break;
                    case "u":
                        this.Execute(command, player);
                        break;
                    case "l":
                        this.Execute(command, player);
                        break;
                    case "r":
                        this.Execute(command, player);
                        break;
                    default:
                        if (this.Successor != null)
                        {
                            this.Successor.ProcessCommand(command, player);
                        }
                        else
                        {
                            throw new InvalidGameCommandException("Invalid game move!");
                        }

                        break;
                }
            }
			```
        	- *InvertCommand()* method to replace the command with it oposite command for back move
        	```c#
        	public override string InvertCommand(string command)
            {
                switch (command)
                {
                    case "d":
                        return "u";
                    case "u":
                        return "d";
                    case "l":
                        return "r";
                    case "r":
                        return "l";
                    default:
                        return command;
                }
            }
        	```
        	- *UnProcessCommand()* method which uses *InvertCommand()* to do the Undo functionallity
        	```c#
        	public override void UnProcessCommand(string command, IPlayer player)
            {
                string invertedCommand = this.InvertCommand(command);
                if (invertedCommand == command && this.Successor != null)
                {
                    this.Successor.UnProcessCommand(command, player);
                }
                else
                {
                    this.ProcessCommand(invertedCommand, player);
                }
            }
        	```
		- added new class `DiagonalCommandExecutor.cs` which has the same functionalities but with different key commands such as
		```c#
		public override string InvertCommand(string command)
        {
            switch (command)
            {
                case "ur":
                    return "dl";
                case "ul":
                    return "dr";
                case "dr":
                    return "ul";
                case "dl":
                    return "ur";
                default:
                    return command;
            }
        }
		```
	- **Chain of Responsibility** used to find the one CommandExecutor who understands the input command 
	    - added new abstract class `CommandReceiver.cs` which is responsible for the chain
	        - field for successor (the one in the chain who can do the operation)
	        ```c#
	        protected CommandExecutor Successor { get; set; }
	        ```
	        - method *SetSuccessor()* to assign the sucessor
	        ```c#
	        public void SetSuccessor(CommandExecutor successor)
            {
                this.Successor = successor;
            }
	        ```
	        - method *Execute()* so that the successor do its job, it also uses the implemented **Visitor** pattern
	        ```c#
	        protected virtual void Execute(string command, IPlayer player)
            {
                this.Visitor.SetVisitCommand(command);
                player.Accept(this.Visitor);
            }
	        ```
	- **Visitor** used to change the `Player.cs` coordinates and score
	    - added new interface `IVisitor.cs`
	    ```c#
	    public interface IVisitor
        {
            void SetVisitCommand(string command);

            void Visit(IPlayer player);
        }
	    ```
	    - added new interface `IVisitable.cs`
	    ```c#
        public interface IVisitable
        {
            void Accept(IVisitor visitor);
        }
	    ```
	    - added a property to the abstract class `CommandReceiver.cs`
	    ```c#
	    protected IVisitor Visitor { get; set; }
	    ```
	    - added class `StandartMoveVisitor.cs`
	        - field for command that must be executed on the IVisitable object
	        ```c#
	        private string command;
	        ```
	        - method *SetVisitCommand()* to set that command
	        ```c#
	        public void SetVisitCommand(string command)
            {
                this.command = command;
            }
	        ```
	        - method *Visit()* to modify the IVisitable object(Player)
	        ```c#
	        public void Visit(IPlayer player)
            {
                switch (this.command.ToLower())
                {
                    case "d":
                        if (Board.Instance.AreSymbolsEqual(player.GetX() + 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            player.SetX(player.GetX() + 1);
                            player.SetScore(player.GetScore() + 1);
                        }

                        break;
                    case "u":
                        if (Board.Instance.AreSymbolsEqual(player.GetX() - 1, player.GetY(), SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            player.SetX(player.GetX() - 1);
                            player.SetScore(player.GetScore() + 1);
                        }

                        break;
                    case "r":
                        if (Board.Instance.AreSymbolsEqual(player.GetX(), player.GetY() + 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            player.SetY(player.GetY() + 1);
                            player.SetScore(player.GetScore() + 1);
                        }

                        break;
                    case "l":
                        if (Board.Instance.AreSymbolsEqual(player.GetX(), player.GetY() - 1, SymbolFactory.GetSymbol(SymbolsEnum.EmptySpace)))
                        {
                            player.SetY(player.GetY() - 1);
                            player.SetScore(player.GetScore() + 1);
                        }

                        break;
                }
            }
	        ```
	    
3.  Added **Structural Patterns**

#### Unit tests
---

#### Added functionalities
---
1.  Diagonal Movement





