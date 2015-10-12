namespace Labyrinth.Logic.Commands
{
    using Interfaces;
    using Models.Interfaces;

    public abstract class CommandExecutor : CommandReceiver, ICommandExecutor
    {
        protected abstract string AvailableCommands { get; }

        public abstract string InvertCommand(string command);

        public abstract void ProcessCommand(string command, IPlayer player);

        public abstract void UnProcessCommand(string command, IPlayer player);

        public override string ToString()
        {
            return this.AvailableCommands;
        }
    }
}
