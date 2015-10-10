using Labyrinth.Models.Interfaces;

namespace Labyrinth.Logic.Commands
{
    public interface IVisitor
    {
        void SetVisitCommand(string command);

        void Visit(IPlayer player);
    }
}
