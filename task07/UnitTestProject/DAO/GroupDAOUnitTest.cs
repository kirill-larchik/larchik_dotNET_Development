using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data.Models;
using StudentSessionReportsLINQLibrary.Reports;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class GroupDAOUnitTest
    {
        [TestMethod]
        public void GetAllGroups()
        {
            int expected = 50;

            SqlServerDAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();
            int actual = groupDAO.GetAllGroups().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1, "group1")]
        [DataRow(2, "group2")]
        [DataRow(3, "group3")]
        public void GetGroupById(int id, string name)
        {
            Group expected = new Group
            {
                Id = id,
                Name = name
            };

            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();
            Group actual = groupDAO.GetGroupById(id);

            Assert.IsTrue(expected.Id == actual.Id && expected.Name == actual.Name);
        }

        [TestMethod]
        public void DeleteGroup()
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            int id = groupDAO.GetAllGroups()[groupDAO.GetAllGroups().Count - 1].Id;
            bool flag = groupDAO.DeleteGroup(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow("newGroup1", 1)]
        [DataRow("newGroup2", 2)]
        [DataRow("newGroup3", 3)]
        public void InsertGroup(string name, int specialtyId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            int oldCount = groupDAO.GetAllGroups().Count;
            bool flag = groupDAO.InsertGroup(new Group { Name = name, SpecialtyId = specialtyId });
            int newCount = groupDAO.GetAllGroups().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(4, "updGroup4", 1)]
        [DataRow(5, "updGroup5", 2)]
        [DataRow(6, "updGroup6", 3)]
        public void UpdateGroup(int id, string name, int specialtyId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            IGroupDAO groupDAO = sqlServerDAOFactory.GetGroupDAO();

            Group group = groupDAO.GetGroupById(id);
            group.Name = name;
            group.SpecialtyId = specialtyId;
            Group updatedGroup = groupDAO.UpdateGroup(group);

            Assert.IsTrue(group.Name == updatedGroup.Name && group.SpecialtyId == updatedGroup.SpecialtyId);
        }
    }
}
