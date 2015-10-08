using Labyrinth.Common;
using Labyrinth.Logic.Contracts;
using Labyrinth.Models;
using System;
using System.Collections.Generic;

namespace Labyrinth.Logic.Commands
{
    public class Command
    {
        private List<string> commands = new List<string>();
        private int currentCommandIndex;
        private string command;
        private IInputHandler inputHandler;

        public Command(IInputHandler inputHandler)
        {
            this.inputHandler = inputHandler;
        }

        public void Start(MoveLogic moveLogic)
        {
            this.command = inputHandler.GetInput().ToLower();
            switch (this.command)
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
                    this.Undo(moveLogic);
                    break;
                case "f":
                    this.Redo(moveLogic);
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
            return this.command;
        }

        public string Exit()
        {
            return this.command;
        }

        public string Top()
        {
            return this.command;
        }

        public void Redo(MoveLogic moveLogic)
        {
            if (this.currentCommandIndex < this.commands.Count - 1)
            {
                var command = this.commands[this.currentCommandIndex++];
                CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
                commandForExecution.Execute();
                this.currentCommandIndex++;
            }
        }

        public void Undo(MoveLogic moveLogic)
        {
            if (this.currentCommandIndex > 0)
            {
                var command = this.commands[--this.currentCommandIndex];
                CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
                commandForExecution.UnExecute();
                this.currentCommandIndex--;
            }
        }

        public void Compute(MoveLogic moveLogic)
        {
            CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
            commandForExecution.Execute();

            this.commands.Add(command);
            this.currentCommandIndex++;
        }
    }
}
