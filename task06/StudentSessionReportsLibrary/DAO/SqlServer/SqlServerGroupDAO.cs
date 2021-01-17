using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.SqlServer
{
    public class SqlServerGroupDAO : IGroupDAO
    {
        private readonly string _connectionString;
        private const int limit = 1;

        public SqlServerGroupDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool DeleteGroup(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"delete from Groups where Groups.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);
                
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                int count = command.ExecuteNonQuery();
                
                if (count == 1)
                    return true;
                return false;
            }
        }

        public List<Group> GetAllGroups()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                List<Group> groups = new List<Group>();

                string sqlCommand = @"select * from Groups where @limit = 1";
                SqlParameter parameter = new SqlParameter("@limit", limit);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Group group = new Group
                        {
                            GroupId = reader.GetInt32(0),
                            GroupName = reader.GetString(1)
                        };

                        groups.Add(group);
                    }
                }

                return groups;
            }
        }

        public Group GetGroupById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Group group = null;

                string sqlCommand = @"select * from Groups where Groups.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        group = new Group
                        {
                            GroupId = reader.GetInt32(0),
                            GroupName = reader.GetString(1)
                        };
                    }
                }

                return group;
            }
        }

        public bool InsertGroup(Group group)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"insert into Groups values (@name)";
                SqlParameter nameParameter = new SqlParameter("@name", group.GroupName);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(nameParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public Group UpdateGroup(Group group)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"update Groups set Groups.Name = @name where Groups.Id = @id";
                SqlParameter idParameter = new SqlParameter("@id", group.GroupId);
                SqlParameter nameParameter = new SqlParameter("@name", group.GroupName);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(idParameter);
                command.Parameters.Add(nameParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return group;
                return null;
            }
        }
    }
}
