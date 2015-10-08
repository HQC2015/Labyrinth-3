namespace Labyrinth.Logic.Interfaces
{
    // MIGHT BE BETTER TO BE ABSTRACT CLASS BECAUSE OF OTHER COMMAND EXECUTORS SUCH AS StandartCommandExecutor, UniqueCommandExecutor
    public interface ICommandExecutor
    {
        void Execute();

        void UnExecute();
    }
}
