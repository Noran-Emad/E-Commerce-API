using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class Order
{
    public int OrderId { get; set; }
    public List<OrderProduct> OrderItems { get; set; } = [];
    public DateTime OrderDate { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }
    public User? User { get; set; }
    public string? UserId { get; set; }
    public ICollection<OrderProduct> ?OrderProducts { get; set; } 

}
