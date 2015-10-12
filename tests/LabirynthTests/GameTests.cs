using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Logic;
using Labyrinth.Console;
using Labyrinth.Logic.BoardSetupRules;
using Moq;
using Labyrinth.Logic.Contracts;
using Labyrinth.Models.Players;
using Labyrinth.Logic.Commands;
using Labyrinth.Models;

namespace LabirynthTests
{
    [TestClass]
    public class GameTests
    {
        [TestInitialize]
        public void Init()
        {
            var mockRender = new Mock<IRenderer>();
            var input = new Mock<IInputHandler>();
            var gamerules = new Mock<StandartBoardSetup>();
        }

        [TestMethod]
        public void IsGame()
        {
            var mockRender = new Mock<Renderer>();
            var input = new Mock<InputHandler>();
            var gamerules = new Mock<StandartBoardSetup>();
            var game = new Game(mockRender.Object, input.Object, gamerules.Object);
            Assert.IsInstanceOfType(game, typeof(Game));
        }

        //[TestMethod]
        //public void IsGameStart()
        //{
        //    //var mockRender = new Renderer();
        //    //var input = new InputHandler();
        //    //var gamerules = new StandartBoardSetup();
        //    //var player = new Player();
        //    //var commandController = new CommandController(player);
        //    //var board = Board.Instance;
        //    //var game = new Game(mockRender, input, gamerules);
        //    //game.Start();
        //    //Assert.AreEqual(0, player.GetScore());
        //    
        //}
    }
}
