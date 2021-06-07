using DanBase.Shared.CustomerModels.Command;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Danbase.WebClient.Services
{
    public interface IBusinessCustomerService
    {
        Task Create(BusinessCustomerCommandDto.AddCustomer CustomerDto);

        Task<List<Models.BusinessCustomer.BusinessCustomerDetails>> GetAll();

        Task<Models.BusinessCustomer.BusinessCustomerDetails> GetById(int Id);

        Task Update(Models.BusinessCustomer.BusinessCustomerDetails CustomerDto);

        Task Delete(int Id);
    }
}