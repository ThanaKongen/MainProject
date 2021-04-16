using Infrastructure.Data;
using System;
using Domain.Models;
using System.Threading.Tasks;
using Application.Command;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    //public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    //{
    //    protected readonly CostomerDbContext DbContext;

    //    public Repository(CostomerDbContext dbContext)
    //    {
    //        DbContext = dbContext;
    //    }

    //    public IQueryable<TEntity> GetAll()
    //    {
    //        try
    //        {
    //            return DbContext.Set<TEntity>();
    //        }
    //        catch (Exception ex)
    //        {

    //            throw new Exception($"Couldn't retrieve entities: {ex.Message}");
    //        }
    //    }

    //    public async Task<TEntity> AddAsync(TEntity Entity)
    //    {
    //        if (Entity == null)
    //        {
    //            throw new ArgumentException($"{nameof(AddAsync)} entity must not be null");
    //        }

    //        try
    //        {
    //            await DbContext.AddAsync(Entity);
    //            await DbContext.SaveChangesAsync();

    //            return Entity;
    //        }
    //        catch (Exception ex)
    //        {

    //            throw new Exception($"{nameof(Entity)} could not be saved: {ex.Message}");
    //        }
    //    }

    //    public async Task<TEntity> UpdateAsync(TEntity Entity)
    //    {
    //        if (Entity == null)
    //        {
    //            throw new ArgumentException($"{nameof(UpdateAsync)} entity must not be null");
    //        }

    //        try
    //        {
    //            DbContext.Update(Entity);
    //            await DbContext.SaveChangesAsync();

    //            return Entity;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception($"{nameof(Entity)} could not be saved: {ex.Message}");
    //        }
    //    }
    //}
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

        //Customer
        //Might change this later 
        public async Task<bool> CustomerExistsAsync(int Id)
            => await DbContext.Customer.FindAsync(Id) != null;

        public async Task<Customer> LoadCustomerAsync(int Id)
            => await DbContext.Customer.FindAsync(Id);

        public async Task DeleteCustomer(int Id)
        {
            var Customer = await DbContext.Customer.FindAsync(Id);
            DbContext.Customer.Remove(Customer);
        }

        //Address
        public async Task AddAddress(Address Entity)
            => await DbContext.Address.AddAsync(Entity);

        public async Task<bool> AddressExistsAsync(int Id)
            => await DbContext.Address.FindAsync(Id) != null;

        public async Task<Address> LoadAddressAsync(int Id)
            => await DbContext.Address.FindAsync(Id);

        //
    }
}
