using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Console;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace LabirynthTests
{
    [TestClass]
    public class Enginetest
    {
        [TestInitialize]


        [TestMethod]
        public void TestMethod()
        {
            var outLines = new List<string>();
            var mockWriter = new Mock<TextWriter>();
            mockWriter.Setup(writer => writer.WriteLine(It.IsAny<string>()))
                .Callback<string>(s => outLines.Add(s));
            Console.SetOut(mockWriter.Object);

            var logger = new Renderer();
            logger.RenderMessage("foo");

            Assert.AreEqual(1, outLines.Count);
            Assert.AreEqual("foo", outLines[0]);
            
        }
    }
}
