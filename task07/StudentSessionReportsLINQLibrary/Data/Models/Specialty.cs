using System.Data.Linq.Mapping;

namespace StudentSessionReportsLINQLibrary.Data.Models
{
    /// <summary>
    /// A specailty of all students.
    /// </summary>
    [Table(Name = "Specialties")]
    public class Specialty
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}
