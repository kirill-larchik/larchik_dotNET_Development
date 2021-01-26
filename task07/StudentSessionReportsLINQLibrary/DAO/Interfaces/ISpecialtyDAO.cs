using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;

namespace StudentSessionReportsLINQLibrary.DAO.Interfaces
{
    public interface ISpecialtyDAO
    {
        List<Specialty> GetAllSpecialties();
        Specialty GetSpecialtyById(int id);
        Specialty UpdateSpecialty(Specialty specialty);
        bool DeleteSpecialty(int id);
        bool InsertSpecialty(Specialty specialty);
    }
}
