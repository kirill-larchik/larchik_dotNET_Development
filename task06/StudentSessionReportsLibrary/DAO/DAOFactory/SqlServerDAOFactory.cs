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
    public class SqlServerDAOFactory : DAOFactory
    {
        private readonly string _connectionString;

        public SqlServerDAOFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MSSqlServer"].ToString();
        }

        public override IGroupDAO GetGroupDAO()
        {
            return new SqlServerGroupDAO(_connectionString);
        }

        public override ISessionDAO GetSessionDAO()
        {
            return new SqlServerSessionDAO(_connectionString);
        }

        public override ISessionResultDAO GetSessionResultDAO()
        {
            return new SqlServerSessionResultDAO(_connectionString);
        }

        public override IStudentDAO GetStudentDAO()
        {
            return new SqlServerStudentDAO(_connectionString);
        }
    }
}
