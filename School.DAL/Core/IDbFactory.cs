
using Microsoft.EntityFrameworkCore;
using School.DAL.Context;

namespace School.DAL.Core
{
    public interface IDbFactory
    {
        DbContext GetDbContext { get; }
    }
}
