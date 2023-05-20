using EzePOS.Infrastructure.Data;
using EzePOS.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EzeposContext _dbContext;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(EzeposContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbset.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbset.Update(entity);
            return entry.Entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> include = null)
        {
            IQueryable<T> query = _dbset;

            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            var entity = await query.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbset.FirstOrDefaultAsync(expression);

            if (entity is null) return false;

            _dbset.Remove(entity);
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? _dbset : _dbset.Where(expression);

        }

    }
}
