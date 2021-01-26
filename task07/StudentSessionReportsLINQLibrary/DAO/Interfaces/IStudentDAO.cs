using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;

namespace StudentSessionReportsLINQLibrary.DAO.Interfaces
{
    public interface IStudentDAO
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student UpdateStudent(Student student);
        bool DeleteStudent(int id);
        bool InsertStudent(Student student);
    }
}
