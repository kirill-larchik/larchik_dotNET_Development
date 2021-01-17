using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Reports;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class ReportsUnitTest
    {
        [DataTestMethod]
        [DataRow(ExpelledStudentSortState.GenderAsc)]
        public void SetExpelledStudents(ExpelledStudentSortState sortState)
        {
            DAOFactory dAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = dAOFactory.GetSessionResultDAO();

            ReportCollection collection = new ReportCollection(sessionResultDAO.GetAllSessionResults());
            collection.SortExpelledStudents(sortState);

            Assert.IsTrue(collection.GetExpelledStudents.Count != 0);
        }
    }
}
