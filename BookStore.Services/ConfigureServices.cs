using BookStore.Core.Entities;
using BookStore.Core.Entities.Models;
using BookStore.Repositories.Implementation;
using BookStore.Repositories.Interface;
using BookStore.Services.Implementation;
using BookStore.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class ConfigureServices
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<nonstopioContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            });

            
            //repository

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IRepository<Bookitem>,Repository<Bookitem>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Status>, Repository<Status>>();

            //services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStatusService, StatusService>();

        }
    }
}
