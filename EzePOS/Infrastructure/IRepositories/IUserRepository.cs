using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);
        Task<User> GetAsync(Expression<Func<User, bool>> expression, List<string> include = null);
        Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
