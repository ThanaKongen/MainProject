using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Models;

namespace ConsoleApp1.Data
{
    public class testingContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<PrivateCustomer> PrivateCustomer { get; set; }

        public DbSet<TestCustomer> TestCustomer { get; set; }
        
        public DbSet<Test> Tests { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=testingef;User Id=testingef;Password=Vp5D!~9h9G4x;");
        }
    }
}
