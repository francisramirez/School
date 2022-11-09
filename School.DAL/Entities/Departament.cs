using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DAL.Entities
{
    [Table("Departments", Schema="dbo")]
    public class Departament : Core.BaseEntity
    {

        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int Administrator { get; set; }

    }
}