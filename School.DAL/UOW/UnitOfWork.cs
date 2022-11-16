

using School.DAL.Core;

namespace School.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        public UnitOfWork(IDbFactory dbFactory) => this.dbFactory = dbFactory;
        public void BeginTransaction() => this.dbFactory.GetDbContext.Database.BeginTransaction();
        public void CommitTransaction() => this.dbFactory.GetDbContext.Database.CommitTransaction();
        public void RollbackTransaction() => this.dbFactory.GetDbContext.Database.RollbackTransaction();
        public void SaveChanges() => this.dbFactory.GetDbContext.SaveChanges();
    }
}
