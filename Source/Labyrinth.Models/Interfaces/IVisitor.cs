using Labyrinth.Models.Interfaces;

namespace Labyrinth.Logic.Interfaces
{
    public interface IVisitor
    {
        void SetVisitCommand(string command);

        void Visit(IPlayer player);
    }
}
