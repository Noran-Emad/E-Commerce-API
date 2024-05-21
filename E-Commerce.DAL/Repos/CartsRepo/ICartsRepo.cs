using E_Commerce.DAL;
using E_Commerce.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repos.CartRepo;

public interface ICartsRepo :IGenericRepo<Cart>
{
    void AddProductToCart(int productId, int Quentity, string UserId);
    void RemoveProductFromCart(int productId, string UserId);
    void UpadteProductQuentity(int productId, int Quentity, string UserId);
}
