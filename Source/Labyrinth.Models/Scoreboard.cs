namespace Labyrinth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Labyrinth.Models.Players;
    using Interfaces;

    public class Scoreboard
    {
        private static readonly Lazy<Scoreboard> instanceOfScoreboard = new Lazy<Scoreboard>(() => new Scoreboard());
        private List<IPlayer> playersWithScore = new List<IPlayer>();

        public static Scoreboard Instance
        {
            get
            {
                return instanceOfScoreboard.Value;
            }
        }

        public List<IPlayer> GetPlayers
        {
            get
            {
                return this.playersWithScore.ToList<IPlayer>();
            }
        }

        public void AddScore(IPlayer playerWithScore)
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
            this.playersWithScore = this.playersWithScore.OrderBy(p => p.GetScore()).ToList();
        }
    }
}
