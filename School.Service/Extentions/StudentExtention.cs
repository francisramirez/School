using School.DAL.Entities;
using School.Service.Dtos;

namespace School.Service.Extentions
{
    public static class StudentExtention
    {
        public static Student ConvertFromStudentUpdateDtoToStudentEntity(this StudentUpdateDto studentUpdateDto)
        {
            return new Student()
            {
                FirstName = studentUpdateDto.FirstName,
                ModifyDate = studentUpdateDto.AuditDate,
                Id = studentUpdateDto.Id,
                LastName = studentUpdateDto.LastName,
                EnrollmentDate = studentUpdateDto.EnrollmentDate,
                UserMod = studentUpdateDto.UserId
            };
        }
    }
}
