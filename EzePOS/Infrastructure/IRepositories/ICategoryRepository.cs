using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category entity);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression, List<string> include = null);
        Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null);
        Task<Category> UpdateAsync(Category entity);
        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
    }
}
