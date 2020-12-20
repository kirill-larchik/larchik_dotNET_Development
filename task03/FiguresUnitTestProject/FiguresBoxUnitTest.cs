using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBoxLibrary;
using FiguresLibrary.FilmFigures;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.PlasticFigures;
using FiguresBoxLibrary.Xml;
using System.IO;
using FiguresLibrary.Interfaces;

namespace FiguresUnitTestProject
{
    [TestClass]
    public class FiguresBoxUnitTest
    {
        [TestMethod]
        public void AddFigure_PaperRectangleAndFilmCircle()
        {
            PaperRectangle rectangle = new PaperRectangle(1, 1);
            FilmCircle cicle = new FilmCircle(3);
            FiguresBox expected = new FiguresBox();
            expected[0] = rectangle;
            expected[1] = cicle;

            FiguresBox actual = new FiguresBox();
            actual.AddFigure(rectangle);
            actual.AddFigure(cicle);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Нельзя добавлять одинаковые фигуры.")]
        public void AddFigure_GetExecption()
        {
            PaperRectangle rectangle = new PaperRectangle(1, 1);
            FilmCircle cicle = new FilmCircle(3);
            PaperRectangle newRectangle = new PaperRectangle(1, 1);

            FiguresBox actual = new FiguresBox();
            actual.AddFigure(rectangle);
            actual.AddFigure(cicle);
            actual.AddFigure(newRectangle);
        }

        [TestMethod]
        public void ShowFigure_FilmRectangleInfo()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            string expected = new FilmRectangle(6, 2).ToString();
            
            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            string actual = box.ShowFigure(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_Get()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            IFigure expected = null;

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            IFigure figure = box[2];
            IFigure actual = box[2];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Indexer_Set()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            FilmCircle expected = new FilmCircle(2);

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            box[0] = expected;
            IFigure actual = box[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEqualFigure_PaperCircle()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            PaperCircle expected = new PaperCircle(6);

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            IFigure actual = box.GetEqualFigure(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAvailableFiguresCount()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            int expected = 5;

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            IFigure figure = box[1];
            int actual = box.GetAvailableFiguresCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalS()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 10);
            PaperCircle circle = new PaperCircle(2);
            double expected = rectangle.GetS() + circle.GetS();

            FiguresBox box = new FiguresBox();
            box.AddFigure(rectangle);
            box.AddFigure(circle);
            double actual = box.GetTotalS();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalP()
        {
            FilmRectangle rectangle = new FilmRectangle(10, 10);
            PaperCircle circle = new PaperCircle(2);
            double expected = rectangle.GetP() + circle.GetP();

            FiguresBox box = new FiguresBox();
            box.AddFigure(rectangle);
            box.AddFigure(circle);
            double actual = box.GetTotalP();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllCircles()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            ICircle[] expected = new ICircle[]
            {
                new PaperCircle(6),
                new FilmCircle(3),
                new PlasticCircle(3)
            };

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            ICircle[] actual = box.GetAllCircles();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllFilmFigures()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            IFigure[] expected = new IFigure[]
            {
                new FilmRectangle(6, 2),
                new FilmCircle(3)
            };

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            IFigure[] actual = box.GetAllFilmFigures();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllPlasticFiguresWithoutDrawn()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";

            IFigure[] expected = new IFigure[]
            {
                new PlasticCircle(3),
                new PlasticRectangle(10, 5)
            };

            FiguresBox box = new FiguresBox();
            box.ReadXmlFile(filePath, XmlReadType.StreamReader);
            IFigure[] actual = box.GetAllPlasticFiguresWithoutDrawn();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
