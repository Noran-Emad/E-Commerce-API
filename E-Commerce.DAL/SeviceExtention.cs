
using E_Commerce.DAL.Repos.CartRepo;
using E_Commerce.DAL.Repos.OrdersRepo;
using E_Commerce.DAL.Repos.ProductsRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public static class SeviceExtention
{
    public static void AddDALServices(this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddScoped<ICartsRepo,CartsRepo>();

        services.AddScoped<IOrdersRepo, OrdersRepo>();

        services.AddScoped<IProductsRepo, ProductsRepo>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

