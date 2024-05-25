using E_Commerce.DAL.DBContext;
using E_Commerce.DAL.Repos.CartRepo;
using E_Commerce.DAL.Repos.OrdersRepo;
using E_Commerce.DAL.Repos.ProductsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly EContext _Context;
    public UnitOfWork(EContext DbContext, IProductsRepo productsRepos, ICartsRepo cartsRepo, IOrdersRepo ordersRepo)
    {
        _Context = DbContext;
        productRepositary = productsRepos;
        cartRepository = cartsRepo;
        orderRepositary = ordersRepo;
    }
    public IProductsRepo productRepositary { get; }
    public ICartsRepo cartRepository { get; }
    public IOrdersRepo orderRepositary { get; }

    public void SaveChanges()
    {
    }
}
