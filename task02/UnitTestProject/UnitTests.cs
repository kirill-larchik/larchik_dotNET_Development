using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GoodsLibrary;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using GoodsExceptionLibrary;

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

        [DataTestMethod]
        [DataRow(100, 20, 10, 200, 10, 15)]
        [DataRow(110, 21, 11, 201, 10, 15)]
        [DataRow(120, 22, 13, 204, 17, 11)]
        public void Plus_Foods(double leftCost, double leftMarkup, int leftCount, int rightCost, double rightMarkup, int rightCount)
        {
            double cost = (leftCost * leftCount + rightCost * rightCount) / (leftCount + rightCount);
            double markup = (leftMarkup * leftCount + rightMarkup * rightCount) / (leftCount + rightCount);
            int count = leftCount + rightCount;
            Food expected = new Food("food", cost, markup, count);

            Food leftFood = new Food("food", leftCost, leftMarkup, leftCount);
            Food rightFood = new Food("food", rightCost, rightMarkup, rightCount);
            Good actual = leftFood + rightFood;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(23, 12, 11)]
        [DataRow(54, 2, 52)]
        [DataRow(4, 3, 1)]
        public void Minus_Materials(int leftCount, int rightCount, int expected)
        {
            Material material = new Material("material", 1, 1, leftCount);

            Good actual = material - rightCount;

            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod()]
        [DataRow(100, 20, 10, 200, 10, 15)]
        [DataRow(110, 21, 11, 201, 10, 15)]
        [DataRow(120, 22, 13, 204, 17, 11)]
        [ExpectedException(typeof(DifferentGoodsException))]
        public void Plus_GetException(double leftCost, double leftMarkup, int leftCount, int rightCost, double rightMarkup, int rightCount)
        {
            double cost = (leftCost * leftCount + rightCost * rightCount) / (leftCount + rightCount);
            double markup = (leftMarkup * leftCount + rightMarkup * rightCount) / (leftCount + rightCount);
            int count = leftCount + rightCount;
            Food expected = new Food("food", cost, markup, count);

            Food leftFood = new Food("food", leftCost, leftMarkup, leftCount);
            Material material = new Material("material", rightCost, rightMarkup, rightCount);
            Good actual = leftFood + material;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(23, 25, 11)]
        [DataRow(54, 100, 52)]
        [DataRow(4, 7, 1)]
        [ExpectedException(typeof(GoodNegativeCountException))]
        public void Minus_GetException(int leftCount, int rightCount, int expected)
        {
            Material material = new Material("material", 1, 1, leftCount);

            Good actual = material - rightCount;

            Assert.AreEqual(expected, actual.Count);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 11000)]
        [DataRow(200, 20, 2, 44000)]
        [DataRow(300, 30, 3, 99000)]
        public void ConvertToInt(double cost, double markup, int count, double expected)
        {
            Food food = new Food
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            int actual = (int)food;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 110)]
        [DataRow(200, 20, 2, 440)]
        [DataRow(300, 30, 3, 990)]
        public void ConvertToDouble(double cost, double markup, int count, double expected)
        {
            Food food = new Food
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            double actual = (double)food;

            Assert.AreEqual(expected, actual);
        }
    }
}
