using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Console;
using Moq;
using System.Collections.Generic;
using System.IO;
using Labyrinth.Models;
using Labyrinth;
using Labyrinth.Models.Symbols;
using Labyrinth.Common.Enum;

namespace LabirynthTests
{
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

            //Console.SetOut(Console.Out);

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

            //Console.SetOut(Console.Out);
            
            Assert.AreEqual(0, outLines.Count);
        }

        //[TestMethod]
        //public void IsRendererPrinBoardCorrect()
        //{
        //    List<string> outLines = new List<string>();
        //    var mockWriter = new Mock<TextWriter>();
        //    mockWriter.Setup(writer => writer.WriteLine(It.IsAny<string>()))
        //            .Callback<string>(s => outLines.Add(s));
        //    Console.SetOut(mockWriter.Object);
        //
        //    var board = Board.Instance;
        //
        //    for (int i = 0; i < GlobalConstants.LabyrinthSizeRow; i++)
        //    {
        //        for (int j = 0; j < GlobalConstants.LabyrinthSizeCol; j++)
        //        {
        //            board.ReplaceSymbol(i, j, SymbolFactory.GetSymbol(SymbolsEnum.FilledSpace));
        //        }
        //    }
        //
        //    var render = new Renderer();
        //    render.RenderBoard(board);
        //
        //    var result = "x x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \nx x x x x x x \n";
        //    
        //    Assert.AreEqual(result, outLines[0]);
        //}
    }   
}
