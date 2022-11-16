
namespace School.DAL.Core
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
    }
}
