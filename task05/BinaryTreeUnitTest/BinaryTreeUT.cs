using BinaryTreeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BinaryTreeUnitTest
{
    [TestClass]
    public class BinaryTreeUT
    {
        [DataTestMethod]
        [DataRow(1, 2, 3, 4, 5, "1\n2\n3\n4\n5\n")]
        [DataRow(6, 3, 2, 1, 5, "1\n2\n3\n5\n6\n")]
        [DataRow(12, 56, 21, 67, 11, "11\n12\n21\n56\n67\n")]
        public void Insert_IntType(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, string expected)
        {
            BinaryTree<int> tree = new BinaryTree<int>(firstValue);
            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);

            string actual = tree.ToString();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("t", "te", "tes", "test", "test1", "t\nte\ntes\ntest\ntest1\n")]
        [DataRow("te", "t", "test1", "t", "te", "t\nte\ntest1\n")]
        [DataRow("te", "t", "test1", "tes", "test", "t\nte\ntes\ntest\ntest1\n")]
        public void Insert_StringType(string firstValue, string secondValue, string thirdValue, string fourthValue, string fifthValue, string expected)
        {
            BinaryTree<string> tree = new BinaryTree<string>(firstValue);

            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);

            string actual = tree.ToString();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, 2, 3, 4, 5, 3)]
        [DataRow(121, 242, 1, 123, 222, 1)]
        [DataRow(6, 2, 13, 64, 25, 13)]
        public void FindNode_IntType_FindThirdValue(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, int expected)
        {
            BinaryTree<int> tree = new BinaryTree<int>(firstValue);
            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);

            int actual = tree.FindNode(thirdValue).Value;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, 3, 2, 5, 4, 6)]
        [DataRow(11, 13, 12, 15, 16, 17)]
        [DataRow(10, 5, 16, 4, 7, 6)]
        public void Delete_IntType_WithChilds(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, int sixthValue)
        {
            BinaryTree<int> tree = new BinaryTree<int>(firstValue);
            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);
            tree.Insert(sixthValue);

            tree.Delete(secondValue);

            Assert.IsNull(tree.FindNode(secondValue));
        }

        [DataTestMethod]
        [DataRow(1, 2, 3, 5, 6, 7)]
        [DataRow(1, 3, 2, 5, 4, 6)]
        [DataRow(11, 13, 12, 15, 16, 17)]
        public void Delete_IntType_WithoutChilds(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, int sixthValue)
        {
            BinaryTree<int> tree = new BinaryTree<int>(firstValue);
            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);
            tree.Insert(sixthValue);

            tree.Delete(sixthValue);

            Assert.IsNull(tree.FindNode(sixthValue));
        }

        [DataTestMethod]
        [DataRow(8, 5, 6, 7, 9)]
        [DataRow(8, 5, 9, 4, 10)]
        [DataRow(10, 2, 3, 4, 5)]
        public void Delete_IntType_WithOneChild(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue)
        {
            BinaryTree<int> tree = new BinaryTree<int>(firstValue);
            tree.Insert(secondValue);
            tree.Insert(thirdValue);
            tree.Insert(fourthValue);
            tree.Insert(fifthValue);

            tree.Delete(secondValue);

            Assert.IsNull(tree.FindNode(secondValue));
        }

        [DataTestMethod]
        [DataRow(1, 2, 3, 4, 5)]
        public void Serialize_Deserialize(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue)
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\serializeFile.xml";

            BinaryTree<int> expected = new BinaryTree<int>(firstValue);
            expected.Insert(secondValue);
            expected.Insert(thirdValue);
            expected.Insert(fourthValue);
            expected.Insert(fifthValue);

            expected.Serialize(filePath);

            BinaryTree<int> actual = BinaryTree<int>.Deserialize(filePath);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [DataTestMethod]
        [DataRow(10, 8, 7, 6, 5, 4)]
        [DataRow(10, 8, 9, 5, 6, 4)]
        [DataRow(10, 11, 12, 13, 14, 15)]
        [DataRow(10, 12, 11, 14, 13, 15)]
        public void BalanceTree(int firstValue, int secondValue, int thirdValue, int fourthValue, int fifthValue, int sixthValue)
        {
            BinaryTree<int> expected = new BinaryTree<int>(firstValue);
            expected.Insert(secondValue);
            expected.Insert(thirdValue);
            expected.Insert(fourthValue);
            expected.Insert(fifthValue);
            expected.Insert(sixthValue);

            BinaryTree<int> actual = new BinaryTree<int>(firstValue);
            actual.Insert(secondValue);
            actual.Insert(thirdValue);
            actual.Insert(fourthValue);
            actual.Insert(fifthValue);
            actual.Insert(sixthValue);

            actual = actual.BalanceTree();

            Assert.IsFalse(expected.FindNode(fourthValue).Equals(actual.FindNode(fourthValue)));
        }
    }
}
