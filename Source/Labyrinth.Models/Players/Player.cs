namespace Labyrinth.Models.Players
{
    using Labyrinth.Logic.Interfaces;
    using Labyrinth.Models.Interfaces;

    public class Player : IPlayer
    {
        private readonly PlayerContext context = new PlayerContext();

        public Player SetName(string name)
        {
            this.context.Name = name;
            return this;
        }

        public Player SetX(int x)
        {
            this.context.X = x;
            return this;
        }

        public Player SetY(int y)
        {
            this.context.Y = y;
            return this;
        }

        public Player SetScore(int score)
        {
            this.context.Score = score;
            return this;
        }

        public string GetName()
        {
            return this.context.Name;
        }

        public int GetX()
        {
            return this.context.X;
        }

        public int GetY()
        {
            return this.context.Y;
        }

        public int GetScore()
        {
            return this.context.Score;
        }

        public string Print()
        {
            return string.Format(". {1} ---> {0} Score", this.context.Score, this.context.Name);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
