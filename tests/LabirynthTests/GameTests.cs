namespace LabirynthTests
{
    using Labyrinth.Console;
    using Labyrinth.Logic;
    using Labyrinth.Logic.BoardSetupRules;
    using Labyrinth.Logic.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

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

        ////[TestMethod]
        ////public void IsGameStart()
        ////{
        ////    var mockRender = new Mock<IRenderer>();
        ////    var input = new Mock<InputHandler>();
        ////    var gamerules = new StandartBoardSetup();
        ////    var board = Board.Instance;
        ////    var game = new Game(mockRender.Object, input.Object, gamerules);
        ////    var queueStuff = new Queue<string>();
        ////    queueStuff.Enqueue("top");
        ////    queueStuff.Enqueue("exit");
        ////    //var action = "top";
        ////    input.Setup(x => x.GetInput()).Returns(queueStuff.Dequeue);
        ////    game.Start();
        ////    mockRender.Verify(x => x.RenderMessage(It.IsAny<string>()), Times.Exactly(4));
        ////    //PrivateObject po = new PrivateObject("player");
        ////    //var result = po.Invoke("GetScore");
        ////    //Assert.AreEqual(0, result);
        ////}
    }
}
