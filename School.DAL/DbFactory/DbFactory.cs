
using Microsoft.EntityFrameworkCore;
using School.DAL.Context;
using School.DAL.Core;
using System;

namespace School.DAL.DbFactory
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private readonly DbContext context;
        private bool isDisposed;
        public DbFactory(SchoolContext context) => this.context = context;
        public DbContext GetDbContext => this.context;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }

            isDisposed = true;

        }
    }
}
