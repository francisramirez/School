using School.Service.Core;
using School.Service.Dtos;
using School.Service.Responses;

namespace School.Service.Contracts
{
    public interface IStudentService : IBaseService
    {
        StudentSaveResponse SaveStudent(StudentSaveDto studentSaveDto);
        StudentUpdateResponse UpdateStudent(StudentUpdateDto studentSaveDto);
        ServiceResult RemoveStudent(StudentRemoveDto studentSaveDto);
        ServiceResult GetStudentsGrades();
    }

}
