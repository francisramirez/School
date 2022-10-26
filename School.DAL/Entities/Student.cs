using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.DAL.Entities
{

    [Table("Students",Schema ="dbo")]
    public class Student : Core.Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }


    }
}
