using System.Collections.Generic;
using School.DAL.Core;
using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        IEnumerable<Course> GetCoursesByDeparmentId(int departmentId);
    }
}
