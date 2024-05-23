using E_Commerce.BL.Dtos.Product;
using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Manager.Product;

public class ProductManeger : IProductManager

{
    private readonly IUnitOfWork _unitOfWork;
    public ProductManeger(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<GetProductDto> GetAll()
    {
        var products = _unitOfWork.productRepositary.GetAll();
        if (products is null) return null;
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Description = p.Description,
            Name = p.Name,
            Price = p.Price
        });
    }

    public IEnumerable<GetProductDto>? GetByCategory(int IdCat)
    {
        var products = _unitOfWork.productRepositary.GetByCategory(IdCat);
        if (products is null) return null;
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Description = p.Description,
            Name = p.Name,
            Price = p.Price,
        });
    }

    public IEnumerable<GetProductDto>? GetByName(string Name)
    {
        var products = _unitOfWork.productRepositary.GetByName(Name);
        if (products is null) return null;
        return products.Select(p => new GetProductDto
        {
            ProductId = p.ProductId,
            Description = p.Description,
            Name = p.Name,
            Price = p.Price,
        });
    }
    public GetProductDetailsDto? GetById(int id)
    {
        var product = _unitOfWork.productRepositary.GetById(id);
        if (product is null) return null;

        return new GetProductDetailsDto
        {
            ProductId = product.ProductId,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product?.Category?.CategoryName,
            Color = product.Color,

        };
    }
}
