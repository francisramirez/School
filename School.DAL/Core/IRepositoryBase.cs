using School.DAL.Entities;
using System.Collections.Generic;

namespace School.DAL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity student);
        void Update(TEntity student);
        void Remove(TEntity student);
        TEntity GetEntity(int studentId);
        bool Exists(int studentId);
        IEnumerable<TEntity> GetEntities();
    }
}
