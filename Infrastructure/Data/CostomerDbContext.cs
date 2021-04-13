using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class CostomerDbContext : DbContext
    {
        private readonly ILoggerFactory Factory;

        public CostomerDbContext(DbContextOptions<CostomerDbContext> options, ILoggerFactory _Factory) : base(options)
        {
            Factory = _Factory;
        }
        //public CostomerDbContext(DbContextOptions<CostomerDbContext> options) : base(options)
        //{
        //}

        public DbSet<Company> Company { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<RelationshipType> RelationshipType { get; set; }

        public DbSet<Relationship> Relationship { get; set; }

        public DbSet<BusinessCustomer> BusinessCustomer { get; set; }

        public DbSet<PrivateCustomer> PrivateCustomer { get; set; }

        public DbSet<CompanyCustomerField> CompanyCustomerField { get; set; }

        public DbSet<CustomerField> CustomerField { get; set; }

        public DbSet<CustomerFieldValue> CustomerFieldValue { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=hovedopgave;User Id=hovedopgave;Password=Lg3sE?-EI62g;");
        }
    }
}
