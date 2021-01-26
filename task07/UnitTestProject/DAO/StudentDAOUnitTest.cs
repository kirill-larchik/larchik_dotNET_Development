using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.Data.Models;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using System;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class StudentDAOUnitTest
    {
        [TestMethod]
        public void GetAllStudents()
        {
            int expected = 500;
            SqlServerDAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();
            int actual = studentDAO.GetAllStudents().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1, "lastName1")]
        [DataRow(2, "lastName2")]
        [DataRow(3, "lastName3")]
        public void GetStudentById(int id, string lastName)
        {
            Student expected = new Student
            {
                Id = id,
                LastName = lastName
            };

            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();
            Student actual = studentDAO.GetStudentById(id);

            Assert.IsTrue(expected.Id == actual.Id && expected.LastName == actual.LastName);
        }

        [TestMethod]
        public void DeleteStudent()
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();

            int id = studentDAO.GetAllStudents()[studentDAO.GetAllStudents().Count - 1].Id;
            bool flag = studentDAO.DeleteStudent(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow("test1", "test1", "test1", "Male", 1)]
        [DataRow("test2", "test2", "test2", "Female", 2)]
        [DataRow("test3", "test3", "test3", "Male", 3)]
        public void InsertStudent(string lastName, string firstName, string middleName, string gender, int groupId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();

            Student student = new Student
            {
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Gender = gender,
                Birthday = DateTime.Today,
                GroupId = groupId
            };

            int oldCount = studentDAO.GetAllStudents().Count;
            bool flag = studentDAO.InsertStudent(student);
            int newCount = studentDAO.GetAllStudents().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(4, "test1")]
        [DataRow(5, "test2")]
        [DataRow(6, "test3")]
        public void UpdateStudent(int id, string lastName)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();

            Student student = studentDAO.GetStudentById(id);
            student.LastName = lastName;
            Student updatedStudent = studentDAO.UpdateStudent(student);

            Assert.IsTrue(student == updatedStudent);
        }
    }
}
