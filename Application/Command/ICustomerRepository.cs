using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Command
{
    public interface ICustomerRepository/*<TEntity> where TEntity : class, new()*/
    {
        //Address
        Task AddAddress(Address Entity);
        Task<bool> AddressExistsAsync(int Id);
        Task<Address> LoadAddressAsync(int Id);
        Task DeleteAddress(int Id);

        //Business Customer
        Task AddBusinessCustomer(BusinessCustomer Entity);
        Task<bool> BusinessCustomerExistsAsync(int Id);
        Task<BusinessCustomer> LoadBusinessCustomerAsync(int Id);
        Task DeleteBusinessCustomer(int Id);

        //Private Customer
        Task AddPrivateCustomerAsync(PrivateCustomer Entity);
        Task<PrivateCustomer> LoadPrivateCustomerAsync(int Id);
        Task<bool> PrivateCustomerExistsAsync(int Id);
        Task DeletePrivateCustomer(int Id);


        //Customer
        //Task<Customer> LoadCustomerAsync(int Id);
        //Task<bool> CustomerExistsAsync(int Id);
    }
}