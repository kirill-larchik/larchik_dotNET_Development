using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.Data.Models;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using System;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class SessionResultDAOUnitTest
    {
        [TestMethod]
        public void GetAllSessionResults()
        {
            int expected = 500;
            SqlServerDAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();
            int actual = sessionResultDAO.GetAllSessionResults().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1, "SubjectName1")]
        [DataRow(2, "SubjectName2")]
        [DataRow(3, "SubjectName3")]
        public void GetSessionResultById(int id, string subjectName)
        {
            SessionResult expected = new SessionResult
            {
                Id = id,
                SubjectName = subjectName
            };

            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();
            SessionResult actual = sessionResultDAO.GetSessionResultById(id);

            Assert.IsTrue(expected.Id == actual.Id && expected.SubjectName == actual.SubjectName);
        }

        [TestMethod]
        public void DeleteSessionResult()
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            int id = sessionResultDAO.GetAllSessionResults()[sessionResultDAO.GetAllSessionResults().Count - 1].Id;
            bool flag = sessionResultDAO.DeleteSessionResult(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow(1, "test1", "Exam", 1, "newTeacherFIO")]
        [DataRow(2, "test2", "Test", 5, "newTeacherFIO")]
        [DataRow(3, "test3", "Exam", 10, "newTeacherFIO")]
        public void InsertSessionResult(int sessionId, string subjectName, string subjectCheckType, int mark, string teacher)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            SessionResult sessionResult = new SessionResult
            {
                SessionId = sessionId,
                SubjectName = subjectName,
                SubjectCheckType = subjectCheckType,
                DateOfPassing = DateTime.Today,
                Mark = mark,
                TeacherFullName = teacher
            };

            int oldCount = sessionResultDAO.GetAllSessionResults().Count;
            bool flag = sessionResultDAO.InsertSessionResult(sessionResult);
            int newCount = sessionResultDAO.GetAllSessionResults().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(4, 1)]
        [DataRow(5, 1)]
        [DataRow(6, 1)]
        public void UpdateSessionResult(int id, int mark)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            SessionResult sessionResult = sessionResultDAO.GetSessionResultById(id);
            sessionResult.Mark = mark;
            SessionResult updatedSessionResult = sessionResultDAO.UpdateSessionResult(sessionResult);

            Assert.IsTrue(sessionResult == updatedSessionResult);
        }
    }
}
