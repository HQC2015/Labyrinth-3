namespace Labyrinth.Models.Players
{
    public class Player
    {
        private readonly PlayerContext context = new PlayerContext();

        public Player SetName(string name)
        {
            this.context.Name = name;
            return this;
        }

        public Player SetScore(int score)
        {
            this.context.Score = score;
            return this;
        }

        public int GetScore()
        {
            return this.context.Score;
        }

        public string Print()
        {
            return string.Format(". {1} ---> {0} Score", this.context.Score, this.context.Name);
        }
    }
}
