using DanBase.Shared.CustomerModels.Command;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Danbase.WebClient.Services
{
    public interface IPrivateCustomerService
    {
        Task Create(PrivateCustomerCommandDto.AddCustomer CustomerDto);

        Task<List<Models.PrivateCustomer.PrivateCustomerDetails>> GetAll();

        Task<Models.PrivateCustomer.PrivateCustomerDetails> GetById(int Id);

    }
}