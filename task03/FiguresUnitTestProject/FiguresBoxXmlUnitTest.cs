using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresBoxLibrary;
using FiguresLibrary;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.FilmFigures;
using FiguresLibrary.PlasticFigures;
using FiguresBoxLibrary.Xml;
using System.IO;

namespace FiguresUnitTestProject
{
    [TestClass]
    public class FiguresBoxXmlUnitTest
    {
        [TestMethod]
        public void Read_StreamReader()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[1] = new FilmRectangle(6, 2);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.StreamReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_StreamWriter()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWrite.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            expected.WriteXmlFile(filePath, XmlWriteType.StreamWriter, FigureWriteType.All);
            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.StreamReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Read_XmlReader()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[1] = new FilmRectangle(6, 2);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.XmlReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_XmlWriter()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWrite.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            expected.WriteXmlFile(filePath, XmlWriteType.XmlWriter, FigureWriteType.All);
            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.XmlReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_XmlWriter_StreamReader()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWrite.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            expected.WriteXmlFile(filePath, XmlWriteType.XmlWriter, FigureWriteType.All);
            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.StreamReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_StreamWriter_XmlReader()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWrite.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[2] = new PaperCircle(6);
            expected[3] = new FilmCircle(3);
            expected[4] = new PlasticCircle(3);
            expected[5] = new PlasticRectangle(10, 5);

            expected.WriteXmlFile(filePath, XmlWriteType.StreamWriter, FigureWriteType.All);
            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(filePath, XmlReadType.XmlReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_StreamWriter_FilmOnly()
        {
            string fileReadPath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            string fileWritePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWriteFilmOnly.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new FilmRectangle(6, 2);
            expected[3] = new FilmCircle(3);

            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(fileReadPath, XmlReadType.XmlReader);
            actual.WriteXmlFile(fileWritePath, XmlWriteType.StreamWriter, FigureWriteType.Film);
            actual.ReadXmlFile(fileWritePath, XmlReadType.XmlReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_XmlWriter_PaperOnly()
        {
            string fileReadPath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            string fileWritePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWritePaperOnly.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PaperRectangle(10, 5);
            expected[3] = new PaperCircle(6);

            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(fileReadPath, XmlReadType.StreamReader);
            actual.WriteXmlFile(fileWritePath, XmlWriteType.XmlWriter, FigureWriteType.Paper);
            actual.ReadXmlFile(fileWritePath, XmlReadType.StreamReader);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Write_XmlWriter_PlasticOnly()
        {
            string fileReadPath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlRead.xml";
            string fileWritePath = Directory.GetCurrentDirectory() + @"\XmlFiles\testXmlWritePlasticOnly.xml";
            FiguresBox expected = new FiguresBox();
            expected[0] = new PlasticCircle(3);
            expected[3] = new PlasticRectangle(10, 5);
            

            FiguresBox actual = new FiguresBox();
            actual.ReadXmlFile(fileReadPath, XmlReadType.XmlReader);
            actual.WriteXmlFile(fileWritePath, XmlWriteType.XmlWriter, FigureWriteType.Plastic);
            actual.ReadXmlFile(fileWritePath, XmlReadType.XmlReader);

            Assert.AreEqual(expected, actual);
        }
    }
}
