using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Intefaces;
using Repository.Entities;
using Service.Interface;
using Common.Dto;


namespace Service.Services
{
    public static class ExtentionService
    {
        public static  IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<IService<Supplier>, SupplierService>();
            services.AddScoped<IService<PurchasingGroupDto>, PurchasingGroupService>();
            services.AddScoped<IService<WantToOpen>, WantToOpenService>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IAlgorithem, Algorithem>();
            services.AddAutoMapper(typeof(MyMapper));
            return services;
        }
    }
}
