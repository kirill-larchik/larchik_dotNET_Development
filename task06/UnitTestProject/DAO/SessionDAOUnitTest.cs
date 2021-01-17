using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class SessionDAOUnitTest
    {
        [TestMethod]
        public void GetAllSessions()
        {
            int expected = 5000;
            SqlServerDAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();
            int actual = sessionDAO.GetAllSessions().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        public void GetSessionById(int id)
        {
            Session expected = new Session
            {
                SessionId = id
            };

            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();
            Session actual = sessionDAO.GetSessionById(id);

            Assert.AreEqual(expected.SessionId, actual.SessionId);
        }

        [TestMethod]
        public void DeleteSession()
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            int id = sessionDAO.GetAllSessions()[sessionDAO.GetAllSessions().Count - 1].SessionId;
            bool flag = sessionDAO.DeleteSession(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow(7, 11)]
        [DataRow(7, 12)]
        [DataRow(7, 13)]
        public void InsertSession(int numberOfSession, int studentId)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            int oldCount = sessionDAO.GetAllSessions().Count;
            bool flag = sessionDAO.InsertSession(new Session { NumberOfSession = numberOfSession, StudentId = studentId});
            int newCount = sessionDAO.GetAllSessions().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(2, 7)]
        [DataRow(3, 7)]
        [DataRow(4, 7)]
        public void UpdateSession(int id, int numberOfSession)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            ISessionDAO sessionDAO = sqlServerDAOFactory.GetSessionDAO();

            Session session = sessionDAO.GetSessionById(id);
            session.NumberOfSession = numberOfSession;
            Session updatedSession = sessionDAO.UpdateSession(session);

            Assert.IsTrue(session == updatedSession);
        }
    }
}
