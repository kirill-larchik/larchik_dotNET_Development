using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StudentSessionReportsLibrary.Objects;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using System.Collections.Generic;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class GroupDAOUnitTest
    {
        [TestMethod]
        public void GetAllGroups()
        {
            int expected = 100;

            SqlServerDAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();
            int actual = groupDAO.GetAllGroups().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1, "group1")]
        [DataRow(10, "group10")]
        [DataRow(100, "group100")]
        public void GetGroupById(int id, string name)
        {
            Group expected = new Group
            {
                GroupId = id,
                GroupName = name
            };

            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();
            Group actual = groupDAO.GetGroupById(id);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteGroup()
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            int id = groupDAO.GetAllGroups()[groupDAO.GetAllGroups().Count - 1].GroupId;
            bool flag = groupDAO.DeleteGroup(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow("newGroup1")]
        [DataRow("newGroup2")]
        [DataRow("newGroup3")]
        public void InsertGroup(string name)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            int oldCount = groupDAO.GetAllGroups().Count;
            bool flag = groupDAO.InsertGroup(new Group { GroupName = name });
            int newCount = groupDAO.GetAllGroups().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(3, "updGroup1")]
        [DataRow(4, "updGroup2")]
        [DataRow(6, "updGroup3")]
        public void UpdateGroup(int id, string name)
        {
            DAOFactory sqlServerDAOFactory = new SqlServerDAOFactory();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            Group group = groupDAO.GetGroupById(id);
            group.GroupName = name;
            Group updatedGroup = groupDAO.UpdateGroup(group);

            Assert.IsTrue(group == updatedGroup);
        }
    }
}
