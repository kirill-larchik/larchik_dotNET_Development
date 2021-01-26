using System.Data.Linq.Mapping;

namespace StudentSessionReportsLINQLibrary.Data.Models
{
    /// <summary>
    /// Group of a student.
    /// </summary>
    [Table(Name = "Groups")]
    public class Group
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "SpecialtyId")]
        public int SpecialtyId { get; set; }
    }
}
