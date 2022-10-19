using System;

namespace School.DAL.Entities
{
    public class Student : Core.Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
