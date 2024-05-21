using E_Commerce.DAL;
using E_Commerce.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Repos.OrdersRepo;

public interface IOrdersRepo : IGenericRepo<Order>
{
    void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId);
    IEnumerable<Order> GetAllOrder(string UserId);
}
