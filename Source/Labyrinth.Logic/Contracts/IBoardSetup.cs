namespace Labyrinth.Logic.Contracts
{
    using Models;
    using Labyrinth.Models.Contracts;
    using Models.Players;

    public interface IBoardSetup
    {
        void SetGame(Board board);
    }
}
