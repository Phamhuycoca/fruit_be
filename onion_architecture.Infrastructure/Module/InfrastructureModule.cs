using Microsoft.Extensions.DependencyInjection;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Infrastructure.Module
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFruitRepository, FruitRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IRefresh_TokenRepository, Refresh_TokenRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBill_DetailRepository, Bill_DetailRepository>();
            return services;
        }
    }
}
