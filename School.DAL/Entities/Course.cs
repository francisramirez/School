namespace School.DAL.Entities
{
    public class Course : Core.BaseEntity
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

    }
}