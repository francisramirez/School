

using Microsoft.Extensions.Logging;
using School.DAL.Interfaces;
using School.Service.Contracts;
using School.Service.Core;
using School.Service.Dtos;
using System;
using System.Linq;
namespace School.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRespository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<CourseService> logger;

        public CourseService(ICourseRepository courseRespository,
                              IDepartmentRepository departmentRepository,
                              ILogger<CourseService> logger)
        {
            this.courseRespository = courseRespository;
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }
        
        public ServiceResult GetCoursesByDeparments()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult Gets()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from course in this.courseRespository.GetEntities()
                             join depto in this.departmentRepository.GetEntities() on course.DepartmentID equals depto.DepartmentID
                             select new Models.CourseModel()
                             {
                                 Credits = course.Credits,
                                 Department = depto.Name,
                                 Id = course.CourseID,
                                 DepartmentId = depto.DepartmentID,
                                 Title = course.Title
                             }).ToList();



                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los cursos";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveCourse(SaveCourseDto saveCourseDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateCourse(UpdateCourse studentSaveDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
