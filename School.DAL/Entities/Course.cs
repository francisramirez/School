using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DAL.Entities
{
    [Table("Course",Schema ="dbo")]
    public class Course : Core.BaseEntity
    {

        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

    }
}