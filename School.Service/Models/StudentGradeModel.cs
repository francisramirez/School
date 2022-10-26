namespace School.Service.Models
{
    public class StudentGradeModel : StudentModel
    {
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public decimal Grade { get; set; }
    }
}
