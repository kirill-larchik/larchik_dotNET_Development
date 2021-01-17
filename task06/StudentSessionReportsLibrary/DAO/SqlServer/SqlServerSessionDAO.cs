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
    public class SqlServerSessionDAO : ISessionDAO
    {
        private readonly string _connectionString;
        private const int limit = 1;

        public SqlServerSessionDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool DeleteSession(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"delete from Sessions where Sessions.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public List<Session> GetAllSessions()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                List<Session> sessions = new List<Session>();

                string sqlCommand = @"select * from Sessions join Students on Sessions.StudentId = Students.Id join Groups on Students.GroupId = Groups.Id where @limit = 1";
                SqlParameter parameter = new SqlParameter("@limit", limit);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Session session = new Session
                        {
                            SessionId = reader.GetInt32(0),
                            NumberOfSession = reader.GetInt32(1),
                            StudentId = reader.GetInt32(2),
                            LastName = reader.GetString(4),
                            FirstName = reader.GetString(5),
                            MiddleName = reader.GetString(6),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(7)),
                            Birthday = reader.GetDateTime(8),
                            GroupId = reader.GetInt32(9),
                            GroupName = reader.GetString(11)
                        };

                        sessions.Add(session);
                    }
                }

                return sessions;
            }
        }

        public Session GetSessionById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Session session = null;

                string sqlCommand = @"select * from Sessions join Students on Sessions.StudentId = Students.Id join Groups on Students.GroupId = Groups.Id where Sessions.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        session = new Session
                        {
                            SessionId = reader.GetInt32(0),
                            NumberOfSession = reader.GetInt32(1),
                            StudentId = reader.GetInt32(2),
                            LastName = reader.GetString(4),
                            FirstName = reader.GetString(5),
                            MiddleName = reader.GetString(6),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(7)),
                            Birthday = reader.GetDateTime(8),
                            GroupId = reader.GetInt32(9),
                            GroupName = reader.GetString(11)
                        };
                    }
                }

                return session;
            }
        }

        public bool InsertSession(Session session)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"insert into Sessions values (@numberOfSession, @studentId)";
                SqlParameter numberParameter = new SqlParameter("@numberOfSession", session.NumberOfSession);
                SqlParameter idParameter = new SqlParameter("@studentId", session.StudentId);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(numberParameter);
                command.Parameters.Add(idParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public Session UpdateSession(Session session)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"update Sessions set Sessions.NumberOfSession = @numberOfSession, Sessions.StudentId = @studentId where Sessions.Id = @id";
                SqlParameter idParameter = new SqlParameter("@id", session.SessionId);
                SqlParameter numberParameter = new SqlParameter("@numberOfSession", session.NumberOfSession);
                SqlParameter studentIdParameter = new SqlParameter("@studentId", session.StudentId);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(idParameter);
                command.Parameters.Add(numberParameter);
                command.Parameters.Add(studentIdParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return session;
                return null;
            }
        }
    }
}
