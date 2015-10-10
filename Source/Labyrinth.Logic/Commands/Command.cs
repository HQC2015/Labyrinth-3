﻿namespace Labyrinth.Logic.Commands
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models.Interfaces;

    public class Command
    {
        private readonly List<string> commands;
        private int currentCommandIndex;
        private string currentCommand;

        private readonly CommandReceiver standartCommandExecutor;
        private readonly CommandReceiver diagonalCommandExecutor;
        private readonly IPlayer player;

        public Command(IPlayer player)
        {
            this.commands = new List<string>();
            this.standartCommandExecutor = new StandartCommandExecutor();
            this.diagonalCommandExecutor = new DiagonalCommandExecutor();
            this.standartCommandExecutor.SetSuccessor(this.diagonalCommandExecutor);
            this.player = player;
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
                case "d":
                case "u":
                case "l":
                case "r":
                    // ADD MORE CASES AND Chain Of Responsibility Pattern will take care going in DiagonalCommandExecutor
                    this.Compute();
                    break;
                default:
                    throw new ArgumentException("Invalid command");
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

        public void Redo()
        {
            if (this.currentCommandIndex < this.commands.Count)
            {
                var command = this.commands[this.currentCommandIndex];
                this.standartCommandExecutor.ProcessCommand(command, this.player);
                this.currentCommandIndex++;
            }
        }

        public void Undo()
        {
            if (this.currentCommandIndex > 0)
            {
                this.currentCommandIndex--;
                var command = this.commands[this.currentCommandIndex];
                this.standartCommandExecutor.UnProcessCommand(command, this.player);
            }
        }

        public void Compute()
        {
            this.standartCommandExecutor.ProcessCommand(this.currentCommand, this.player);
            this.commands.Add(this.currentCommand);
            this.currentCommandIndex++;
        }
    }
}
