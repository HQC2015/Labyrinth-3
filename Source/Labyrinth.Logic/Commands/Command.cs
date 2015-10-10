namespace Labyrinth.Logic.Commands
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Common;
    using Labyrinth.Logic.Contracts;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models;

    public class Command
    {
        private readonly List<string> commands;
        private readonly MoveLogic moveLogic;

        private int currentCommandIndex;
        private string currentCommand;
        private CommandExecutor commandExecutor;

        public Command(MoveLogic moveLogic)
        {
            this.commands = new List<string>();
            this.moveLogic = moveLogic;
        }

        public void ProcessCommand(string command)
        {
            this.currentCommand = command;
            switch (command)
            {
                case "b":
                    this.Undo(this.moveLogic);
                    break;
                case "f":
                    this.Redo(this.moveLogic);
                    break;
                case "d":
                case "u":
                case "l":
                case "r":
                    this.Compute(this.moveLogic);
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        public void Redo(MoveLogic moveLogic)
        {
            var command = this.commands[this.currentCommandIndex++];
            this.commandExecutor = new CommandExecutor(command, moveLogic);
            this.commandExecutor.Execute();
            this.currentCommandIndex++;
        }

        public void Undo(MoveLogic moveLogic)
        {
            var command = this.commands[--this.currentCommandIndex];
            this.commandExecutor = new CommandExecutor(command, moveLogic);
            this.commandExecutor.UnExecute();
            this.currentCommandIndex--;
        }

        public void Compute(MoveLogic moveLogic)
        {
            this.commandExecutor = new CommandExecutor(this.currentCommand, moveLogic);
            this.commandExecutor.Execute();

            this.commands.Add(this.currentCommand);
            this.currentCommandIndex++;
        }
    }
}
