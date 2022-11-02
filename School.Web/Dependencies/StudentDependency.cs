using Microsoft.Extensions.DependencyInjection;
using School.DAL.Interfaces;
using School.DAL.Repositories;
using School.Service.Contracts;
using School.Service.Services;

namespace School.Web.Dependencies
{
    public static class StudentDependency
    {
        /// <summary>
        /// Dependencias del módulo estudiantes //
        /// </summary>
        /// <param name="services">Servicio donde se registra las dependencias</param>
        public static void AddStudentDependency(this IServiceCollection services) 
        {
            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Services(BL)//
            services.AddTransient<IStudentService, StudentService>();

        }
    }
}
