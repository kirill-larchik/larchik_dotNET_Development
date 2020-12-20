using FiguresLibrary.Interfaces;
using SheetsLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FiguresBoxLibrary.Xml
{
    public enum XmlWriteType
    {
        StreamWriter,
        XmlWriter
    }

    public enum FigureWriteType
    {
        All,
        Paper,
        Film,
        Plastic
    }

    /// <summary>
    ///  A xml write operations
    /// </summary>
    internal class XmlWriteOperation
    {

        /// <summary>
        /// Write a figure collection to xml fiie with StreamWriter
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="figures"></param>
        /// <param name="figureWriteType"></param>
        /// <returns></returns>
        public void WriteXmlFileWithStreamWriter(string filePath, IFigure[] figures, FigureWriteType figureWriteType)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement root = document.CreateElement("figures");
            
            for (int i = 0; i < figures.Length; i++)
            {
                if (CheckFigure(figures[i], figureWriteType))
                {
                    DetermineFigureType(document, root, figures[i]);
                }
            }

            document.AppendChild(root);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                document.Save(writer);
            }
        }

        /// <summary>
        /// Write a figure collection to xml fiie with XmlWritter.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="figures"></param>
        /// <param name="figureWriteType"></param>
        /// <returns></returns>
        public void WriteXmlFileWithXmlReader(string filePath, IFigure[] figures, FigureWriteType figureWriteType)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                string material = "";

                writer.WriteStartDocument();
                writer.WriteStartElement("figures");

                foreach (IFigure figure in figures)
                {
                    if (CheckFigure(figure, figureWriteType))
                    {
                        writer.WriteStartElement("figure");

                        switch (figure.GetType().GetInterfaces()[0].Name)
                        {
                            case "IRectangle":
                                IRectangle rectangle = (IRectangle)figure;

                                material = rectangle.GetType().BaseType.Name.Replace("Sheet", "");
                                writer.WriteAttributeString("material", material);
                                writer.WriteAttributeString("form", "Rectangle");

                                writer.WriteStartElement("length");
                                writer.WriteString(rectangle.Length.ToString());
                                writer.WriteEndElement();

                                writer.WriteStartElement("width");
                                writer.WriteString(rectangle.Width.ToString());
                                writer.WriteEndElement();

                                break;

                            case "ICircle":
                                ICircle circle = (ICircle)figure;

                                material = circle.GetType().BaseType.Name.Replace("Sheet", "");
                                writer.WriteAttributeString("material", material);
                                writer.WriteAttributeString("form", "Circle");

                                writer.WriteStartElement("radius");
                                writer.WriteString(circle.Radius.ToString());
                                writer.WriteEndElement();

                                break;
                        }

                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private bool CheckFigure(IFigure figure, FigureWriteType figureWriteType)
        {
            switch (figureWriteType)
            {
                case FigureWriteType.All:
                    if (figure != null)
                        return true;
                    else
                        return false;
                case FigureWriteType.Film:
                    if (figure != null && figure.GetType().BaseType.Name == "FilmSheet")
                        return true;
                    else
                        return false;
                case FigureWriteType.Paper:
                    if (figure != null && figure.GetType().BaseType.Name == "PaperSheet")
                        return true;
                    else
                        return false;
                case FigureWriteType.Plastic:
                    if (figure != null && figure.GetType().BaseType.Name == "PlasticSheet")
                        return true;
                    else
                        return false;
            }

            return false;
        }

        private void DetermineFigureType(XmlDocument document, XmlElement root, IFigure figure)
        {
            string figureType = figure.GetType().GetInterfaces()[0].Name;
            
            switch (figureType)
            {
                case "IRectangle":
                    GetRectangleNode(document, root, (IRectangle)figure);
                    break;
                case "ICircle":
                    GetCircleNode(document, root, (ICircle)figure);
                    break;
            }
        }

        private void GetRectangleNode(XmlDocument document, XmlElement root, IRectangle rectangle)
        {
            XmlElement rectangleElement = document.CreateElement("figure");

            string material = rectangle.GetType().BaseType.Name.Replace("Sheet", "");
            rectangleElement.SetAttribute("material", material);
            rectangleElement.SetAttribute("form", "Rectangle");

            XmlElement lengthElement = document.CreateElement("length");
            lengthElement.InnerText = rectangle.Length.ToString();
            rectangleElement.AppendChild(lengthElement);

            XmlElement widthElement = document.CreateElement("width");
            widthElement.InnerText = rectangle.Width.ToString();
            rectangleElement.AppendChild(widthElement);

            root.AppendChild(rectangleElement);
        }

        private void GetCircleNode(XmlDocument document, XmlElement root, ICircle circle)
        {
            XmlElement circleElement = document.CreateElement("figure");

            string material = circle.GetType().BaseType.Name.Replace("Sheet", "");
            circleElement.SetAttribute("material", material);
            circleElement.SetAttribute("form", "Circle");

            XmlElement lengthElement = document.CreateElement("radius");
            lengthElement.InnerText = circle.Radius.ToString();
            circleElement.AppendChild(lengthElement);

            root.AppendChild(circleElement);
        }
    }
}
