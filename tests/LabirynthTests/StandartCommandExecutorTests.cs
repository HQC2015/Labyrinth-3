namespace LabirynthTests
{
    using Labyrinth.Logic.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class StandartCommandExecutorTests
    {
        [TestMethod]
        public void IsSCTMakerightInstance()
        {
            var mockWriter = new Mock<IVisitor>();
            var result = new StandartCommandExecutor(mockWriter.Object);
            Assert.IsInstanceOfType(result, typeof(StandartCommandExecutor));
        }

        [TestMethod]
        public void IsSCTRevertComandDown()
        {
            var mockWriter = new Mock<IVisitor>();
            var commandExecutor = new StandartCommandExecutor(mockWriter.Object);
            string result = commandExecutor.InvertCommand("d");
            Assert.AreEqual("u", result);
        }

        [TestMethod]
        public void IsSCTRevertComandUp()
        {
            var mockWriter = new Mock<IVisitor>();
            var commandExecutor = new StandartCommandExecutor(mockWriter.Object);
            string result = commandExecutor.InvertCommand("u");
            Assert.AreEqual("d", result);
        }

        [TestMethod]
        public void IsSCTRevertComandLeft()
        {
            var mockWriter = new Mock<IVisitor>();
            var commandExecutor = new StandartCommandExecutor(mockWriter.Object);
            string result = commandExecutor.InvertCommand("l");
            Assert.AreEqual("r", result);
        }

        [TestMethod]
        public void IsSCTRevertComandRight()
        {
            var mockWriter = new Mock<IVisitor>();
            var commandExecutor = new StandartCommandExecutor(mockWriter.Object);
            string result = commandExecutor.InvertCommand("r");
            Assert.AreEqual("l", result);
        }

        [TestMethod]
        public void IsSCTRevertInvalidCommand()
        {
            var mockWriter = new Mock<IVisitor>();
            var commandExecutor = new StandartCommandExecutor(mockWriter.Object);
            string result = commandExecutor.InvertCommand("m");
            Assert.AreEqual("m", result);
        }
    }
}
