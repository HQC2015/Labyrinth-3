namespace Labyrinth.Logic.Commands
{
    using Labyrinth.Models.Interfaces;

    public abstract class CommandReceiver
    {
        protected IVisitor visitor;

        protected CommandExecutor Successor { get; set; }

        public void SetSuccessor(CommandExecutor successor)
        {
            this.Successor = successor;
        }

        protected virtual void Execute(string command, IPlayer player)
        {
            this.visitor.SetVisitCommand(command);
            player.Accept(this.visitor);
        }
    }
}
