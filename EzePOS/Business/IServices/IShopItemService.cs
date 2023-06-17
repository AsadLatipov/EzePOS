using EzePOS.Business.Models;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.IServices
{
    public interface IShopItemService
    {
        Task<BaseResponse<ShopItem>> UpdateAsync(ShopItem category, User user);
        Task<BaseResponse<ShopItem>> CreateAsync(ShopItem category, User user);
        Task<BaseResponse<ShopItem>> GetAsync(Expression<Func<ShopItem, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ShopItem, bool>> expression);
        Task<BaseResponse<IEnumerable<ShopItem>>> GetAllAsync(Expression<Func<ShopItem, bool>> expression = null);
    }
}
