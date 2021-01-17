using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Objects;
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
            SqlServerDAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();
            int actual = studentDAO.GetAllStudents().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void GetStudentById(int id)
        {
            Student expected = new Student
            {
                StudentId = id
            };

            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();
            Student actual = studentDAO.GetStudentById(id);

            Assert.AreEqual(expected.StudentId, actual.StudentId);
        }

        [TestMethod]
        public void DeleteStudent()
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();

            int id = studentDAO.GetAllStudents()[studentDAO.GetAllStudents().Count - 1].StudentId;
            bool flag = studentDAO.DeleteStudent(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow("test1", "test1", "test1", Gender.Male, 1)]
        [DataRow("test2", "test2", "test2", Gender.Female, 2)]
        [DataRow("test3", "test3", "test3", Gender.Male, 3)]
        public void InsertStudent(string lastName, string firstName, string middleName, Gender gender, int groupId)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
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
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IStudentDAO studentDAO = sqlServerDAOFactory.GetStudentDAO();

            Student student = studentDAO.GetStudentById(id);
            student.LastName = lastName;
            Student updatedStudent = studentDAO.UpdateStudent(student);

            Assert.IsTrue(student == updatedStudent);
        }
    }
}
