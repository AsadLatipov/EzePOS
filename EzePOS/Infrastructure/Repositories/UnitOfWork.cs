using EzePOS.Infrastructure.Data;
using EzePOS.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EzeposContext context;
        public UnitOfWork(EzeposContext context)
        {
            this.context = context;
            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);
        }
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IUserRepository Users { get; private set; }
        public IClientRepository Clients { get; private set; }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
