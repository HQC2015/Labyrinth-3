namespace Labyrinth.Logic.Interfaces
{
    using Observer;

    public abstract class MoveLogic : IObservered
    {
        public PlayerObserver Observer;
        protected int playerX;
        protected int playerY;
        protected int currentScore;

        public void Update(int currentScore, int playerX, int playerY)
        {
            this.currentScore = currentScore;
            this.playerX = playerX;
            this.playerY = playerY;
        }

        public abstract void MakeMove(string command);
    }
}
