using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product entity);
        Task<Product> GetAsync(Expression<Func<Product, bool>> expression, List<string> include = null);
        Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
        Task<Product> UpdateAsync(Product entity);
        Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
    }
}
