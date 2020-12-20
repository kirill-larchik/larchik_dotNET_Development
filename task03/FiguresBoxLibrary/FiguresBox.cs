using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLibrary.Interfaces;
using FiguresBoxLibrary.Xml;
using System.IO;
using System.Xml;
using System.Net.Http.Headers;
using SheetsLibrary;

namespace FiguresBoxLibrary
{
    /// <summary>
    /// A figure box (20 elements).
    /// </summary>
    public class FiguresBox
    {
        IFigure[] figuresBox;

        private XmlReadOperation xmlRead;
        private XmlWriteOperation xmlWrite;

        /// <summary>
        /// The box size.
        /// </summary>
        public int Length { get { return figuresBox.Length; } }

        /// <summary>
        /// Inits a new figure box.
        /// </summary>
        public FiguresBox()
        {
            figuresBox = new IFigure[20];

            for (int i = 0; i < Length; i++)
                figuresBox[i] = null;

            xmlRead = new XmlReadOperation();
            xmlWrite = new XmlWriteOperation();
        }

        /// <summary>
        /// Reads all figures from xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="type"></param>
        public void ReadXmlFile(string filePath, XmlReadType type)
        {
            switch (type)
            {
                case XmlReadType.StreamReader:
                    figuresBox = xmlRead.ReadXmlWithStreamReader(filePath);
                    break;
                case XmlReadType.XmlReader:
                    figuresBox = xmlRead.ReadXmlWithXmlReader(filePath);
                    break;
            }
        }

        /// <summary>
        /// Write the figure box to xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="figureWriteType"></param>
        /// <param name="xmlWriteType"></param>
        public void WriteXmlFile(string filePath, XmlWriteType xmlWriteType, FigureWriteType figureWriteType)
        {
            switch (xmlWriteType)
            {
                case XmlWriteType.StreamWriter:
                    xmlWrite.WriteXmlFileWithStreamWriter(filePath, figuresBox, figureWriteType);
                    break;
                case XmlWriteType.XmlWriter:
                    xmlWrite.WriteXmlFileWithXmlReader(filePath, figuresBox, figureWriteType);
                    break;
            }
        } 
        
        /// <summary>
        /// Add a new figure to the box.
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(IFigure figure)
        {
            bool flag = true;
            int position = -1;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].Equals(figure))
                    throw new Exception("Нельзя добавлять одинаковые фигуры.");

                if (figuresBox[i] == null && flag == true)
                {
                    position = i;
                    flag = false;
                }
            }

            figuresBox[position] = figure;
        }

        /// <summary>
        /// Returns a figure by number.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string ShowFigure(int index)
        {
            return figuresBox[index].ToString();
        }

        /// <summary>
        /// Extract or replace a figure by number.    
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IFigure this[int index]
        {
            get
            {
                IFigure figure = figuresBox[index];
                figuresBox[index] = null;
                return figure;
            }
            set
            {
                figuresBox[index] = value;
            }
        }

        /// <summary>
        /// Returns a equal figure.
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public IFigure GetEqualFigure(IFigure figure)
        {
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i].Equals(figure))
                    return figuresBox[i];
            }

            return null;
        }

        /// <summary>
        /// Returns count of figures ib the box.
        /// </summary>
        /// <returns></returns>
        public int GetAvailableFiguresCount()
        {
            int count = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Returns total square.
        /// </summary>
        /// <returns></returns>
        public double GetTotalS()
        {
            double s = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    s += figuresBox[i].GetS();
            }

            return s;
        }

        /// <summary>
        /// Returns total perimeter.
        /// </summary>
        /// <returns></returns>
        public double GetTotalP()
        {
            double p = 0;

            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    p += figuresBox[i].GetP();
            }

            return p;
        }

        /// <summary>
        /// Extract all circles.
        /// </summary>
        /// <returns></returns>
        public ICircle[] GetAllCircles()
        {
            int length = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().GetInterfaces()[0] == typeof(ICircle))
                    length++;
            }

            ICircle[] circles = new ICircle[length];
            
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().GetInterfaces()[0] == typeof(ICircle))
                {
                    circles[index] = (ICircle)this[i];
                    index++;
                }
            }

            return circles;
        }

        /// <summary>
        /// Extract all film figures.
        /// </summary>
        /// <returns></returns>
        public IFigure[] GetAllFilmFigures()
        {
            int length = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(FilmSheet))
                    length++;
            }

            IFigure[] filmFigures = new IFigure[length];

            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(FilmSheet))
                {
                    filmFigures[index] = this[i];
                    index++;
                }
            }

            return filmFigures;
        }

        /// <summary>
        /// Extract all plastic figures without drawn.
        /// </summary>
        /// <returns></returns>
        public IFigure[] GetAllPlasticFiguresWithoutDrawn()
        {
            int length = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(PlasticSheet) && ((Sheet)figuresBox[i]).IsDrawn == false)
                    length++;
            }

            IFigure[] filmFigures = new IFigure[length];

            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null && figuresBox[i].GetType().BaseType == typeof(PlasticSheet) && ((Sheet)figuresBox[i]).IsDrawn == false)
                {
                    filmFigures[index] = this[i];
                    index++;
                }
            }

            return filmFigures;
        }

        public override bool Equals(object obj)
        {

            return obj is FiguresBox box &&
                   GetHashCode() == box.GetHashCode();
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                    hashCode += figuresBox[i].GetHashCode();
            }
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Фигуры, содержащиеся в коробке:\n");
            for (int i = 0; i < Length; i++)
            {
                if (figuresBox[i] != null)
                {
                    stringBuilder.Append(figuresBox[i].ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}
