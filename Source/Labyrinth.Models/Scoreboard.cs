namespace Labyrinth.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Labyrinth.Models.Players;

    public class Scoreboard
    {
        private static readonly Lazy<Scoreboard> instance = new Lazy<Scoreboard>(() => new Scoreboard());
        private List<Player> playersWithScore = new List<Player>();

        public static Scoreboard Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<Player> GetPlayers
        {
            get
            {
                return playersWithScore.ToList<Player>();
            }
        }

        public void AddScore(Player playerWithScore)
        {
            if (playersWithScore.Count < 5)
            {
                playersWithScore.Add(playerWithScore);
            }
            else if (playersWithScore.Count >= 5)
            {
                if (playersWithScore[4].GetScore() < playerWithScore.GetScore())
                {
                    playersWithScore.Remove(playersWithScore[4]);
                    playersWithScore.Add(playerWithScore);
                }
            }

            playersWithScore = playersWithScore.OrderBy(p => p.GetScore()).ToList();
        }
    }
}
