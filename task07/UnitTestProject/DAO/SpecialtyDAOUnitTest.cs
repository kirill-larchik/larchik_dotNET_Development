using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data.Models;

namespace UnitTestProject.DAO
{
    [TestClass]
    public class SpecialtyDAOUnitTest
    {
        [TestMethod]
        public void GetAllSpecialties()
        {
            int expected = 5;

            SqlServerDAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISpecialtyDAO specialtyDAO = sqlServerDAOFactory.GetSpecialtyDAO();
            int actual = specialtyDAO.GetAllSpecialties().Count;

            Assert.IsTrue(actual > expected);
        }

        [DataTestMethod]
        [DataRow(1, "specialty1")]
        [DataRow(2, "specialty2")]
        [DataRow(3, "specialty3")]
        public void GetSpecialtyById(int id, string name)
        {
            Specialty expected = new Specialty
            {
                Id = id,
                Name = name
            };

            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISpecialtyDAO specialtyDAO = sqlServerDAOFactory.GetSpecialtyDAO();
            Specialty actual = specialtyDAO.GetSpecialtyById(id);

            Assert.IsTrue(expected.Id == actual.Id && expected.Name == actual.Name);
        }

        [TestMethod]
        public void DeleteSpecialty()
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISpecialtyDAO specialtyDAO = sqlServerDAOFactory.GetSpecialtyDAO();

            int id = specialtyDAO.GetAllSpecialties()[specialtyDAO.GetAllSpecialties().Count - 1].Id;
            bool flag = specialtyDAO.DeleteSpecialty(id);

            Assert.IsTrue(flag);
        }

        [DataTestMethod]
        [DataRow("newSpecialty1", 1)]
        [DataRow("newSpecialty2", 2)]
        [DataRow("newSpecialty3", 3)]
        public void InsertSpecialty(string name, int specialtyId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISpecialtyDAO specialtyDAO = sqlServerDAOFactory.GetSpecialtyDAO();

            int oldCount = specialtyDAO.GetAllSpecialties().Count;
            bool flag = specialtyDAO.InsertSpecialty(new Specialty { Name = name, Id = specialtyId });
            int newCount = specialtyDAO.GetAllSpecialties().Count;

            Assert.IsTrue(flag && oldCount < newCount);
        }

        [DataTestMethod]
        [DataRow(4, "updSpecialty4", 1)]
        [DataRow(5, "updSpecialty5", 2)]
        [DataRow(6, "updSpecialty6", 3)]
        public void UpdateSpecialty(int id, string name, int specialtyId)
        {
            DAOFactory sqlServerDAOFactory = SqlServerDAOFactory.GetInstance();
            ISpecialtyDAO specialtyDAO = sqlServerDAOFactory.GetSpecialtyDAO();

            Specialty specialty = specialtyDAO.GetSpecialtyById(id);
            specialty.Name = name;
            Specialty updatedSpecialty = specialtyDAO.UpdateSpecialty(specialty);

            Assert.IsTrue(specialty.Name == updatedSpecialty.Name && specialty.Id == updatedSpecialty.Id);
        }
    }
}
