using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSessionReportsLibrary.DAO.DAOFactory;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Excel;

namespace UnitTestProject.Excel
{
    [TestClass]
    public class ExcelUnitTest
    {
        [DataTestMethod]
        [DataRow(SessionResultSortState.GroupAsc)]
        public void SaveStudentSessionReportToFile(SessionResultSortState sortState)
        {
            DAOFactory dAOFactory = new SqlServerDAOFactory();
            ISessionResultDAO sessionResultDAO = dAOFactory.GetSessionResultDAO();
            ExcelReport.SaveStudentSessionReportToFile(sessionResultDAO.GetAllSessionResults(), sortState);
        }
    }
}
