using EzePOS.Business.IServices;
using EzePOS.Business.Services;
using EzePOS.Cashier.WindowUI.Windows;
using EzePOS.Infrastructure.Data;
using EzePOS.Infrastructure.IRepositories;
using EzePOS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EzePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public string lang = "ru";

        public static IServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
            //_host = new HostBuilder().Build();
            ServiceProvider = _host.Services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {

            string DbPath;
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "EzePos.db");

            services.AddSingleton<Layout>();

            services.AddDbContext<EzeposContext>(options =>
            {
                options.UseSqlite($"Data Source={DbPath}");
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IShopItemService, ShopItemService>();




            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await _host.StartAsync();

            try
            {
                var dbContext = ServiceProvider.GetRequiredService<EzeposContext>();
                dbContext.Database.Migrate();
            }
            catch
            {

            }

            var mainWindow = ServiceProvider.GetRequiredService<Layout>();
            //mainWindow.WindowStyle = WindowStyle.None;
            //mainWindow.WindowState = WindowState.Maximized;
            mainWindow.Show();


            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
