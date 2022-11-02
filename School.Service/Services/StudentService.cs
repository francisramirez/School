using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using School.DAL.Interfaces;
using School.Service.Contracts;
using School.Service.Core;
using School.Service.Dtos;
using School.Service.Responses;

namespace School.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<StudentService> logger;
        public StudentService(IStudentRepository studentRepository, 
                              ILogger<StudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
        }

        public ServiceResult Gets()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var students = studentRepository.GetEntities();

                result.Data = students.Select(st => new Models.StudentModel()
                {
                    Id = st.Id,
                    EnrollmentDate = st.EnrollmentDate.Value,
                    EnrollmentDateDisplay = st.EnrollmentDate.Value.ToString("dd/mm/yyyy"),
                    FirstName = st.FirstName,
                    LastName = st.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los estudiantes";
                this.logger.LogError($" { result.Message } {ex.Message}", ex.ToString());
            }

            return result;
        }
        
        public ServiceResult GetStudentsGrades()
        {
            throw new System.NotImplementedException();
        }
        public ServiceResult RemoveStudent(StudentRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Student studentToRemove = studentRepository.GetEntity(removeDto.Id); // Se busca el estudiante a eliminar //

                studentToRemove.Id = removeDto.Id;
                studentToRemove.UserDeleted = removeDto.UserDeleted;
                studentToRemove.Deleted = true;
                studentToRemove.DeletedDate = DateTime.Now;

                studentRepository.Remove(studentToRemove);

                result.Message = "Estudiante eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                this.logger.LogError($" { result.Message } {ex.Message}", ex.ToString());
            }

            return result;
        }
        public StudentSaveResponse SaveStudent(StudentSaveDto studentSaveDto)
        {
            StudentSaveResponse result = new StudentSaveResponse();

            try
            {
                // Validar los campos requeridos y logitudes //

                var resutlIsValid = IsValidStudent(studentSaveDto);

                if (resutlIsValid.Success)
                {
                    // Verificar si el estudiante esta inscripto //
                    if (studentRepository.Exists(st => st.FirstName == studentSaveDto.FirstName
                                                    && st.LastName == studentSaveDto.LastName
                                                    && st.EnrollmentDate.Value.Date == studentSaveDto.EnrollmentDate.Value.Date
                                                    ))
                    {
                        result.Success = false;
                        result.Message = "Este estudiante ya se encuentra registrado.";
                        return result;
                    }

                    DAL.Entities.Student studentToAdd = new DAL.Entities.Student()
                    {
                        LastName = studentSaveDto.LastName,
                        EnrollmentDate = studentSaveDto.EnrollmentDate,
                        FirstName = studentSaveDto.FirstName,
                        CreationDate = DateTime.Now,
                        CreationUser = studentSaveDto.UserId
                    };

                    studentRepository.Save(studentToAdd);

                    result.Matricula = studentToAdd.Id.ToString();

                    result.Message = "Estudiante agregado correctamente";
                }
                else 
                {
                    result.Success = resutlIsValid.Success;
                    result.Message = resutlIsValid.Message;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                this.logger.LogError($" { result.Message } {ex.Message}", ex.ToString());
            }
            return result;
        }
        public StudentUpdateResponse UpdateStudent(StudentUpdateDto studentSaveDto)
        {
            StudentUpdateResponse result = new StudentUpdateResponse();

            try
            {
                // Validar los campos requeridos y logitudes //

                var resultIsValid = IsValidStudent(studentSaveDto);

                if (resultIsValid.Success)
                {
                    DAL.Entities.Student studentToUpdate = studentRepository.GetEntity(studentSaveDto.Id); // Se busca el estudiante a actualizar //

                    studentToUpdate.FirstName = studentSaveDto.FirstName;
                    studentToUpdate.LastName = studentSaveDto.LastName;
                    studentToUpdate.EnrollmentDate = studentSaveDto.EnrollmentDate;
                    studentToUpdate.ModifyDate = DateTime.Now;
                    studentToUpdate.UserMod = studentSaveDto.UserId;
                    studentToUpdate.Id = studentSaveDto.Id;

                    studentRepository.Update(studentToUpdate);

                    result.Message = "Estudiante actualizado correctamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = resultIsValid.Message;
                }
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el estudiante";
                this.logger.LogError($" { result.Message } {ex.Message}", ex.ToString());
            }

            return result;

        }
        private ServiceResult IsValidStudent(DtoStudentBase dtoStudent) 
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(dtoStudent.FirstName))
            {
                result.Success = false;
                result.Message = "El nombre del estudiante es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(dtoStudent.LastName))
            {
                result.Success = false;
                result.Message = "El apellido del estudiante es requerido.";
                return result;
            }

            if (!dtoStudent.EnrollmentDate.HasValue)
            {
                result.Success = false;
                result.Message = "La fecha de inscripción es requerida.";
                return result;
            }

            if (dtoStudent.FirstName.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida.";
                return result;
            }

            if (dtoStudent.LastName.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del apellido es inválida.";
                return result;
            }

            return result;
        }
    }
}
