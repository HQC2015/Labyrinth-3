namespace Labyrinth.Logic.Commands
{
    using Interfaces;
    using Models.Interfaces;
    using Models.Visitors;

    public class StandartCommandExecutor : CommandReceiver, ICommandExecutor
    {
        private readonly IVisitor visitor;

        public StandartCommandExecutor()
        {
            this.visitor = new StandartMoveLogicVisitor();
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
                    break;
            }
        }

        public override void UnProcessCommand(string command, IPlayer player)
        {
            this.ProcessCommand(Undo(command), player);
        }

        public void Execute(string command, IPlayer player)
        {
            this.visitor.SetVisitCommand(command);
            player.Accept(this.visitor);
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
                    return command;
            }
        }
    }
}
