namespace Labyrinth.Scoreboard
{
    public class Board
    {
        public Board(int moves, string name)
        {
            this.Moves = moves;
            this.Name = name;
        }

        public int Moves { get; private set; }

        public string Name { get; private set; }
    }
}
