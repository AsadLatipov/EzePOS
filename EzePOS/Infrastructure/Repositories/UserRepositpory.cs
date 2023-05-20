using EzePOS.Infrastructure.Data;
using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EzeposContext dbcontext) : base(dbcontext)
        {
        }
    }
}
