using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Reports;
using System;
using System.Configuration;

namespace UnitTestProject
{
    [TestClass]
    public class ReportsUnitTest
    {
        [DataTestMethod]
        [DataRow(ExpelledStudentSortState.GenderAsc)]
        public void SetExpelledStudents(ExpelledStudentSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            ExpelledStudentReportCollection collection = new ExpelledStudentReportCollection(context);
            collection.SortExpelledStudents(sortState);

            Assert.IsTrue(collection.GetReports.Count != 0);
        }
    }
}
