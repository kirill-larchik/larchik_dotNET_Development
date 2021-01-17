using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLibrary.DAO.Interfaces;
using StudentSessionReportsLibrary.Objects;

namespace StudentSessionReportsLibrary.DAO.SqlServer
{
    public class SqlServerSessionResultDAO : ISessionResultDAO
    {
        private readonly string _connectionString;
        private const int limit = 1;

        private static SqlServerSessionResultDAO instance;

        private SqlServerSessionResultDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqlServerSessionResultDAO GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new SqlServerSessionResultDAO(connectionString);
            return instance;
        }

        public bool DeleteSessionResult(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"delete from SessionResults where SessionResults.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public List<SessionResult> GetAllSessionResults()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                List<SessionResult> sessionResults = new List<SessionResult>();

                string sqlCommand = @"select * from SessionResults join Sessions on SessionResults.SessionId = Sessions.Id join Students on Sessions.StudentId = Students.Id join Groups on Students.GroupId = Groups.Id where @limit = 1";
                SqlParameter parameter = new SqlParameter("@limit", limit);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SessionResult sessionResult = new SessionResult
                        {
                            SessionResultId = reader.GetInt32(0),
                            SessionId = reader.GetInt32(1),
                            SubjectName = reader.GetString(2),
                            SubjectCheckType = (SubjectCheckType)Enum.Parse(typeof(SubjectCheckType), reader.GetString(3)),
                            DateOfPassing = reader.GetDateTime(4),
                            Mark = reader.GetInt32(5),
                            NumberOfSession = reader.GetInt32(7),
                            StudentId = reader.GetInt32(8),
                            LastName = reader.GetString(10),
                            FirstName = reader.GetString(11),
                            MiddleName = reader.GetString(12),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(13)),
                            Birthday = reader.GetDateTime(14),
                            GroupId = reader.GetInt32(15),
                            GroupName = reader.GetString(17)
                        };

                        sessionResults.Add(sessionResult);
                    }
                }

                return sessionResults;
            }
        }

        public SessionResult GetSessionResultById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SessionResult sessionResult = null;

                string sqlCommand = @"select * from SessionResults join Sessions on SessionResults.SessionId = Sessions.Id join Students on Sessions.StudentId = Students.Id join Groups on Students.GroupId = Groups.Id where SessionResults.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sessionResult = new SessionResult
                        {
                            SessionResultId = reader.GetInt32(0),
                            SessionId = reader.GetInt32(1),
                            SubjectName = reader.GetString(2),
                            SubjectCheckType = (SubjectCheckType)Enum.Parse(typeof(SubjectCheckType), reader.GetString(3)),
                            DateOfPassing = reader.GetDateTime(4),
                            Mark = reader.GetInt32(5),
                            NumberOfSession = reader.GetInt32(7),
                            StudentId = reader.GetInt32(8),
                            LastName = reader.GetString(10),
                            FirstName = reader.GetString(11),
                            MiddleName = reader.GetString(12),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(13)),
                            Birthday = reader.GetDateTime(14),
                            GroupId = reader.GetInt32(15),
                            GroupName = reader.GetString(17)
                        };
                    }
                }

                return sessionResult;
            }
        }

        public bool InsertSessionResult(SessionResult sessionResult)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"insert into SessionResults values (@sessionId, @subjectName, @subjectCheckType, @dateOfPassing, @mark)";
                SqlParameter sessionIdParameter = new SqlParameter("@sessionId", sessionResult.SessionId);
                SqlParameter subjectNameParameter = new SqlParameter("@subjectName", sessionResult.SubjectName);
                SqlParameter subjectCheckTypeParameter = new SqlParameter("@subjectCheckType", Enum.GetName(typeof(SubjectCheckType), sessionResult.SubjectCheckType));
                SqlParameter dateOfPassingParameter = new SqlParameter("@dateOfPassing", sessionResult.DateOfPassing);
                SqlParameter markParameter = new SqlParameter("@mark", sessionResult.Mark);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(sessionIdParameter);
                command.Parameters.Add(subjectNameParameter);
                command.Parameters.Add(subjectCheckTypeParameter);
                command.Parameters.Add(dateOfPassingParameter);
                command.Parameters.Add(markParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public SessionResult UpdateSessionResult(SessionResult sessionResult)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"update SessionResults set SessionResults.SessionId = @sessionId, SessionResults.SubjectName = @subjectName, SessionResults.SubjectCheckType = @subjectCheckType, SessionResults.DateOfPassing = @dateOfPassing, SessionResults.Mark = @mark where SessionResults.Id = @id";
                SqlParameter idParameter = new SqlParameter("@id", sessionResult.SessionResultId);
                SqlParameter sessionIdParameter = new SqlParameter("@sessionId", sessionResult.SessionId);
                SqlParameter subjectNameParameter = new SqlParameter("@subjectName", sessionResult.SubjectName);
                SqlParameter subjectCheckTypeParameter = new SqlParameter("@subjectCheckType", Enum.GetName(typeof(SubjectCheckType), sessionResult.SubjectCheckType));
                SqlParameter dateOfPassingParameter = new SqlParameter("@dateOfPassing", sessionResult.DateOfPassing);
                SqlParameter markParameter = new SqlParameter("@mark", sessionResult.Mark);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(idParameter);
                command.Parameters.Add(sessionIdParameter);
                command.Parameters.Add(subjectNameParameter);
                command.Parameters.Add(subjectCheckTypeParameter);
                command.Parameters.Add(dateOfPassingParameter);
                command.Parameters.Add(markParameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return sessionResult;
                return null;
            }
        }
    }
}
