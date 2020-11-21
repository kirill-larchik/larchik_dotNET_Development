using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientsLibrary;

namespace BakeryProductsLibrary
{
    /// <summary>
    /// Describing properties of a bakery product.
    /// </summary>
    public interface IBakeryProduct
    {
        /// <summary>
        /// Returns calorie of a bakery product.
        /// </summary>
        /// <returns></returns>
        double GetCalorie();

        /// <summary>
        /// Returns cost of a bakery product.
        /// </summary>
        /// <returns></returns>
        double GetCost();

        /// <summary>
        /// Returns ingredients of a bakery product.
        /// </summary>
        /// <returns></returns>
        Ingredient[] GetIngredients();
    }
}
