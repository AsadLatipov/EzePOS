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
    public interface IProductService
    {
        Task<BaseResponse<Product>> UpdateAsync(Product product, User user);
        Task<BaseResponse<Product>> CreateAsync(Product product, User user);
        Task<BaseResponse<Product>> GetAsync(Expression<Func<Product, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Product, bool>> expression);
        Task<BaseResponse<IEnumerable<Product>>> GetAllAsync(Expression<Func<Product, bool>> expression = null);
    }
}
