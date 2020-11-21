using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BakeryProductsLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        private readonly string filePath = Directory.GetCurrentDirectory() + @"\Files\Products.txt";

        [TestMethod]
        public void ReadFile()
        {
            BakeryProductsCollection collection = new BakeryProductsCollection(filePath);

            Assert.IsTrue(collection.Count == 4);
        }
    }
}
