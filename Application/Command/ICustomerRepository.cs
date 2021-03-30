using Domain.Models;
using System.Threading.Tasks;

namespace Application.Command
{
    public interface ICustomerRepository /*<TEntity> where TEntity : class, new()*/
    {
        Task AddAddress(Address Entity);
        Task AddBusinessCustomer(BusinessCustomer Entity);
        Task AddPrivateCustomerAsync(PrivateCustomer Entity);
        Task<bool> AddressExistsAsync(int Id);
        Task<bool> BusinessCustomerExistsAsync(int Id);
        Task CustomerExistAsync(Customer Entity);
        void Dispose();
        Task<Address> LoadAddressAsync(int Id);
        Task<BusinessCustomer> LoadBusinessCustomerAsync(int Id);
        Task<Customer> LoadCustomerAsync(int Id);
        Task<PrivateCustomer> LoadPrivateCustomerAsync(int Id);
        Task<bool> PrivateCustomerExistsAsync(int Id);
    }
}