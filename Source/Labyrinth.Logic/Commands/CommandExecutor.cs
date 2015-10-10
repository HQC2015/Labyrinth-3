namespace Labyrinth.Logic.Commands
{
    using System;
    using Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly string command;
        private readonly MoveLogic moveLogic;

        public CommandExecutor(string command, MoveLogic moveLogic)
        {
            this.command = command;
            this.moveLogic = moveLogic;
        }

        public void Execute()
        {
            this.moveLogic.MakeMove(this.command);
        }

        public void UnExecute()
        {
            this.moveLogic.MakeMove(this.Undo(this.command));
        }

        public string Undo(string command)
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
                    throw new ArgumentException("wrong command");
            }
        }
    }
}
