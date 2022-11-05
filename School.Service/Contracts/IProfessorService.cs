
using School.Service.Core;
using School.Service.Dtos;

namespace School.Service.Contracts
{
    public interface IProfessorService : IBaseService
    {
        ServiceResult SaveProfessor(SaveProfessorDto saveProfessor);
    }
}
