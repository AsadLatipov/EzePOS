using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface IShopRepository
    {
        Task<Shop> CreateAsync(Shop entity);
        Task<Shop> GetAsync(Expression<Func<Shop, bool>> expression, List<string> include = null);
        Task<IQueryable<Shop>> GetAllAsync(Expression<Func<Shop, bool>> expression = null);
        Task<Shop> UpdateAsync(Shop entity);
        Task<bool> DeleteAsync(Expression<Func<Shop, bool>> expression);
    }
}
