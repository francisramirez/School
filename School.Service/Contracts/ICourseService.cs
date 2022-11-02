using School.Service.Core;
using School.Service.Dtos;

namespace School.Service.Contracts
{
    public interface ICourseService : IBaseService
    {
        ServiceResult SaveCourse(SaveCourseDto saveCourseDto);
        ServiceResult UpdateCourse(UpdateCourse studentSaveDto);
        ServiceResult GetCoursesByDeparments();
    }
}
