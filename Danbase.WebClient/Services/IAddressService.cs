using DanBase.Shared.CustomerModels.Command;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Danbase.WebClient.Services
{
    public interface IAddressService
    {
        Task Create(AddressCommandDto.AddAddress Address);

        Task<List<Models.Address>> GetAll();

        Task Update(Models.Address address);

        Task Delete(int Id);
    }
}