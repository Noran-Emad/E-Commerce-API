﻿using Microsoft.EntityFrameworkCore;
//using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;
[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class OrderProduct
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}
