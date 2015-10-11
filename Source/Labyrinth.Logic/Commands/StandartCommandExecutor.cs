namespace Labyrinth.Logic.Commands
{
    using System;
    using Labyrinth.Models.Interfaces;
    using Labyrinth.Models.Visitors;

    public class StandartCommandExecutor : CommandExecutor
    {
        private readonly string availableCommands = "L=left, R=right, D=down, U=up";

        public StandartCommandExecutor(IVisitor visitor)
        {
            this.visitor = visitor;
        }

        protected override string AvailableCommands
        {
            get
            {
                return this.availableCommands;
            }
        }

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

        public override void UnProcessCommand(string command, IPlayer player)
        {
            string invertedCommand = this.InvertCommand(command);
            if (invertedCommand == command && this.Successor != null)
            {
                this.Successor.UnProcessCommand(command, player);
            }
            else
            {
                this.ProcessCommand(this.InvertCommand(command), player);
            }
        }

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

        public override string ToString()
        {
            return this.availableCommands;
        }
    }
}
