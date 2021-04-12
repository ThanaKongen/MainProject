using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static DanBase.Shared.CustomerModels.Query.CustomerReadModelsDto;
using System.Linq;

namespace Infrastructure.Query
{
    public class CustomerQueries
    {
        private readonly CostomerDbContext Context;

        public CustomerQueries(CostomerDbContext _context)
        {
            Context = _context;
        }

        public async Task<List<GetCustomerDetails>> GetAllCustomers()
        {
            return await Context.Customer.Select(x => new GetCustomerDetails
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                AccountNo = x.AccountNo
            })
                .OrderByDescending(x => x.FirstName)
                .ToListAsync();
        }

        public async Task<GetCustomerDetails> GetCustomerById(CustomerQueryModels.GetCustomerById query)
        {
            return await Context.Customer
                .Where(x => x.Id == query.Id)
                .Select(x => new GetCustomerDetails
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    AccountNo = x.AccountNo
                })
                .FirstOrDefaultAsync();
        }

    }
}
