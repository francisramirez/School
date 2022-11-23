using School.Service.Models;
using School.Web.Models;
using System.Collections.Generic;
using System.Linq;
namespace School.Web.Extentions
{
    public static class StudentExtentions
    {
        public static List<Student> ConvertStudentModelToModel(this List<Service.Models.StudentModel> studentModels)
        {
            var myStudents = studentModels.Select(student => new Student()
            {
                LastName = student.LastName,
                FirstName = student.FirstName,
                PersonID = student.Id,
                EnrollmentDate = student.EnrollmentDate
            }).ToList();

            return myStudents;

        }

        public static List<Student> GetStudents(List<Service.Models.StudentModel> studentModels)
        {
            var myStudents = studentModels.Select(student => new Student()
            {
                LastName = student.LastName,
                FirstName = student.FirstName,
                PersonID = student.Id,
                EnrollmentDate = student.EnrollmentDate
            }).ToList();

            return myStudents;
        }

        public static Models.Student ConvertFromStudentModelToStudent(this StudentModel studentModel)
        {
            return new Models.Student()
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                EnrollmentDate = studentModel.EnrollmentDate
            };
        }
    }
}
