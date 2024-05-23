using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.Order;

public class GetOrderHistoryDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }
}
