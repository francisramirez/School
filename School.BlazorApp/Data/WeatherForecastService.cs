using School.Service.Contracts;
using School.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.BlazorApp.Data
{
    public class WeatherForecastService
    {
        public WeatherForecastService(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ICourseService courseService;

        public async Task<CourseList[]> GetForecastAsync(DateTime startDate)
        {
            var courseLists = ((List<CourseModel>)this.courseService.GetAll().Data).Select(co => new CourseList()
            {
                Credits = co.Credits,
                Department = co.Department,
                DepartmentId = co.DepartmentId,
                Id = co.Id,
                Name = co.Title
            }).ToArray();

            return await Task.FromResult(courseLists);

        }
    }
}
