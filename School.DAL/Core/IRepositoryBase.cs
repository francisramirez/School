using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace School.DAL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity  entity);
        void Save(TEntity[] entities);
        void Update(TEntity  entity);
        void Remove(TEntity  entity);
        TEntity GetEntity(int entityid );
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities();
        void ExecuteProcedure(string procedureCommand,params SqlParameter[] sqlParams);
    }
}
