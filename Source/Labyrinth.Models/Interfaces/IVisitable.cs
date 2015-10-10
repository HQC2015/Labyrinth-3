namespace Labyrinth.Models.Interfaces
{
    using Labyrinth.Logic.Interfaces;

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
