namespace School.DAL.Entities
{
    public class Student : Core.Person
    {
        public string Matricula { get; set; }
        public Course Curso { get; set; }
        public Area Area { get; set; }
    }
}
