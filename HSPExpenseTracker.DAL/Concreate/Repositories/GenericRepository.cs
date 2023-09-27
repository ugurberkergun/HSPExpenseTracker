using HSPExpenseTracker.Core.DAL;
using HSPExpenseTracker.Core.Entities;
using HSPExpenseTracker.DAL.Concreate.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Concreate.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity, new()
    {
        public readonly DbSet<T> _dbSet;
        public readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            query = filter is not null ? query = query.Where(filter) : query;

            return query.AsNoTracking().FirstOrDefault();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.AsNoTracking().AsQueryable() : _dbSet.Where(filter).AsQueryable();
        }

        public async Task Save(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }
    }
}
