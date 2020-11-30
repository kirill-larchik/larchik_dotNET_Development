using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodsLibrary;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        readonly string filePath = Directory.GetCurrentDirectory() + @"\file.json";

        [DataTestMethod]
        [DataRow(100, 10, 110)]
        [DataRow(200, 20, 220)]
        [DataRow(300, 30, 330)]
        public void GetUnitCost(double cost, double markup, double expected)
        {
            Food food = new Food
            {
                Cost = cost,
                Markup = markup
            };

            double actual = food.GetUnitCost();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 110)]
        [DataRow(200, 20, 2, 440)]
        [DataRow(300, 30, 3, 990)]
        public void GetTotalCost(double cost, double markup, int count, double expected)
        {
            Food food = new Food
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            double actual = food.GetTotalCost();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveToFIle()
        {
            Food food = new Food("food1", 10, 11, 2);
            Material material = new Material("material1", 12, 13, 3);
            Furniture furniture = new Furniture("furniture1", 13, 14, 4);

            GoodsCollection collection = new GoodsCollection(food, material, furniture);
            collection.SaveToFile(filePath);
            
            Assert.IsTrue(File.ReadAllText(filePath).Length > 0);
        }

        [TestMethod]
        public void ReadFIle()
        {
            Food food = new Food("food1", 10, 11, 2);
            Material material = new Material("material1", 12, 13, 3);
            Furniture furniture = new Furniture("furniture1", 13, 14, 4);
            GoodsCollection expectedCollection = new GoodsCollection(food, material, furniture);
            List<Good> expected = expectedCollection.GetGoods();
            
            GoodsCollection actualCollection = new GoodsCollection();
            actualCollection.ReadFile(Directory.GetCurrentDirectory() + @"\file.json");
            List<Good> actual = actualCollection.GetGoods();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
