

namespace Labyrinth.Models.Interfaces
{
    using Labyrinth.Logic.Commands;
    using Players;

    public interface IPlayer : IVisitable
    {
        Player SetName(string name);

        Player SetX(int x);

        Player SetY(int y);

        Player SetScore(int score);

        string GetName();

        int GetX();

        int GetY();

        int GetScore();

        string Print();
        
    }
}
