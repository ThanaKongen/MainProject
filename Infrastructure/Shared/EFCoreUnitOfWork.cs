using DanBase.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        private readonly Data.CostomerDbContext _dbContext;

        public EFCoreUnitOfWork(Data.CostomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
