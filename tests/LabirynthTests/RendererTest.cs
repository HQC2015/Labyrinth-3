namespace LabirynthTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Labyrinth.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RendererTest
    {
        [TestMethod]
        public void IsRendererPrintRightMessageWhenWePassMessage()
        {
            List<string> outLines = new List<string>();
            var mockWriter = new Mock<TextWriter>();
            mockWriter.Setup(writer => writer.WriteLine(It.IsAny<string>()))
                    .Callback<string>(s => outLines.Add(s));
            Console.SetOut(mockWriter.Object);

            var render = new Renderer();
            render.RenderMessage("foo");

            Assert.AreEqual(1, outLines.Count);
            Assert.AreEqual("foo", outLines[0]);
        }

        [TestMethod]
        public void IsRendererPrintRightMessageWithNoMessage()
        {
            List<string> outLines = new List<string>();
            var mockWriter = new Mock<TextWriter>();
            mockWriter.Setup(writer => writer.WriteLine(It.IsAny<string>()))
                    .Callback<string>(s => outLines.Add(s));
            Console.SetOut(mockWriter.Object);

            var render = new Renderer();
            render.RenderMessage();
            
            Assert.AreEqual(0, outLines.Count);
        }
    }   
}
