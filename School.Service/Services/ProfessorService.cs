using Microsoft.Extensions.Logging;
using School.Service.Contracts;
using School.Service.Core;
using School.Service.Dtos;

namespace School.Service.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly ILogService<ProfessorService> logService;

        public ProfessorService(ILogService<ProfessorService> logService)
        {
            this.logService = logService;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {

            }
            catch (System.Exception ex)
            {
                this.logService.LogError(ex.Message);
                throw;
            }
            return result;
        }
        public ServiceResult GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveProfessor(SaveProfessorDto saveProfessor)
        {
            ServiceResult result = new ServiceResult();

            result = Validations.ValidationsPerson.IsValidPerson(saveProfessor);
            
            if (result.Success)
            {
                // Save Professor //
            }
            return result;
        }
    }
}
