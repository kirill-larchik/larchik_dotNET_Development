using System;
using System.IO;
using FiguresLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class FiguresCollectionUT
    {
        [TestMethod]
        public void ReadFromFile()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            int exptected = File.ReadAllLines(filePath).Length;
            
            FiguresCollection collection = new FiguresCollection();
            collection.ReadFromFile(filePath);
            int actual = collection.Count;

            Assert.AreEqual(exptected, actual);
        }
    }
}
