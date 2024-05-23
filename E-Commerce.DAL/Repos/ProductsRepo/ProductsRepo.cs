using E_Commerce.DAL.DBContext;
using E_Commerce.DAL;
using E_Commerce.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DAL.Repos.ProductsRepo;

namespace E_Commerce.DAL.Repos.ProductsRepo;

public class ProductsRepo : GenericRepo<Product>, IProductsRepo
{
    private readonly EContext _Context;
    public ProductsRepo(EContext context) : base(context)
    {
        _Context = context;
    }
    public IEnumerable<Product>? GetByCategory(int IdCat)
    {
        return _Context.Set<Product>().Where(x => x.CategoryId == IdCat);
    }

    public Product? GetById(int id)
    {
        return _Context.Set<Product>().Include(e => e.Category).FirstOrDefault(x => x.CategoryId == id);
    }

    public IEnumerable<Product>? GetByName(string Name)
    {
        return _Context.Set<Product>().Where(x => x.Name == Name);
    }
}
