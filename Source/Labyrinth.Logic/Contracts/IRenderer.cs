namespace Labyrinth.Logic.Contracts
{
    using Models;

    public interface IRenderer
    {
        void RenderMessage();

        void RenderMessage(string msg);

        void RenderBoard(Board board);

        void RenderScoreboard(Scoreboard scoreboard);
    }
}
