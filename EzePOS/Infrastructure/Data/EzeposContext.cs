using EzePOS.Infrastructure.Entities;
using EzePOS.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EzePOS.Infrastructure.Data
{
    public class EzeposContext : DbContext
    {
        private string DbPath;
        public EzeposContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "EzePos.db");
        }
        public EzeposContext(DbContextOptions<EzeposContext> options)
        : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseSqlite($"Data Source={Variables.DatabaseUrl}");

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.User();
            base.OnModelCreating(modelBuilder);
        }
    }
}
