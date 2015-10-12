namespace LabirynthTests
{
    using System.Collections.Generic;
    using Labyrinth.Models;
    using Labyrinth.Models.Players;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void IsScoreboardInstaceIsSingle()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            Scoreboard scoreboard2 = Scoreboard.Instance;
            Assert.AreSame(scoreboard, scoreboard2);
        }

        [TestMethod]
        public void IsScoreboardAddPlayer()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            var player = new Player();
            player.SetScore(5);
            player.SetName("Pesho");
            scoreboard.AddScore(player);
            Assert.AreEqual(1, scoreboard.GetPlayers.Count);
        }

        [TestMethod]
        public void IsScoreboardAddPlayerAfterThereIsAlreadyFivePlayers()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            for (int i = 1; i <= 5; i++)
            {
                var player = new Player();
                player.SetScore(i);
                player.SetName(i + " Pesho");
                scoreboard.AddScore(player);
            }

            var newPlayer = new Player();
            newPlayer.SetScore(2);
            newPlayer.SetName("Pesho");
            scoreboard.AddScore(newPlayer);
            Assert.AreEqual(5, scoreboard.GetPlayers.Count);
        }

        [TestMethod]
        public void IsScoreboardAddPlayerAfterThereIsAlreadyFivePlayersAndNewPlayerHasWorstResult()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            for (int i = 1; i <= 5; i++)
            {
                var player = new Player();
                player.SetScore(i);
                player.SetName(i + " Pesho");
                scoreboard.AddScore(player);
            }

            var newPlayer = new Player();
            newPlayer.SetScore(8);
            newPlayer.SetName("Pesho");
            scoreboard.AddScore(newPlayer);
            Assert.AreEqual(5, scoreboard.GetPlayers.Count);
        }

        [TestMethod]
        public void IsScoreboardReturnRightListOfPlayers()
        {
            Scoreboard scoreboard = Scoreboard.Instance;
            var listOfPlayers = new List<Player>();
            for (int i = 1; i <= 5; i++)
            {
                var player = new Player();
                player.SetScore(i);
                player.SetName(i + " Pesho");
                scoreboard.AddScore(player);
                listOfPlayers.Add(player);
            }

            Assert.ReferenceEquals(Scoreboard.Instance.GetPlayers, listOfPlayers);
        }
    }
}
