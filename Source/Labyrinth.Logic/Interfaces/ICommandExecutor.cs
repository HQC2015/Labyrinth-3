namespace Labyrinth.Logic.Interfaces
{
    using Labyrinth.Models.Interfaces;

    public interface ICommandExecutor
    {
        void ProcessCommand(string command, IPlayer player);

        void UnProcessCommand(string command, IPlayer player);

        string InvertCommand(string command);
    }
}
