using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing methods for all figures.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Returns perimeter of figure.
        /// </summary>
        /// <returns></returns>
        double GetP();

        /// <summary>
        /// Returns square of figure.
        /// </summary>
        /// <returns></returns>
        double GetS();
    }
}
