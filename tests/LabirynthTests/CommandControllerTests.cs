using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Labyrinth.Logic.Commands;
using Labyrinth.Models.Players;

namespace LabirynthTests
{
    [TestClass]
    public class CommandControllerTests
    {
        //[TestMethod]
        //public void IsCommandRecieverInvokeRightPrivateMethods()
        //{
        //    var mockReciever = new Mock<CommandReceiver>();
        //    mockReciever.Setup(x => x.SetSuccessor(It.IsAny<CommandExecutor>())).Verifiable();
        //    mockReciever.Verify(x => x.SetSuccessor(It.IsAny<CommandExecutor>()), Times.Once);
        //
        //}

        //[TestMethod]
        //public void IsProcessCommandInvokeRightMethod()
        //{
        //    var player = new Player();
        //    var cc = new Mock<CommandController>(player);
        //    cc.Object.ProcessCommand("d");
        //    
        //
        //}
    }
}
