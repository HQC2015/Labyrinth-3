namespace Labyrinth.Logic.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using Models.Interfaces;
    using Models.Visitors;

    public class CommandController
    {
        private readonly IPlayer player;
        private readonly List<string> commands;
        private readonly List<CommandExecutor> commandExecutors;
        private int currentCommandIndex;
        private string currentCommand;

        public CommandController(IPlayer player)
        {
            this.player = player;
            this.commands = new List<string>();
            this.commandExecutors = new List<CommandExecutor>();

            this.commandExecutors.Add(new StandartCommandExecutor(new StandartMoveVisitor()));
            this.commandExecutors.Add(new DiagonalCommandExecutor(new DiagonalMoveVisitor()));
            this.AssignResponsibilityChain(this.commandExecutors);
        }

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

        public string GetAvailableCommands()
        {
            var result = new StringBuilder();
            foreach (var commandExecutor in this.commandExecutors)
            {
                result.AppendLine(commandExecutor.ToString());
            }

            return result.ToString().TrimEnd();
        }

        private void AssignResponsibilityChain(List<CommandExecutor> commandExecutors)
        {
            for (int i = 1; i < commandExecutors.Count; i++)
            {
                var previousCommandExecutor = commandExecutors[i - 1];
                var currentCommandExecutor = commandExecutors[i];
                previousCommandExecutor.SetSuccessor(currentCommandExecutor);
            }
        }

        private void Redo()
        {
            if (this.currentCommandIndex < this.commands.Count)
            {
                string command = this.commands[(this.commands.Count - 1) - this.currentCommandIndex];
                this.commandExecutors[0].ProcessCommand(command, this.player);
                this.currentCommandIndex++;
            }
        }

        private void Undo()
        {
            if (this.currentCommandIndex > 0)
            {
                this.currentCommandIndex--;
                string command = this.commands[(this.commands.Count - 1) - this.currentCommandIndex];
                this.commandExecutors[0].UnProcessCommand(command, this.player);
            }
        }

        private void Compute()
        {
            this.commandExecutors[0].ProcessCommand(this.currentCommand, this.player);
            this.commands.Add(this.currentCommand);
            this.currentCommandIndex++;
        }
    }
}
