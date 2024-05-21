using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class User : IdentityUser
{
    public Cart? Cart { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
