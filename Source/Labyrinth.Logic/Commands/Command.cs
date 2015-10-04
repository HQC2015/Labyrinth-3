using Labyrinth.Common;
using Labyrinth.Logic.Contracts;
using Labyrinth.Models;
using System;
using System.Collections.Generic;

namespace Labyrinth.Logic.Commands
{
    public class Command
    {
        private MoveLogic moveLogic;
        private List<string> commands = new List<string>();
        private int currentCommandIndex;
        private string command;
        private IInputHandler inputHandler;
        private IRenderer renderer;

        public Command()
        {
            this.command = inputHandler.GetInput();
        }

        public void Start()
        {
            renderer.RenderMessage(Messages.EnterMoveMessage);
            switch (this.command.ToLower())
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
                    this.Undo();
                    break;
                case "f":
                    this.Redo();
                    break;
                default:
                    this.renderer.RenderMessage("Invalid command!");
                    break;
            }
        }

        public void Restart()
        {

        }

        public void Exit()
        {

        }

        public void Top()
        {
            this.renderer.RenderScoreboard(Scoreboard.Instance);
            this.renderer.RenderMessage("\n");
            this.renderer.RenderBoard(Board.Instance);
        }

        public void Redo()
        {
            if (this.currentCommandIndex < this.commands.Count - 1)
            {
                var command = this.commands[this.currentCommandIndex++];
                CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
                commandForExecution.Execute();
                this.currentCommandIndex++;
            }
        }

        public void Undo()
        {
            if (this.currentCommandIndex > 0)
            {
                var command = this.commands[--this.currentCommandIndex];
                CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
                commandForExecution.UnExecute();
                this.currentCommandIndex--;
            }
        }

        public void Compute()
        {
            CommandExecutor commandForExecution = new CommandExecutor(command, moveLogic);
            commandForExecution.Execute();

            this.commands.Add(command);
            this.currentCommandIndex++;
        }
    }
}
