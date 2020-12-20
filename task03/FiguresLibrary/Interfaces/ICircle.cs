using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing methods and properties for all circles.
    /// </summary>
    public interface ICircle : IFigure
    {
        /// <summary>
        /// Returns diameter of circle.
        /// </summary>
        int Diameter { get; set; }

        /// <summary>
        /// Returns radius of circle.
        /// </summary>
        int Radius { get; set; }
    }
}
