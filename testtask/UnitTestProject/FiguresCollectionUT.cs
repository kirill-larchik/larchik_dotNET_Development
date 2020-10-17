using System;
using System.IO;
using FiguresLibrary;
using FiguresLibrary.Interfaces;
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

        [TestMethod]
        public void GetAveragePerimeter()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            FiguresCollection collection = new FiguresCollection();
            collection.ReadFromFile(filePath);

            double expected = 0;
            for (int i = 0; i < collection.Count; i++)
                expected += collection[i].GetP();
            expected /= collection.Count;

            double actual = collection.GetAveragePerimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalSquare()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            FiguresCollection collection = new FiguresCollection();
            collection.ReadFromFile(filePath);

            double expected = 0;
            for (int i = 0; i < collection.Count; i++)
                expected += collection[i].GetS();

            double actual = collection.GetTotalSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxSquareFigure()
        {
            IFigure expected = new Circle(5);

            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            FiguresCollection collection = new FiguresCollection();
            collection.ReadFromFile(filePath);

            IFigure actual = collection.GetMaxSquareFigure();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFigureTypeByMaxAveragePerimeter()
        {
            Type expected = typeof(Circle);

            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            FiguresCollection collection = new FiguresCollection();
            collection.ReadFromFile(filePath);

            Type actual = collection.GetFigureTypeByMaxAveragePerimeter();

            Assert.AreEqual(expected, actual);
        }
    }
}
