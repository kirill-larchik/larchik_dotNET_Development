using ColorsLibrary;

namespace SheetsLibrary
{
    /// <summary>
    /// A Sheet.
    /// </summary>
    public abstract class Sheet
    {
        protected Color color;

        /// <summary>
        /// Returns the sheet color.
        /// </summary>
        public Color GetColor { get { return color; } }

        /// <summary>
        /// Is the sheet drawn?
        /// </summary>
        public bool IsDrawn { get; protected set; }

        /// <summary>
        /// Inits a new sheet.
        /// </summary>
        public Sheet()
        {
            IsDrawn = false;
        }

        /// <summary>
        /// Changes the current color to another.
        /// </summary>
        /// <param name="color"></param>
        public abstract void ChangeColor(Color color);

        public override bool Equals(object obj)
        {
            return obj is Sheet sheet &&
                   color == sheet.color &&
                   GetColor == sheet.GetColor &&
                   IsDrawn == sheet.IsDrawn;
        }

        public override int GetHashCode()
        {
            int hashCode = 1650713829;
            hashCode = hashCode * -1521134295 + color.GetHashCode();
            hashCode = hashCode * -1521134295 + GetColor.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDrawn.GetHashCode();
            return hashCode;
        }
    }
}
