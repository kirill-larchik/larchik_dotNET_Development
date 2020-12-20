using ColorsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsLibrary
{
    /// <summary>
    /// A paper sheet.
    /// </summary>
    public abstract class PaperSheet : Sheet
    {
        /// <summary>
        /// Inits a new paper sheet.
        /// </summary>
        public PaperSheet()
        {
            color = Color.White;
        }

        public override void ChangeColor(Color color)
        {
            if (IsDrawn == false)
            {
                this.color = color;
                IsDrawn = true;
            }
            else
                throw new Exception("Лист бумаги можно красить только один раз.");
        }
    }
}
