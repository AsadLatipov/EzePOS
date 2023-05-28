using EzePOS.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.IRepositories
{
    public interface IClientRepository
    {
        Task<Client> CreateAsync(Client entity);
        Task<Client> GetAsync(Expression<Func<Client, bool>> expression, List<string> include = null);
        Task<IQueryable<Client>> GetAllAsync(Expression<Func<Client, bool>> expression = null);
        Task<Client> UpdateAsync(Client entity);
        Task<bool> DeleteAsync(Expression<Func<Client, bool>> expression);
    }
}
