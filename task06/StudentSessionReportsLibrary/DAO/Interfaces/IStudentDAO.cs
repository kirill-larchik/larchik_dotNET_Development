using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.Interfaces
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
