using System;

namespace School.DAL.Entities
{
    public class Professor : Core.Person
    {
        public int Id { get; set; }
        public string CodProfessor { get; set; }
        public DateTime HireDate { get; set; }
    }
}
