using System;
using System.IO;
using System.Threading;
using BinaryTreeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLibrary;

namespace BinaryTreeUnitTest
{
    [TestClass]
    public class StudentBinaryTreeUT
    {
        [TestMethod]
        public void Insert_Student()
        {
            DateTime date = new DateTime(2020, 8, 8);

            string expected = $"Name: Q W E, TestName: test2, Date: {date.ToString("d")}, Mark: 4;\n\nName: A B C, TestName: test1, Date: {date.ToString("d")}, Mark: 8;\n\n";

            StudentTest firstTest = new StudentTest("A B C", "test1", date, Mark.Eight);
            StudentTest secondTest = new StudentTest("Q W E", "test2", date, Mark.Four);
            
            BinaryTree<StudentTest> tree = new BinaryTree<StudentTest>(firstTest);
            tree.Insert(secondTest);

            string actual = tree.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_Student()
        {
            StudentTest firstTest = new StudentTest("A B C", "test1", DateTime.Now, Mark.Eight);
            StudentTest secondTest = new StudentTest("Q W E", "test2", DateTime.Now, Mark.Four);
            StudentTest expected = new StudentTest("Q W E", "test3", DateTime.Now, Mark.Five);

            BinaryTree<StudentTest> tree = new BinaryTree<StudentTest>(firstTest);
            tree.Insert(secondTest);
            tree.Insert(expected);

            BinaryTree<StudentTest> actual = tree.FindNode(expected);

            Assert.AreEqual(expected, actual.Value);
        }

        [TestMethod]
        public void Delete_Student()
        {
            StudentTest firstTest = new StudentTest("A B C", "test1", DateTime.Now, Mark.Eight);
            StudentTest secondTest = new StudentTest("Q W E", "test2", DateTime.Now, Mark.Four);
            StudentTest expected = new StudentTest("Q W E", "test3", DateTime.Now, Mark.Five);

            BinaryTree<StudentTest> tree = new BinaryTree<StudentTest>(firstTest);
            tree.Insert(secondTest);
            tree.Insert(expected);

            tree.Delete(expected);
            
            Thread.Sleep(200);

            Assert.IsNull(tree.FindNode(expected));
        }

        [TestMethod]
        public void Serialize_Student()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\XmlFiles\StudentSerializeFile.xml";

            StudentTest firstTest = new StudentTest("A B C", "test1", DateTime.Now, Mark.Eight);
            StudentTest secondTest = new StudentTest("Q W E", "test2", DateTime.Now, Mark.Four);
            StudentTest thirdTest = new StudentTest("Q W E", "test3", DateTime.Now, Mark.Five);

            BinaryTree<StudentTest> expected = new BinaryTree<StudentTest>(firstTest);
            expected.Insert(secondTest);
            expected.Insert(thirdTest);

            expected.Serialize(filePath);

            BinaryTree<StudentTest> actual = BinaryTree<StudentTest>.Deserialize(filePath);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
