using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing methods for each figures.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Returns perimeter of the figure.
        /// </summary>
        /// <returns></returns>
        double GetP();

        /// <summary>
        /// Returns square of the figure.
        /// </summary>
        /// <returns></returns>
        double GetS();
    }
}
