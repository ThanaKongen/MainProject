using Infrastructure.Data;
using System;
using Domain.Models;
using System.Threading.Tasks;
using Application.Command;

namespace Infrastructure
{
    //public class CustomerRepository<TEntity> : ICustomerRepository<TEntity> where TEntity : class, new()
    //{
    //    protected readonly CostomerDbContext DbContext;

    //    public CustomerRepository(CostomerDbContext dbContext)
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
    //        if (Entity==null)
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

    //    //public Task<Customer> GetEntityById (int Id)
    //    //{
    //    //    return GetAll().FirstOrDefaultAsync(x => x.Id == Id);
    //    //}
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

        //Business Customer
        public async Task AddBusinessCustomer(BusinessCustomer Entity)
            => await DbContext.BusinessCustomer.AddAsync(Entity);

        public async Task<bool> BusinessCustomerExistsAsync(int Id)
            => await DbContext.BusinessCustomer.FindAsync(Id) != null;

        public async Task<BusinessCustomer> LoadBusinessCustomerAsync(int Id)
            => await DbContext.BusinessCustomer.FindAsync(Id);

        //Customer
        //Might change this later 
        public async Task CustomerExistAsync(Customer Entity)
            => await DbContext.Customer.FindAsync(Entity);

        public async Task<Customer> LoadCustomerAsync(int Id)
            => await DbContext.Customer.FindAsync(Id);

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
