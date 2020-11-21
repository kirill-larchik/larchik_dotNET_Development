using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLibrary
{
    /// <summary>
    /// Class descrabing properties of a ingredient.
    /// </summary>
    public abstract class Ingredient
    {
        /// <summary>
        /// Returns the calorie of a ingredient.
        /// </summary>
        public double Calorie { get; protected set; }

        /// <summary>
        /// Returns the cost of a ingredient.
        /// </summary>
        public double Cost { get; protected set; }

        /// <summary>
        /// Returns the value of a ingredient.
        /// </summary>
        public double Value { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is Ingredient ingredient &&
                   Calorie == ingredient.Calorie &&
                   Cost == ingredient.Cost &&
                   Value == ingredient.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = -1403189430;
            hashCode = hashCode * -1521134295 + Calorie.GetHashCode();
            hashCode = hashCode * -1521134295 + Cost.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Calorie: {Calorie}, Cost: {Cost}, Value: {Value};";
        }
    }
}
