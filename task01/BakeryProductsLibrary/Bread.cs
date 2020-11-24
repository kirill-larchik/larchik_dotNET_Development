using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientsLibrary;

namespace BakeryProductsLibrary
{
    /// <summary>
    /// Class describing properties of a bread.
    /// </summary>
    public class Bread : IBakeryProduct
    {
        private Ingredient[] _ingredients;

        /// <summary>
        /// Returns the bread name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Returns the markup of the bread category.
        /// </summary>
        public double Markup { get; private set; }

        /// <summary>
        /// Inits a bread with markup and given inredients.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ingredients"></param>
        public Bread(string name, params Ingredient[] ingredients)
        {
            Name = name;
            _ingredients = ingredients;

            Markup = 100;
        }

        /// <summary>
        /// Returns the bread calorie.
        /// </summary>
        /// <returns></returns>
        public double GetCalorie()
        {
            double calorie = 0;
            for (int i = 0; i < _ingredients.Length; i++)
                calorie += _ingredients[i].Calorie;
            return calorie;
        }

        /// <summary>
        /// Returns the bread cost.
        /// </summary>
        /// <returns></returns>
        public double GetCost()
        {
            double cost = 0;
            for (int i = 0; i < _ingredients.Length; i++)
                cost += _ingredients[i].Cost;
            return cost + Markup;
        }

        public Ingredient[] GetIngredients()
        {
            return _ingredients;
        }

        public override bool Equals(object obj)
        {
            return obj is Bread bread &&
                   EqualityComparer<Ingredient[]>.Default.Equals(_ingredients, bread._ingredients) &&
                   Name == bread.Name &&
                   Markup == bread.Markup;
        }

        public override int GetHashCode()
        {
            int hashCode = -1335647283;
            hashCode = hashCode * -1521134295 + EqualityComparer<Ingredient[]>.Default.GetHashCode(_ingredients);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Markup.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string str = $"{this.GetType().Name} '{Name}:'\n";
            for (int i = 0; i < _ingredients.Length; i++)
                str += _ingredients[i].ToString() + "\n";
            return str;
        }
    }
}
