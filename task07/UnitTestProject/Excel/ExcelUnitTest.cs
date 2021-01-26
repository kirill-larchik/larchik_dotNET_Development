using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Excel;
using StudentSessionReportsLINQLibrary.Reports;
using StudentSessionReportsLINQLibrary.Data;
using System.IO;
using System.Configuration;

namespace UnitTestProject.Excel
{
    [TestClass]
    public class ExcelUnitTest
    {
        [DataTestMethod]
        [DataRow(@"\SummaryMarksByGroupAsc.xlsx", SummaryMarkSortState.GroupAsc)]
        [DataRow(@"\SummaryMarksByAverageDesc.xlsx", SummaryMarkSortState.AverageDesc)]
        public void SaveSummaryMarkToFile(string filePath, SummaryMarkSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            SummaryMarkReportCollection summaryMarkReportCollection = new SummaryMarkReportCollection(context);
            summaryMarkReportCollection.GenerateReports();
            summaryMarkReportCollection.SortSummaryMarks(sortState);

            ExcelReport.SaveSummaryMarkToFile(Directory.GetCurrentDirectory() + filePath, summaryMarkReportCollection.GetReports);
        }

        [DataTestMethod]
        [DataRow(@"\SessionResultsByFullNameAsc.xlsx", SessionResultSortState.FullNameAsc)]
        [DataRow(@"\SessionResultsByAverageMarkDesc.xlsx", SessionResultSortState.AverageMarkDesc)]
        public void SaveSessionResultsToFile(string filePath, SessionResultSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            SessionResultReportCollection collection = new SessionResultReportCollection(context);
            collection.GenerateReports();
            collection.SortSessionReports(sortState);

            ExcelReport.SaveSessionResultsToFile(Directory.GetCurrentDirectory() + filePath, collection.GetReports);
        }
    }
}
