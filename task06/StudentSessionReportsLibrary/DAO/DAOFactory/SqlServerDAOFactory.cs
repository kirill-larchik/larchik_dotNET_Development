using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.DAO.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.DAOFactory
{
    /// <summary>
    /// A DAO factory for MS-SQLServer
    /// </summary>
    public class SqlServerDAOFactory : DAOFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Init a DAO factory for MS SQL Server.
        /// </summary>
        public SqlServerDAOFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
        }

        public override IGroupDAO GetGroupDAO()
        {
            return SqlServerGroupDAO.GetInstance(_connectionString);
        }

        public override ISessionDAO GetSessionDAO()
        {
            return SqlServerSessionDAO.GetInstance(_connectionString);
        }

        public override ISessionResultDAO GetSessionResultDAO()
        {
            return SqlServerSessionResultDAO.GetInstance(_connectionString);
        }

        public override IStudentDAO GetStudentDAO()
        {
            return SqlServerStudentDAO.GetInstance(_connectionString);
        }
    }
}
