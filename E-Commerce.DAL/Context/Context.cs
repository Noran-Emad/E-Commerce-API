using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.DBContext
{
    public class EContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
        public DbSet<CartProduct> CartProducts => Set<CartProduct>();

        public EContext(DbContextOptions<EContext> options)
         : base(options)
        {
        // This constructor forces me to enter my Connection string to use my Context in any connection string (SQl ,sql server,... to be flexable
        }         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cart>()
             .HasOne(item => item.User)
             .WithOne(cart => cart.Cart);

            builder.Entity<OrderProduct>()
            .HasOne(e => e.Product)
            .WithMany(product => product.OrderProducts)
            .HasForeignKey(item => item.ProductId);

            builder.Entity<Order>()
           .HasOne(item => item.User)
           .WithMany(order => order.Orders)
           .HasForeignKey(r => r.UserId);

            builder.Entity<OrderProduct>()
           .HasOne(e => e.Order)
            .WithMany(order => order.OrderItems)
            .HasForeignKey(item => item.OrderId);

            #region Seeding  products

            var products = new List<Product>
        {
          new Product {ProductId= 1,Name= "Samsung s24",Description ="latest version",Color="White",CategoryId=2,Price=33000 },
          new Product {ProductId= 2,Name= "Iphone15",Description ="latest version",Color="Gold",CategoryId=2,Price=40000},
          new Product {ProductId= 3,Name= "x-box",Description ="latest version",Color="Black",CategoryId=1,Price=50000},
          new Product {ProductId= 4,Name= "Samsung T10",Description ="latest version",Color="White",CategoryId=3,Price=35000 }
        };
            #endregion
            #region Seeding Categories
            var Categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="X-Box"},
                new Category{CategoryId=2,CategoryName="Mobiles"},
                new Category{CategoryId=3,CategoryName="Tablests"}

            };
            #endregion

            builder.Entity<Product>().HasData(products);
            builder.Entity<Category>().HasData(Categories);

        }

    }

}
