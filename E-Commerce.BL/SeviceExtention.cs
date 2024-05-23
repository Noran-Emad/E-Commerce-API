using E_Commerce.BL.Manager.Cart;
using E_Commerce.BL.Manager.Order;
using E_Commerce.BL.Manager.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public static class SeviceExtention
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderManager, OrderManeger>();
        services.AddScoped<IProductManager, ProductManeger>();
        services.AddScoped<ICartManager, CartManeger>();

    }
}
