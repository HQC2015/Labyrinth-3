namespace Labyrinth.Logic.Commands
{
    using System;
    using Labyrinth.Models.Interfaces;
    using Labyrinth.Models.Visitors;

    public class DiagonalCommandExecutor : CommandExecutor
    {
        private readonly string availableCommands = "UR=up-right, UL=up-left, DR=down-right, DL=down-left";

        public DiagonalCommandExecutor(IVisitor visitor)
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

        public override void ProcessCommand(string command, IPlayer player)
        {
            switch (command)
            {
                case "ur":
                    this.Execute(command, player);
                    break;
                case "ul":
                    this.Execute(command, player);
                    break;
                case "dr":
                    this.Execute(command, player);
                    break;
                case "dl":
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
    }
}
