using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLINQLibrary.DAO.DAOFactory;
using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Reports.Excel;
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
            summaryMarkReportCollection.SortReports(sortState);

            SummaryMarkReportExcel excelReport = new SummaryMarkReportExcel(Directory.GetCurrentDirectory() + filePath);
            excelReport.SaveToFile(summaryMarkReportCollection.GetReports);
        }

        [DataTestMethod]
        [DataRow(@"\AverageGroupMarkByFullNameAsc.xlsx", AverageGroupMarkSortState.FullNameAsc)]
        [DataRow(@"\AverageGroupMarkByAverageMarkDesc.xlsx", AverageGroupMarkSortState.AverageMarkDesc)]
        public void SaveAverageGroupMarkReportsToFile(string filePath, AverageGroupMarkSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            AverageGroupMarkReportCollection collection = new AverageGroupMarkReportCollection(context);
            collection.GenerateReports();
            collection.SortReports(sortState);

            AverageGroupMarkReportExcel excelReport = new AverageGroupMarkReportExcel(Directory.GetCurrentDirectory() + filePath);
            excelReport.SaveToFile(collection.GetReports);
        }

        [DataTestMethod]
        [DataRow(@"\AverageMarkDynamicBySubjectNameAsc.xlsx", AverageMarkDynamicSortState.SubjectNameAsc)]
        [DataRow(@"\AverageMarkDynamicBySubjectNameDesc.xlsx", AverageMarkDynamicSortState.SubjectNameDesc)]
        public void SaveAverageMarkDynamickReportsToFile(string filePath, AverageMarkDynamicSortState sortState)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
            StudentSessionReportsContext context = new StudentSessionReportsContext(connectionString);

            AverageMarkDynamicReportCollection collection = new AverageMarkDynamicReportCollection(context);
            collection.GenerateReports();
            collection.SortReports(sortState);

            AverageMarkDynamicReportExcel excelReport = new AverageMarkDynamicReportExcel(Directory.GetCurrentDirectory() + filePath);
            excelReport.SaveToFile(collection.GetReports);
        }
    }
}
