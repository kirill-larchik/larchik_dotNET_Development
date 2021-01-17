using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Excel;
using StudentSessionReportsLibrary.Reports;
using System.IO;

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
            DAOFactory dAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = dAOFactory.GetSessionResultDAO();

            ReportCollection collection = new ReportCollection(sessionResultDAO.GetAllSessionResults());
            collection.SortSummaryMarks(sortState);

            ExcelReport.SaveSummaryMarkToFile(Directory.GetCurrentDirectory() + filePath, collection.GetSummaryMark);
        }

        [DataTestMethod]
        [DataRow(@"\SessionResultsByFullNameAsc.xlsx", SessionResultSortState.FullNameAsc)]
        [DataRow(@"\SessionResultsByAverageMarkDesc.xlsx", SessionResultSortState.AverageMarkDesc)]
        public void SaveSessionResultsToFile(string filePath, SessionResultSortState sortState)
        {
            DAOFactory dAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = dAOFactory.GetSessionResultDAO();

            ReportCollection collection = new ReportCollection(sessionResultDAO.GetAllSessionResults());
            collection.SortSessionReports(sortState);

            ExcelReport.SaveSessionResultsToFile(Directory.GetCurrentDirectory() + filePath, collection.GetSessionReports);
        }
    }
}
