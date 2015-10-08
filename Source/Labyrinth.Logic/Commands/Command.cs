using Labyrinth.Common;
using Labyrinth.Logic.Contracts;
using Labyrinth.Logic.Interfaces;
using Labyrinth.Models;
using System;
using System.Collections.Generic;

namespace Labyrinth.Logic.Commands
{
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
                case "top":
                    this.Top();
                    break;
                case "exit":
                    this.Exit();
                    break;
                case "restart":
                    this.Restart();
                    break;
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
                    this.Compute(moveLogic);
                    break;
                default:
                    this.Invalid();
                    break;
            }
        }

        public string Invalid()
        {
            return "Invalid command";
        }

        public string Restart()
        {
            return this.currentCommand;
        }

        public string Exit()
        {
            return this.currentCommand;
        }

        public string Top()
        {
            return this.currentCommand;
        }

        public void Redo(MoveLogic moveLogic)
        {
            if (this.currentCommandIndex < this.commands.Count - 1)
            {
                var command = this.commands[this.currentCommandIndex++];
                this.commandExecutor = new CommandExecutor(command, moveLogic);
                this.commandExecutor.Execute();
                this.currentCommandIndex++;
            }
        }

        public void Undo(MoveLogic moveLogic)
        {
            if (this.currentCommandIndex > 0)
            {
                var command = this.commands[--this.currentCommandIndex];
                this.commandExecutor = new CommandExecutor(command, moveLogic);
                this.commandExecutor.UnExecute();
                this.currentCommandIndex--;
            }
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
