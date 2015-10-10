namespace Labyrinth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Players;

    public class Scoreboard
    {
        private static readonly Lazy<Scoreboard> InstanceOfScoreboard = new Lazy<Scoreboard>(() => new Scoreboard());
        private List<Player> playersWithScore = new List<Player>();

        public static Scoreboard Instance
        {
            get
            {
                return InstanceOfScoreboard.Value;
            }
        }

        public List<Player> GetPlayers
        {
            get
            {
                return this.playersWithScore.ToList<Player>();
            }
        }

        public void AddScore(Player playerWithScore)
        {
            if (this.playersWithScore.Count < 5)
            {
                this.playersWithScore.Add(playerWithScore);
            }
            else if (this.playersWithScore.Count >= 5)
            {
                if (this.playersWithScore[4].GetScore() < playerWithScore.GetScore())
                {
                    this.playersWithScore.Remove(this.playersWithScore[4]);
                    this.playersWithScore.Add(playerWithScore);
                }
            }

            this.playersWithScore = this.playersWithScore.OrderBy(s => s.GetScore()).ToList();
        }
    }
}
