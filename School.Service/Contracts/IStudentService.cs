using School.Service.Core;
using School.Service.Dtos;
using School.Service.Responses;

namespace School.Service.Contracts
{
    public interface IStudentService 
    {
        StudentResponse SaveStudent(StudentSaveDto studentSaveDto);
        StudentResponse UpdateStudent(StudentUpdateDto studentSaveDto);
        ServiceResult RemoveStudent(StudentRemoveDto studentSaveDto);
        ServiceResult GetStudentsGrades();
        ServiceResult GetStudents();
    }

}
