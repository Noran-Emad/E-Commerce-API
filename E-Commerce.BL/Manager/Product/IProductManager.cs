using E_Commerce.BL.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Manager.Product;

public interface IProductManager
{
    IEnumerable<GetProductDto> GetAll();
    GetProductDetailsDto? GetById(int id);
    IEnumerable<GetProductDto>? GetByName(string Name);
    IEnumerable<GetProductDto>? GetByCategory(int IdCat);
}
