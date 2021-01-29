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
            collection.SortReports(sortState);

            Assert.IsTrue(collection.GetReports.Count != 0);
        }

        [DataTestMethod]
        [DataRow(AverageSpecilatyMarkSortState.SpecilatyDesc)]
        public void SetAverageSpecilatyMarkReports(AverageSpecilatyMarkSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            AverageSpecialtyMarkReportCollection collection = new AverageSpecialtyMarkReportCollection(context);
            collection.SortReports(sortState);

            Assert.IsTrue(collection.GetReports.Count != 0);
        }

        [DataTestMethod]
        [DataRow(AverageTeacherMarkSortState.TeacherNameAsc)]
        public void SetAverageTeacherMarkReports(AverageTeacherMarkSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            AverageTeacherMarkReportCollection collection = new AverageTeacherMarkReportCollection(context);
            collection.SortReports(sortState);

            Assert.IsTrue(collection.GetReports.Count != 0);
        }

        [DataTestMethod]
        [DataRow(AverageMarkDynamicSortState.SubjectNameDesc)]
        public void SetAverageMarkDynamicReports(AverageMarkDynamicSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            AverageMarkDynamicReportCollection collection = new AverageMarkDynamicReportCollection(context);
            collection.SortReports(sortState);

            Assert.IsTrue(collection.GetReports.Count != 0);
        }
    }
}
