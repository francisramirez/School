using System.Collections.Generic;
using System.Linq;
using School.DAL.Context;
using School.DAL.Core;
using School.DAL.Entities;
using School.DAL.Interfaces;
namespace School.DAL.Repositories
{
    public class DepartmentRepository : RepositoryBase<Departament>, IDepartmentRepository
    {
        private readonly SchoolContext context;
        public DepartmentRepository(SchoolContext context) : base(new DbFactory.DbFactory(context)) => this.context = context;
        public override IEnumerable<Departament> GetEntities() => context.Departaments.Where(dep => !dep.Deleted);
    }
}
