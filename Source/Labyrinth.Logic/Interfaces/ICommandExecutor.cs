namespace Labyrinth.Logic.Commands
{
    using Labyrinth.Models.Interfaces;

    public interface ICommandExecutor
    {
        void Execute(string command, IPlayer player);

        string Undo(string command);
    }
}
