using HSPExpenseTracker.Core.DAL;
using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Abstract
{
    public interface IAccountRepository:IGenericRepository<Account>
    {
    }
}
