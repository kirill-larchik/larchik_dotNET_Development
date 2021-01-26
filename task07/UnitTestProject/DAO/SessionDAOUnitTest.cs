using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data.Models;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class SessionDAOUnitTest
    {
        [TestMethod]
        public void GetAllSessions()
        {
            int expected = 50;

            SqlServerDAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();
            int actual = sessionDAO.GetAllSessions().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void GetSessionById(int id)
        {
            Session expected = new Session
            {
                Id = id,
            };

            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();
            Session actual = sessionDAO.GetSessionById(id);

            Assert.IsTrue(expected.Id == actual.Id);
        }

        [TestMethod]
        public void DeleteSession()
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            int id = sessionDAO.GetAllSessions()[sessionDAO.GetAllSessions().Count - 1].Id;
            bool flag = sessionDAO.DeleteSession(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        public void InsertSession(int number, int studentId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            int oldCount = sessionDAO.GetAllSessions().Count;
            bool flag = sessionDAO.InsertSession(new Session { NumberOfSession = number, StudentId = studentId });
            int newCount = sessionDAO.GetAllSessions().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(4, 1, 1)]
        [DataRow(5, 2, 2)]
        [DataRow(6, 3, 3)]
        public void UpdateSession(int id, int number, int studentId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            Session session = sessionDAO.GetSessionById(id);
            session.NumberOfSession = number;
            session.StudentId = studentId;
            Session updatedSession = sessionDAO.UpdateSession(session);

            Assert.IsTrue(session.NumberOfSession == updatedSession.NumberOfSession && session.StudentId == updatedSession.StudentId);
        }
    }
}
