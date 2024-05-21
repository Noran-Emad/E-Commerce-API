using E_Commerce.DAL.Repos.CartRepo;
using E_Commerce.DAL.Repos.OrdersRepo;
using E_Commerce.DAL.Repos.ProductsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public interface IUnitOfWork
{
    public IProductsRepo productRepositary { get; }
    public ICartsRepo cartRepository { get; }
    public IOrdersRepo orderRepositary { get; }

    void SaveChanges();
}
