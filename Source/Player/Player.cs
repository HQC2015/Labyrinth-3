namespace Labyrinth.Players
{
    public class Player
    {
        public Player(int score, string name)
        {
            this.Score = score;
            this.Name = name;
        }

        public int Score { get; set; }

        public string Name { get; private set; }
    }
}
