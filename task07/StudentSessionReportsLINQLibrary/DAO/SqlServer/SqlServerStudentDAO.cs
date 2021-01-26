using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLINQLibrary.DAO.SqlServer
{
    public class SqlServerStudentDAO : IStudentDAO
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerStudentDAO instance;

        private SqlServerStudentDAO(StudentSessionReportsContext context)
        {
            _context = context;
        }

        public static SqlServerStudentDAO GetInstance(StudentSessionReportsContext context)
        {
            if (instance == null)
                instance = new SqlServerStudentDAO(context);
            return instance;
        }

        public bool DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.DeleteOnSubmit(student);
                _context.SubmitChanges();
                return true;
            }

            return false;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public bool InsertStudent(Student student)
        {
            if (student != null)
            {
                _context.Students.InsertOnSubmit(student);
                _context.SubmitChanges();

                return true;
            }

            return false;
        }

        public Student UpdateStudent(Student student)
        {
            var updStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (updStudent != null)
            {
                updStudent.LastName = student.LastName;
                updStudent.FirstName = student.FirstName;
                updStudent.MiddleName = student.MiddleName;
                updStudent.Birthday = student.Birthday;
                updStudent.Gender = student.Gender;

                _context.SubmitChanges();
            }

            return updStudent;
        }
    }
}
