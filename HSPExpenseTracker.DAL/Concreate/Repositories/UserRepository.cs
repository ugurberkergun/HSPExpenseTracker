using HSPExpenseTracker.DAL.Abstract;
using HSPExpenseTracker.DAL.Concreate.DbContexts;
using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Concreate.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }
    }
}
