﻿using E_Commerce.BL.Dtos.Product;
using E_Commerce.BL.Manager.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _maneger;
        public ProductsController(IProductManager maneger)
        {
            _maneger = maneger;
        }
        [HttpGet]

        public ActionResult<IEnumerable<GetProductDto>> GetAll()
        {
            var product = _maneger.GetAll();
            return product.ToList();
        }

        /////////////////////////////////
        [HttpGet]
        [Route("{id}")]
        public ActionResult<GetProductDetailsDto> GetById(int id)
        {
            var ProductDetails = _maneger.GetById(id);
            if (ProductDetails is null)
            {
                return NotFound();
            }
            return ProductDetails;
        }

        ///////////////////////////////////
        [HttpGet]
        [Route("Category/{id}")]
        public ActionResult<IEnumerable<GetProductDto>> GetByCatId(int id)
        {
            var Products = _maneger.GetByCategory(id);
            if (Products is null)
            {
                return NotFound();
            }
            return Products.ToList();
        }
        ////////////////////////
        [HttpGet]
        [Route("{Name:alpha}")]
        public ActionResult<IEnumerable<GetProductDto>> GetByName(string Name)
        {
            var Products = _maneger.GetByName(Name);
            if (Products is null)
            {
                return NotFound();
            }
            return Products.ToList();
        }
    }
}
    

