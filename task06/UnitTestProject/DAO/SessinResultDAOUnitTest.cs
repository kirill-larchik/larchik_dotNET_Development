using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Objects;
using System;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class SessinResultDAOUnitTest
    {
        [TestMethod]
        public void GetAllSessionResults()
        {
            int expected = 500;
            SqlServerDAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();
            int actual = sessionResultDAO.GetAllSessionResults().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void GetSessionResultById(int id)
        {
            SessionResult expected = new SessionResult
            {
                SessionResultId = id
            };

            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();
            SessionResult actual = sessionResultDAO.GetSessionResultById(id);

            Assert.AreEqual(expected.SessionResultId, actual.SessionResultId);
        }

        [TestMethod]
        public void DeleteSessionResult()
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            int id = sessionResultDAO.GetAllSessionResults()[sessionResultDAO.GetAllSessionResults().Count - 1].SessionResultId;
            bool flag = sessionResultDAO.DeleteSessionResult(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow(1, "test1", SubjectCheckType.Exam, 1)]
        [DataRow(2, "test2", SubjectCheckType.Test, 5)]
        [DataRow(3, "test3", SubjectCheckType.Exam, 10)]
        public void InsertSessionResult(int sessionId, string subjectName, SubjectCheckType subjectCheckType, int mark)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            SessionResult sessionResult = new SessionResult
            {
                SessionId = sessionId,
                SubjectName = subjectName,
                SubjectCheckType = subjectCheckType,
                DateOfPassing = DateTime.Today,
                Mark = mark
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
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = sqlServerDAOFactory.GetSessionResultDAO();

            SessionResult sessionResult = sessionResultDAO.GetSessionResultById(id);
            sessionResult.Mark = mark;
            SessionResult updatedSessionResult = sessionResultDAO.UpdateSessionResult(sessionResult);

            Assert.IsTrue(sessionResult == updatedSessionResult);
        }
    }
}
