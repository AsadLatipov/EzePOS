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
    public interface ICategoryService
    {
        Task<BaseResponse<Category>> UpdateAsync(Category category, User user);
        Task<BaseResponse<Category>> CreateAsync(Category category, User user);
        Task<BaseResponse<Category>> GetAsync(Expression<Func<Category, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Category, bool>> expression);
        Task<BaseResponse<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> expression = null);
    }

}
