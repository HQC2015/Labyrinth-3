namespace Labyrinth.Logic.Commands
{
    using System;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Models.Contracts;
    using Models.Players;
    using Models;
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
            this.moveLogic.MakeMove(command);
        }

        public void UnExecute()
        {
            this.moveLogic.MakeMove(Undo(command));
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
