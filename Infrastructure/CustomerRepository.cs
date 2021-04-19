using Infrastructure.Data;
using System;
using Domain.Models;
using System.Threading.Tasks;
using Application.Command;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly CostomerDbContext DbContext;

        public CustomerRepository(CostomerDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public void Dispose() => DbContext.Dispose();

        //Private Customer
        public async Task AddPrivateCustomerAsync(PrivateCustomer Entity)
            => await DbContext.PrivateCustomer.AddAsync(Entity);

        public async Task<bool> PrivateCustomerExistsAsync(int Id)
            => await DbContext.PrivateCustomer.FindAsync(Id) != null;

        public async Task<PrivateCustomer> LoadPrivateCustomerAsync(int Id)
            => await DbContext.PrivateCustomer.FindAsync(Id);

        public async Task DeletePrivateCustomer(int Id)
        {
            var customer = await DbContext.PrivateCustomer.FindAsync(Id);
            DbContext.PrivateCustomer.Remove(customer);
        }

        //Business Customer
        public async Task AddBusinessCustomer(BusinessCustomer Entity)
            => await DbContext.BusinessCustomer.AddAsync(Entity);

        public async Task<bool> BusinessCustomerExistsAsync(int Id)
            => await DbContext.BusinessCustomer.FindAsync(Id) != null;

        public async Task<BusinessCustomer> LoadBusinessCustomerAsync(int Id)
            => await DbContext.BusinessCustomer.FindAsync(Id);
        
        public async Task DeleteBusinessCustomer(int Id)
        {
            var customer = await DbContext.BusinessCustomer.FindAsync(Id);
            DbContext.BusinessCustomer.Remove(customer);
        }

        //Address
        public async Task AddAddress(Address Entity)
            => await DbContext.Address.AddAsync(Entity);

        public async Task<bool> AddressExistsAsync(int Id)
            => await DbContext.Address.FindAsync(Id) != null;

        public async Task<Address> LoadAddressAsync(int Id)
            => await DbContext.Address.FindAsync(Id);

        public async Task DeleteAddress(int Id)
        {
            var address = await DbContext.Address.FindAsync(Id);
            DbContext.Address.Remove(address);
        }

        //Customer
        //Might change this later 
        //public async Task<bool> CustomerExistsAsync(int Id)
        //    => await DbContext.Customer.FindAsync(Id) != null;

        //public async Task<Customer> LoadCustomerAsync(int Id)
        //    => await DbContext.Customer.FindAsync(Id);

        //public async Task DeleteCustomer(int Id)
        //{
        //    var Customer = await DbContext.Customer.FindAsync(Id);
        //    DbContext.Customer.Remove(Customer);
        //}


        //
    }
}
