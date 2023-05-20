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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EzeposContext dbcontext) : base(dbcontext)
        {
        }
    }
}
