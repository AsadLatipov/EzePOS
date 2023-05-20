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
    public interface IUserService
    {
        Task<BaseResponse<User>> UpdateAsync(User user);
        Task<BaseResponse<User>> CreateAsync(User user);
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null);
    }
}
