namespace School.Web.Models
{
    public class CourseList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }

    }
}
