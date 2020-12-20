using ColorsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsLibrary
{
    /// <summary>
    /// A plastic sheet.
    /// </summary>
    public abstract class PlasticSheet : Sheet
    {
        /// <summary>
        /// Inits a new plastic sheet.
        /// </summary>
        public PlasticSheet()
        {
            color = Color.White;
        }

        public override void ChangeColor(Color color)
        {
            if (IsDrawn == false)
                IsDrawn = true;

            this.color = color;
        }
    }
}
