using EzePOS.Business.Models;
using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.IServices
{
    public interface IShopService
    {
        Task<BaseResponse<Shop>> UpdateAsync(Shop category, User user);
        Task<BaseResponse<Shop>> CreateAsync(Shop category, User user);
        Task<BaseResponse<Shop>> GetAsync(Expression<Func<Shop, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Shop, bool>> expression);
        Task<BaseResponse<IEnumerable<Shop>>> GetAllAsync(Expression<Func<Shop, bool>> expression = null);
    }
}
