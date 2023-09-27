using HSPExpenseTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Core.DAL
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task Save(T entity);
        Task<T> GetByIdAsync(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetList(Expression<Func<T, bool>> filter = null);
        void Update(T entity);
        void Delete(T entity);

    }
}
