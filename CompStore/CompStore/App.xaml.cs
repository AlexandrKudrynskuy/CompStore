using Bll.Service;
using Dll.Context;
using Dll.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CompStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider provider;
        public App()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            provider = service.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection service)
        {
            service.AddDbContext<CompStoreContext>(option => { option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompStore;Integrated Security=True;");});
           
            service.AddTransient<ProductService>();
            service.AddTransient<ProductRepository>();
            
            service.AddTransient<BrandService>();
            service.AddTransient<BrandRepository>();
            
            service.AddTransient<CustomersService>();
            service.AddTransient<CustomerRepository>();


            service.AddTransient<OrderService>();
            service.AddTransient<OrderRepository>();


            service.AddTransient<CategoryService>();
            service.AddTransient<CategoryRepository>();

            service.AddTransient<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = provider.GetService<MainWindow>();

        }
    }
}
