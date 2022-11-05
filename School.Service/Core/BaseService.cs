namespace School.Service.Core
{
    public interface IBaseService
    {
        ServiceResult Gets();
        ServiceResult GetById(int Id);
       
    }
}
