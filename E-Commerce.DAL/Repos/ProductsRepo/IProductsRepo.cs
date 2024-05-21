using E_Commerce.DAL;
using E_Commerce.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repos.ProductsRepo;

public interface IProductsRepo :IGenericRepo<Product>
{
    Product? GetById(int id);
    IEnumerable<Product>? GetByName(string Name);
    IEnumerable<Product>? GetByCategory(int IdCat);
}
