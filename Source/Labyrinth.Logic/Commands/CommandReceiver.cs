namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Models.Interfaces;

    public abstract class CommandReceiver
    {
        protected CommandReceiver Successor { get; set; }

        public void SetSuccessor(CommandReceiver successor)
        {
            this.Successor = successor;
        }

        public abstract void ProcessCommand(string command, IPlayer player);

        public abstract void UnProcessCommand(string command, IPlayer player);
    }
}
