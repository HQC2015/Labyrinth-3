namespace Labyrinth.Logic.Contracts
{
    using Models;
    using Labyrinth.Models.Contracts;
    using Models.Players;

    public interface ICommandExecutor
    {
        void Execute();

        void UnExecute();
    }
}
