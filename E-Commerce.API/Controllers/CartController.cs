using E_Commerce.BL.Dtos.Cart;
using E_Commerce.BL.Manager.Cart;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManeger;
        private readonly UserManager<User> _userManage;
        public CartController(ICartManager cartManeger, UserManager<User> userManage)
        {
            _cartManeger = cartManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProductToCart(AddToCartDto addToCartDto)
        {
            User? user = await _userManage.GetUserAsync(User);

            _cartManeger.AddProductToCart(addToCartDto.ProductId, addToCartDto.Quantity, user.Id);

            return Ok("product Sucsessfully Added to Cart");

        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveProductFromCart(int id)
        {
            User? user = await _userManage.GetUserAsync(User);
            _cartManeger.RemoveProductFromCart(id, user.Id);
            return Ok("product Sucsessfully Deleted from Cart");
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpadteProductQuentity(EditQuantityProCartDto editQuentityProCartDto)
        {
            User? user = await _userManage.GetUserAsync(User);

            _cartManeger.UpadteProductQuentity(editQuentityProCartDto.ProductId,
             editQuentityProCartDto.Quantity, user.Id);
            return Ok("product  Sucsessfully Updated");
        }

    }
}

