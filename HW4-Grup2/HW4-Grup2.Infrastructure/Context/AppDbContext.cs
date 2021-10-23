using HW4_Grup2.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HW4_Grup2.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<Role> Roles{ get; set; }
        //public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasNoKey().HasData(
        //             new User() { Name = "Ali", LastName = "Birinci" },
        //             new User() { Name = "İlker", LastName = "Baltacı" },
        //             new User() { Name = "Mustafa", LastName = "Kocatepe" },
        //             new User() { Name = "Mehmet Emin", LastName = "Aykan" });

        //    modelBuilder.Entity<Order>().HasData(
        //          new Order() { Id = 1, TotalPrice = 1500, Address = "ankara", UserId = "Ali1", CreatedAt = DateTime.Now, OrderNumber = 1 },
        //          new Order() { Id = 2, TotalPrice = 2000, Address = "istanbul", UserId = "Ali1", CreatedAt = DateTime.Now, OrderNumber = 2 },
        //          new Order() { Id = 3, TotalPrice = 2500, Address = "izmir", UserId = "Ilker1", CreatedAt = DateTime.Now, OrderNumber = 3 },
        //          new Order() { Id = 4, TotalPrice = 3000, Address = "adana", UserId = "Mustafa1", CreatedAt = DateTime.Now, OrderNumber = 4 });

        //    modelBuilder.Entity<Product>().HasData(
        //        new Product() { Id = 1, Name = "Apple iPad", Price = 1000 },
        //        new Product() { Id = 2, Name = "Samsung Smart TV", Price = 1500 },
        //        new Product() { Id = 3, Name = "Nokia 3310", Price = 500 },
        //        new Product() { Id = 4, Name = "Dell Mouse", Price = 250 },
        //        new Product() { Id = 5, Name = "Samsung Monitor", Price = 1000 });



        //    modelBuilder.Entity<OrderItem>().HasData(
        //          new OrderItem() { Id = 1, ItemPrice = 1000, OrderId = 1, ProductId = 1, Quantity = 1 },
        //          new OrderItem() { Id = 2, ItemPrice = 500, OrderId = 1, ProductId = 3, Quantity = 1 },

        //          new OrderItem() { Id = 3, ItemPrice = 1000, OrderId = 2, ProductId = 1, Quantity = 2 },

        //          new OrderItem() { Id = 4, ItemPrice = 1500, OrderId = 3, ProductId = 2, Quantity = 1 },
        //          new OrderItem() { Id = 5, ItemPrice = 1000, OrderId = 3, ProductId = 5, Quantity = 1 },

        //          new OrderItem() { Id = 6, ItemPrice = 1000, OrderId = 4, ProductId = 3, Quantity = 6 });

        //}

    }
}
