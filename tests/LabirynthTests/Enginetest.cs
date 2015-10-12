namespace LabirynthTests
{
    using Labyrinth.Console;
    using Labyrinth.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void IsEngineConstructorMakeInstanceOfEngine()
        {
            var renderer = new Renderer();
            var input = new InputHandler();
            var engine = new Engine(renderer, input);

            Assert.IsInstanceOfType(engine, typeof(Engine));
        }

        [TestMethod]
        public void IsEngineRunRight()
        {
            var renderer = new Renderer();
            Assert.IsInstanceOfType(renderer, typeof(Renderer));
        }

        [TestMethod]
        public void IsInputHandlerReturnsRightInstance()
        {
            var input = new InputHandler();
            Assert.IsInstanceOfType(input, typeof(InputHandler));
        }

        [TestMethod]
        public void IsEngineMakeStandartGameRules()
        {
            var renderer = new Renderer();
            var input = new InputHandler();
            var engine = new Engine(renderer, input);
        }
    }
}
