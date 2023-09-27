using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Core.DAL.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        Task CommitAsync();
        void Commit();
    }
}
