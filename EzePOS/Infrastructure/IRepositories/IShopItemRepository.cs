using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface IShopItemRepository
    {
        Task<ShopItem> CreateAsync(ShopItem entity);
        Task<ShopItem> GetAsync(Expression<Func<ShopItem, bool>> expression, List<string> include = null);
        Task<IQueryable<ShopItem>> GetAllAsync(Expression<Func<ShopItem, bool>> expression = null);
        Task<ShopItem> UpdateAsync(ShopItem entity);
        Task<bool> DeleteAsync(Expression<Func<ShopItem, bool>> expression);
    }
}
