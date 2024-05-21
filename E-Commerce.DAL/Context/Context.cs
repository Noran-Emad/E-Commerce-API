using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.DBContext
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
        public DbSet<CartProduct> CartProducts => Set<CartProduct>();

        public Context(DbContextOptions<Context> options)
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

            #region Seeding  products

            var products = new List<Product>
        {
          new Product {ProductId= 1,Name= "headphone",Description ="good product ",Color="red",CategoryId=1,Price=3000 },
          new Product {ProductId= 2,Name= "phone",Description ="good product oppo ",Color="red",CategoryId=3,Price=40000},
          new Product {ProductId= 3,Name= "Iphone",Description ="good product apple ",Color="red",CategoryId=2,Price=90000}
        };
            #endregion
            #region Seeding Categories
            var Categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="electronic"},
                new Category{CategoryId=2,CategoryName="ios"},
                new Category{CategoryId=3,CategoryName="android"}

            };
            #endregion

            builder.Entity<Product>().HasData(products);
            builder.Entity<Category>().HasData(Categories);

        }

    }

}
