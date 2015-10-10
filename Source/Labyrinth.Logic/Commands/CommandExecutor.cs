namespace Labyrinth.Logic.Commands
{
    using Labyrinth.Models.Interfaces;

    public abstract class CommandExecutor
    {
        protected CommandExecutor Successor { get; set; }

        public void SetSuccessor(CommandExecutor successor)
        {
            this.Successor = successor;
        }

        public abstract void ProcessCommand(string command, IPlayer player);

        public abstract void UnProcessCommand(string command, IPlayer player);
    }
}
