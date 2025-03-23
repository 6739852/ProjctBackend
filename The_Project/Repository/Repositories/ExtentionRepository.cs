using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Intefaces;

namespace Repository.Repositories
{
    public static class ExtentionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IRepository<PurchasingGroup>, PurchasingGroupRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            return services;
        }

    }
}
