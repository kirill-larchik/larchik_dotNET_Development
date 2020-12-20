using FiguresLibrary.Interfaces;
using FiguresBoxLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.FilmFigures;
using FiguresLibrary.PlasticFigures;

namespace FiguresBoxLibrary.Xml
{
    public enum XmlReadType
    {
        StreamReader,
        XmlReader
    }

    /// <summary>
    /// A xml read operations.
    /// </summary>
    internal class XmlReadOperation
    {
        /// <summary>
        /// Reads all figures with StreamReader.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithStreamReader(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string xmlString = reader.ReadToEnd();

                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlString);

                XmlNodeList list = document.GetElementsByTagName("figure");

                IFigure[] figures = InitFiguresArray();

                // Заполняю массив фигурами.
                int index = 0;
                foreach (XmlNode node in list)
                {
                    if (index != figures.Length)
                    {
                        figures[index] = GetFigure(node);
                        index++;
                    }
                    else
                    {
                        return figures;
                    }
                }

                return figures;
            }
        }

        /// <summary>
        /// Reads all figures XmlReader.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithXmlReader(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                IFigure[] figures = InitFiguresArray();
                int index = 0;

                string element = "";

                string material = "";
                string form = "";

                int length = 0;
                int width = 0;
                int radius = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        element = reader.Name;
                        if (element == "figure")
                        {
                            material = reader.GetAttribute("material");
                            form = reader.GetAttribute("form");
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "length":
                                length = int.Parse(reader.Value);
                                break;
                            case "width":
                                width = int.Parse(reader.Value);
                                break;
                            case "radius":
                                radius = int.Parse(reader.Value);
                                break;
                        }
                    }
                    else if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "figure"))
                    {
                        if (index != figures.Length)
                        {
                            figures[index] = GetConcreteSheetFigure(material, form, length, width, radius);
                            index++;
                        }
                        else
                        {
                            return figures;
                        }
                    }
                }

                return figures;
            }
        }
        
        private IFigure[] InitFiguresArray()
        {
            
            IFigure[] figures = new IFigure[20];
           
            for (int i = 0; i < figures.Length; i++)
                figures[i] = null;
            
            return figures;
        }

        private IFigure GetFigure(XmlNode figure)
        {
            GetFigureSideValues(figure, out int length, out int width, out int radius);
            GetFigureMaterialAndForm(figure, out string material, out string form);
            return GetConcreteSheetFigure(material, form, length, width, radius);
        }

        private void GetFigureSideValues(XmlNode figure, out int length, out int width, out int radius)
        {
            length = 0;
            width = 0;
            radius = 0;

            XmlNodeList sides = figure.ChildNodes;
            foreach (XmlNode side in sides)
            {
                switch (side.Name)
                {
                    case "length":
                        length = int.Parse(side.InnerText);
                        break;
                    case "width":
                        width = int.Parse(side.InnerText);
                        break;
                    case "radius":
                        radius = int.Parse(side.InnerText);
                        break;
                }
            }

            if (length == 0 && width == 0 && radius == 0)
                throw new Exception("Неккоретно заданы длины сторон.");
        }

        private void GetFigureMaterialAndForm(XmlNode figure, out string material, out string form)
        {
            material = "";
            form = "";

            foreach(XmlAttribute attribute in figure.Attributes)
            {
                switch (attribute.Name)
                {
                    case "material":
                        material = attribute.InnerText;
                        break;
                    case "form":
                        form = attribute.InnerText;
                        break;
                }
            }
            
            if(material == "" || form == "")
                throw new Exception("Неккоретно заданы материал и форма сторон.");
        }

        private IFigure GetConcreteSheetFigure(string material, string form, int length, int width, int radius)
        {
            IFigure figure = null;

            if (material == "Paper")
            {
                if (form == "Rectangle")
                    figure = new PaperRectangle(length, width);
                if (form == "Circle")
                    figure = new PaperCircle(radius);
            }
            
            if (material == "Film")
            {
                if (form == "Rectangle")
                    figure = new FilmRectangle(length, width);
                if (form == "Circle")
                    figure = new FilmCircle(radius);
            }

            if (material == "Plastic")
            {
                if (form == "Rectangle")
                    figure = new PlasticRectangle(length, width);
                if (form == "Circle")
                    figure = new PlasticCircle(radius);
            }

            if (figure == null)
                throw new Exception("Вы ввели неккоректные данные фигур(ы).");
            else
                return figure;
        }
    }
}
