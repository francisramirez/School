using School.Service.Contracts;
using School.Service.Core;
using School.Service.Dtos;

namespace School.Service.Services
{
    public class ProfessorService : IProfessorService
    {
        public ProfessorService()
        {

        }
        public ServiceResult GetAll()
        {
            throw new System.NotImplementedException();
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
