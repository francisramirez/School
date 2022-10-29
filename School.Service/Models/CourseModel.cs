
namespace School.Service.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
    }
}
