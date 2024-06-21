﻿using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.Entities.Context
{
    public class KotonDbContext : DbContext
    {
        protected KotonDbContext()
        {
        }
        public KotonDbContext(DbContextOptions<KotonDbContext> options) : base(options)
        {            
        }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CustomerRole>  CustomerRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRole>().
                HasKey(x => new { x.RoleId,x.CustomerId});
            modelBuilder.Entity<CustomerRole>().
                HasOne(x => x.Role).
                WithMany(y => y.CustomerRoles);
            modelBuilder.Entity<CustomerRole>().
                HasOne(x => x.Customer).
                WithMany(y => y.CustomerRoles);

            base.OnModelCreating(modelBuilder);

 
        }


    }
}
