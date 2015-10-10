using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Models;
using Labyrinth.Models.Players;
using System.Collections.Generic;

namespace LabirynthTests
{
    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void IsScoreboardInstaceIsSingle()
        {
            var scoreboard = Scoreboard.Instance;
            var scoreboard2 = Scoreboard.Instance;
            Assert.AreSame(scoreboard, scoreboard2);
        }

        [TestMethod]
        public void IsScoreboardAddPlayer()
        {
            var scoreboard = Scoreboard.Instance;
            var player = new Player();
            player.SetScore(5);
            player.SetName("Pesho");
            scoreboard.AddScore(player);
            Assert.AreEqual(1, scoreboard.playersWithScore.Count);

        }

        [TestMethod]
        public void IsScoreboardAddPlayerAfterThereIsAlreadyFivePlayers()
        {
            var scoreboard = Scoreboard.Instance;
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
            Assert.AreEqual(5, scoreboard.playersWithScore.Count);

        }

        [TestMethod]
        public void IsScoreboardAddPlayerAfterThereIsAlreadyFivePlayersAndNewPlayerHasWorstResult()
        {
            var scoreboard = Scoreboard.Instance;
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
            Assert.AreEqual(5, scoreboard.playersWithScore.Count);

        }

        [TestMethod]
        public void IsScoreboardReturnRightListOfPlayers()
        {
            var scoreboard = Scoreboard.Instance;
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
