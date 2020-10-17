using FiguresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary
{
    public enum Figures
    {
        Circle,
        Rectangle,
        Square
    }

    /// <summary>
    /// Class describing a collection of figures.
    /// </summary>
    public class FiguresCollection
    {
        private List<IFigure> figures;

        /// <summary>
        /// The count of figures.
        /// </summary>
        public int Count { get { return figures.Count; } }

        public IFigure this[int index]
        {
            get 
            {
                return figures[index];
            }
            set
            {
                figures[index] = value;
            }
        }

        /// <summary>
        /// Inits the new figures collection.
        /// </summary>
        public FiguresCollection()
        {
            figures = new List<IFigure>();
        }

        /// <summary>
        /// Adds a new figure.
        /// </summary>
        /// <param name="figure"></param>
        public void Add(IFigure figure)
        {
            figures.Add(figure);
        }

        /// <summary>
        /// Removes a figure from the collection by index.
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            figures.RemoveAt(index);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            figures.Clear();
        }

        /// <summary>
        /// Reads txt file and returns the figures collection.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void ReadFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] vs = line.Split(' ');

                    switch (Enum.Parse(typeof(Figures), vs[0]))
                    {
                        case Figures.Circle:
                            int radius;
                            if (!int.TryParse(vs[1], out radius))
                                throw new Exception("Incorrect format of data.");
                            
                            Add(new Circle(radius));
                            break;
                        case Figures.Rectangle:
                            int length;
                            if (!int.TryParse(vs[1], out length))
                                throw new Exception("Incorrect format of data.");
                            
                            int width;
                            if(!int.TryParse(vs[2], out width))
                                throw new Exception("Incorrect format of data.");
                            
                            Add(new Rectangle(length, width));
                            break;
                        case Figures.Square:
                            int side;
                            if (!int.TryParse(vs[1], out side))
                                throw new Exception("Incorrect format of data.");

                            Add(new Square(side));
                            break;
                        default:
                            throw new Exception("Incorrect format of data.");
                    }
                }
            }
        }
    }
}
