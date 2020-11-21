using IngredientsLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BakeryProductsLibrary
{
    public enum SortState
    {
        Calaorie,
        Cost
    }

    /// <summary>
    /// Class describing a bakery products collection.
    /// </summary>
    public class BakeryProductsCollection
    {
        private IBakeryProduct[] _products;

        /// <summary>
        /// Returns count of products.
        /// </summary>
        public int Count { get { return _products.Length; } }

        /// <summary>
        /// Inits a bakery products collection.
        /// </summary>
        /// <param name="filePath"></param>
        public BakeryProductsCollection(string filePath)
        {
            ReadFile(filePath);
        }

        /// <summary>
        /// Reads entities from file.
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string[] productsLines = null;
                    IList<Ingredient> ingredients = null;
                    IList<IBakeryProduct> bakeryProducts = new List<IBakeryProduct>();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.StartsWith("\t"))
                        {
                            if (productsLines != null)
                            {
                                bakeryProducts.Add(GetBakeryProduct(productsLines[0], productsLines[1], ingredients.ToArray()));
                            }

                            productsLines = line.Split(' ');
                            ingredients = new List<Ingredient>();
                        }
                        else
                        {
                            string[] lines = line.Split(' ');

                            string typeName = lines[0].Remove(0, 1);

                            double cost = double.Parse(lines[1]);
                            double value = double.Parse(lines[2]);
                            double calorie = lines.Count() == 4 ? double.Parse(lines[3]) : 0;

                            ingredients.Add(GetIngredient(typeName, cost, value, calorie));
                        }
                    }
                    //Add last.
                    bakeryProducts.Add(GetBakeryProduct(productsLines[0], productsLines[1], ingredients.ToArray()));

                    _products = bakeryProducts.ToArray();
                }
            }
        }

        private IBakeryProduct GetBakeryProduct(string typeName, string productName, Ingredient[] ingredients)
        {
            IBakeryProduct bakeryProduct = null;
            switch (typeName)
            {
                case nameof(Bread):
                    bakeryProduct = new Bread(productName, ingredients);
                    break;
                case nameof(Loaf):
                    bakeryProduct = new Loaf(productName, ingredients);
                    break;
            }

            return bakeryProduct;
        }

        private Ingredient GetIngredient(string typeName, double cost, double value, double calorie)
        {
            Ingredient ingredient = null;
            switch (typeName)
            {
                case nameof(Flour):
                    ingredient = new Flour(calorie, cost, value);
                    break;
                case nameof(Water):
                    ingredient = new Water(cost, value);
                    break;
                case nameof(Yeast):
                    ingredient = new Yeast(calorie, cost, value);
                    break;
            }

            return ingredient;
        }

        /// <summary>
        /// Returns sorted array.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IBakeryProduct[] GetSortedArray(SortState state)
        {
            IBakeryProduct[] bakeryProducts = new IBakeryProduct[Count];
            Array.Copy(_products, bakeryProducts, Count);

            IBakeryProduct temp;
            for (int i = 0; i < bakeryProducts.Length - 1; i++)
            {
                for (int j = i + 1; j < bakeryProducts.Length; j++)
                {
                    switch (state)
                    {
                        case SortState.Calaorie:
                            if (bakeryProducts[i].GetCalorie() > bakeryProducts[j].GetCalorie())
                            {
                                temp = bakeryProducts[i];
                                bakeryProducts[i] = bakeryProducts[j];
                                bakeryProducts[j] = temp;
                            }
                            break;
                        case SortState.Cost:
                            if (bakeryProducts[i].GetCost() > bakeryProducts[j].GetCost())
                            {
                                temp = bakeryProducts[i];
                                bakeryProducts[i] = bakeryProducts[j];
                                bakeryProducts[j] = temp;
                            }
                            break;
                    }
                    
                }
            }

            return bakeryProducts;
        }

        /// <summary>
        /// Returns array by given product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IBakeryProduct[] GetProducts(IBakeryProduct product)
        {
            IList<IBakeryProduct> products = new List<IBakeryProduct>();

            for (int i = 0; i < Count; i++)
            {
                if (_products[i].GetCalorie() == product.GetCalorie() && _products[i].GetCost() == product.GetCost())
                    products.Add(_products[i]);
            }

            return products.ToArray();
        }

        /// <summary>
        /// Returns array by given ingredient.
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public IBakeryProduct[] GetProducts(Ingredient ingredient)
        {
            IList<IBakeryProduct> products = new List<IBakeryProduct>();

            for (int i = 0; i < Count; i++)
            {
                Ingredient[] ingredients = _products[i].GetIngredients();
                for (int j = 0; j < ingredients.Length; j++)
                {
                    if (ingredients[j].GetType().Name == ingredient.GetType().Name && ingredients[j].Value > ingredient.Value)
                    {
                        products.Add(_products[i]);
                        break;
                    }
                }
            }

            return products.ToArray();
        }

        /// <summary>
        /// Returns array by given count.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IBakeryProduct[] GetProducts(int count)
        {
            IList<IBakeryProduct> products = new List<IBakeryProduct>();

            for (int i = 0; i < Count; i++)
            {
                Ingredient[] ingredients = _products[i].GetIngredients();
                if (ingredients.Length > count)
                    products.Add(_products[i]);
            }

            return products.ToArray();
        }

    }
}
