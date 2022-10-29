using School.DAL.Entities;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace School.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public bool Exists(Expression<Func<Departament, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departament> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Departament GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Remove(Departament entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Departament entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Departament entity)
        {
            throw new NotImplementedException();
        }
    }
}
