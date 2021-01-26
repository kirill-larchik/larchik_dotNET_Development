using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLINQLibrary.DAO.SqlServer
{
    public class SqlServerSpecialtyDAO : ISpecialtyDAO
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerSpecialtyDAO instance;

        private SqlServerSpecialtyDAO(StudentSessionReportsContext context)
        {
            _context = context;
        }

        public static SqlServerSpecialtyDAO GetInstance(StudentSessionReportsContext context)
        {
            if (instance == null)
                instance = new SqlServerSpecialtyDAO(context);
            return instance;
        }

        public bool DeleteSpecialty(int id)
        {
            var specialty = _context.Specialties.FirstOrDefault(g => g.Id == id);
            if (specialty != null)
            {
                _context.Specialties.DeleteOnSubmit(specialty);
                _context.SubmitChanges();
                return true;
            }

            return false;
        }

        public List<Specialty> GetAllSpecialties()
        {
            return _context.Specialties.ToList();
        }

        public Specialty GetSpecialtyById(int id)
        {
            var specialty = _context.Specialties.FirstOrDefault(g => g.Id == id);
            return specialty;
        }

        public bool InsertSpecialty(Specialty specialty)
        {
            if (specialty != null)
            {
                _context.Specialties.InsertOnSubmit(specialty);
                _context.SubmitChanges();

                return true;
            }

            return false;
        }

        public Specialty UpdateSpecialty(Specialty specialty)
        {
            var updSpecialty = _context.Specialties.FirstOrDefault(g => g.Id == specialty.Id);
            if (updSpecialty != null)
            {
                updSpecialty.Name = specialty.Name;
                _context.SubmitChanges();
            }

            return updSpecialty;
        }
    }
}
