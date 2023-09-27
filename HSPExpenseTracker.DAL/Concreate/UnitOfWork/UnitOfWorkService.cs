using HSPExpenseTracker.Core.DAL.UnitOfWork;
using HSPExpenseTracker.DAL.Concreate.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Concreate.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWorkService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
