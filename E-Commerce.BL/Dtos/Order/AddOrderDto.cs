﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.Order;

public class AddOrderDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
