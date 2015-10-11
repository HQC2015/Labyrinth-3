using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Logic;
using Labyrinth.Console;

namespace LabirynthTests
{
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
    }
}
