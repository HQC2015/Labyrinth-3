namespace Labyrinth.Logic.Contracts
{
    using Models;
    using Labyrinth.Models.Contracts;

    public interface IGameRule
    {
        void SetGame(Board board);
    }
}
