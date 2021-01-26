using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.DAO.SqlServer;
using StudentSessionReportsLINQLibrary.Data;
using System.Configuration;

namespace StudentSessionReportsLINQLibrary.DAO.DAOFactory
{
    /// <summary>
    /// A DAO factory for MS-SQLServer
    /// </summary>
    public class SqlServerDAOFactory : DAOFactory
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerDAOFactory instance;

        /// <summary>
        /// Init a DAO factory for MS SQL Server.
        /// </summary>
        private SqlServerDAOFactory()
        {
            _context = new StudentSessionReportsContext(ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString());
        }

        public static SqlServerDAOFactory GetInstance()
        {
            if (instance == null)
                instance = new SqlServerDAOFactory();
            return instance;
        }

        public override IGroupDAO GetGroupDAO()
        {
            return SqlServerGroupDAO.GetInstance(_context);
        }

        public override ISessionDAO GetSessionDAO()
        {
            return SqlServerSessionDAO.GetInstance(_context);
        }

        public override ISessionResultDAO GetSessionResultDAO()
        {
            return SqlServerSessionResultDAO.GetInstance(_context);
        }

        public override IStudentDAO GetStudentDAO()
        {
            return SqlServerStudentDAO.GetInstance(_context);
        }

        public override ISpecialtyDAO GetSpecialtyDAO()
        {
            return SqlServerSpecialtyDAO.GetInstance(_context);
        }
    }
}
