using ColorsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsLibrary
{
    /// <summary>
    /// A film sheet.
    /// </summary>
    public abstract class FilmSheet : Sheet
    {
        /// <summary>
        /// Inits a new film sheet.
        /// </summary>
        public FilmSheet()
        {
            color = Color.Colorless;
        }

        public override void ChangeColor(Color color)
        {
            throw new Exception("Цвет листа пленки нельзя менять.");
        }
    }
}
