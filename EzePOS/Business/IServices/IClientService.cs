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
    
    public interface IClientService
    {
        Task<BaseResponse<Client>> UpdateAsync(Client category, User user);
        Task<BaseResponse<Client>> CreateAsync(Client category, User user);
        Task<BaseResponse<Client>> GetAsync(Expression<Func<Client, bool>> expression);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Client, bool>> expression);
        Task<BaseResponse<IEnumerable<Client>>> GetAllAsync(Expression<Func<Client, bool>> expression = null);
    }
}
