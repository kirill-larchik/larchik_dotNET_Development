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
    public class SqlServerStudentDAO : IStudentDAO
    {
        private readonly string _connectionString;
        private const int limit = 1;

        private static SqlServerStudentDAO instance;

        private SqlServerStudentDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static SqlServerStudentDAO GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new SqlServerStudentDAO(connectionString);
            return instance;
        }

        public bool DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"delete from Students where Students.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public List<Student> GetAllStudents()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                List<Student> students = new List<Student>();

                string sqlCommand = @"select * from Students join Groups on Students.GroupId = Groups.Id where @limit = 1";
                SqlParameter parameter = new SqlParameter("@limit", limit);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(4)),
                            Birthday = reader.GetDateTime(5),
                            GroupId = reader.GetInt32(6),
                            GroupName = reader.GetString(8)
                        };

                        students.Add(student);
                    }
                }

                return students;
            }
        }

        public Student GetStudentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Student student = null;

                string sqlCommand = @"select * from Students join Groups on Students.GroupId = Groups.Id where Students.Id = @id";
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(parameter);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student = new Student
                        {
                            StudentId = reader.GetInt32(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(4)),
                            Birthday = reader.GetDateTime(5),
                            GroupId = reader.GetInt32(6),
                            GroupName = reader.GetString(8)
                        };
                    }
                }

                return student;
            }
        }

        public bool InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"insert into Students values (@lastName, @firstName, @middleName, @gender, @birthday, @groupId)";
                SqlParameter lastName = new SqlParameter("@lastName", student.LastName);
                SqlParameter firstName = new SqlParameter("@firstName", student.FirstName);
                SqlParameter middleName = new SqlParameter("@middleName", student.MiddleName);
                SqlParameter gender = new SqlParameter("@gender", Enum.GetName(typeof(Gender), student.Gender));
                SqlParameter birthday = new SqlParameter("@birthday", student.Birthday);
                SqlParameter groupId = new SqlParameter("@groupId", student.GroupId);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(lastName);
                command.Parameters.Add(firstName);
                command.Parameters.Add(middleName);
                command.Parameters.Add(gender);
                command.Parameters.Add(birthday);
                command.Parameters.Add(groupId);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return true;
                return false;
            }
        }

        public Student UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = @"update Students set Students.LastName = @lastName, Students.FirstName = @firstName, Students.MiddleName = @middleName, Students.Gender = @gender, Students.Birthday = @birthday, Students.GroupId = @groupId where Students.Id = @id";
                SqlParameter id = new SqlParameter("@id", student.StudentId);
                SqlParameter lastName = new SqlParameter("@lastName", student.LastName);
                SqlParameter firstName = new SqlParameter("@firstName", student.FirstName);
                SqlParameter middleName = new SqlParameter("@middleName", student.MiddleName);
                SqlParameter gender = new SqlParameter("@gender", Enum.GetName(typeof(Gender), student.Gender));
                SqlParameter birthday = new SqlParameter("@birthday", student.Birthday);
                SqlParameter groupId = new SqlParameter("@groupId", student.GroupId);

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.Add(id);
                command.Parameters.Add(lastName);
                command.Parameters.Add(firstName);
                command.Parameters.Add(middleName);
                command.Parameters.Add(gender);
                command.Parameters.Add(birthday);
                command.Parameters.Add(groupId);
                int count = command.ExecuteNonQuery();

                if (count == 1)
                    return student;
                return null;
            }
        }
    }
}
