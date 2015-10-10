namespace Labyrinth.Logic.Commands
{
    using Labyrinth.Models.Interfaces;

    public interface IVisitor
    {
        void SetVisitCommand(string command);

        void Visit(IPlayer player);
    }
}
