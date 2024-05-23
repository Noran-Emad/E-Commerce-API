using E_Commerce.DAL.DBContext;
using E_Commerce.DAL;
using E_Commerce.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repos.OrdersRepo;

public class OrdersRepo : GenericRepo<Order>, IOrdersRepo
{
    public readonly EContext _Context;

    public OrdersRepo(EContext context) : base(context)
    {
        _Context = context;
    }

    public void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId)
    {
        var cart = _Context.Set<Cart>()
                  .FirstOrDefault(c => c.UserId == UserId);
        if (cart != null)
        {
            // Create a new order
            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = UserId,

                OrderItems = new List<OrderProduct>()
            };
            _Context.Set<Order>().Add(order);
            _Context.SaveChanges();
            // Add order items from the provided list

            decimal total = 0;
            foreach (var obj in newOrder)
            {
                var product = _Context.Set<Product>().Find(obj.ProductId);
                if (product != null)
                {
                    var orderItem = new OrderProduct
                    {
                        ProductId = obj.ProductId,
                        Quantity = obj.ProductId,
                        OrderId = order.OrderId
                    };
                    _Context.Set<OrderProduct>().Add(orderItem);
                    total += obj.Quntity * (decimal)product.Price;

                    order.TotalPrice = total;
                    // Add the order to the context and save changes

                    _Context.SaveChanges();
                    var cartItem = cart?.CartProducts?.FirstOrDefault(e => e.ProductId == obj.ProductId);
                    if (cartItem != null)
                    {
                        cart?.CartProducts?.Remove(cartItem);
                        _Context.SaveChanges();
                    }

                }
            }
            _Context.SaveChanges();
        }

    }






    public IEnumerable<Order> GetAllOrder(string userId)
    {
        return _Context.Set<Order>()
           .Where(c => c.UserId == userId);
    }
}
