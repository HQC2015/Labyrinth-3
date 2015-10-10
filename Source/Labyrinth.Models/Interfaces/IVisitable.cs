namespace Labyrinth.Models.Interfaces
{
    using Labyrinth.Logic.Commands;

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
