using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing properties of a rectangle.
    /// </summary>
    public interface IRectangle : IFigure
    {
        /// <summary>
        /// The length of the rectangle.
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        int Width { get; set; }
    }
}
