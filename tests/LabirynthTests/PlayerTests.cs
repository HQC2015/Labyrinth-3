using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Models.Players;
using Moq;
using Labyrinth.Logic.Commands;

namespace LabirynthTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void IsPlayerSetNamePassToContext()
        {
            var playerContext = new PlayerContext();
            var player = new Player(playerContext);
            player.SetName("pesho");
            Assert.AreEqual("pesho", playerContext.Name);
        }

        [TestMethod]
        public void IsPlayerSetXPassToContext()
        {
            var playerContext = new PlayerContext();
            var player = new Player(playerContext);
            player.SetX(1);
            Assert.AreEqual(1, playerContext.X);
        }

        [TestMethod]
        public void IsPlayerSetYPassToContext()
        {
            var playerContext = new PlayerContext();
            var player = new Player(playerContext);
            player.SetY(1);
            Assert.AreEqual(1, playerContext.Y);
        }

        [TestMethod]
        public void IsPlayerGetXGetFromContext()
        {
            var player = new Player();
            Assert.AreEqual(0, player.GetX());
        }

        [TestMethod]
        public void IsPlayerGetYGetFromContext()
        {
            var player = new Player();
            Assert.AreEqual(0, player.GetY());
        }

        [TestMethod]
        public void IsPlayerGetNameGetFromContext()
        {
            var player = new Player();
            player.SetName("pesho");
            Assert.AreEqual("pesho", player.GetName());
        }
        
        [TestMethod]
        public void IsPlayerPrintReturnWriteString()
        {
            var player = new Player();
            player.SetName("pesho");
            player.SetScore(5);
            Assert.AreEqual(". pesho ---> 5 Score", player.Print());
        }

        [TestMethod]
        public void IsPlayerAcceptSetVisitorToPlayer()
        {
            var mockVisitor = new Mock<IVisitor>();
            var player = new Player();
            mockVisitor.Setup(x => x.Visit(player)).Verifiable();
            player.Accept(mockVisitor.Object);
            mockVisitor.Verify();
        }
    }
}
