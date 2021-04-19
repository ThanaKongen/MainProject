using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static DanBase.Shared.CustomerModels.Query.AddressReadModelsDto;
using System.Linq;

namespace Infrastructure.Query
{
    public class AddressQueries
    {
        private readonly CostomerDbContext Context;

        public AddressQueries(CostomerDbContext context)
        {
            Context = context;
        }

        public async Task<List<GetAddressDetails>> GetAllAddress()
        {
            return await Context.Address.Select(x => new GetAddressDetails
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Street = x.Street,
                Zip = x.Zip,
                City = x.City,
                Country = x.Country

            })
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<GetAddressDetails> GetAddressById(AddressQueryModels.GetAddressById query)
        {
            return await Context.Address
                .Where(x => x.Id == query.Id)
                .Select(x => new GetAddressDetails
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    Street = x.Street,
                    Zip = x.Zip,
                    City = x.City,
                    Country = x.Country
                })
                .FirstOrDefaultAsync();
        }
    }
}
