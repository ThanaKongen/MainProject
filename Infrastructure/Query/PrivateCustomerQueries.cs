using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static DanBase.Shared.CustomerModels.Query.PrivateCustomerReadModelsDto;
using System.Linq;

namespace Infrastructure.Query
{
    public class PrivateCustomerQueries
    {
        private readonly CostomerDbContext Context;

        public PrivateCustomerQueries(CostomerDbContext _context)
        {
            Context = _context;
        }

        public async Task<List<GetCustomerDetails>> GetAllCustomers()
        {
            return await Context.PrivateCustomer.Select(x => new GetCustomerDetails
            {
                Id = x.Id,
                CompanyId = x.CompanyId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CPR = x.CPR,
                Username = x.Username, 
                Password = x.Password,
                Text = x.Text,
                AccountNo = x.AccountNo, 
                Created = (DateTime)x.Created,
                LastUpdate = (DateTime)x.LastUpdate

            })
                .OrderByDescending(x => x.Created)
                .ToListAsync();
        }

        public async Task<GetCustomerDetails> GetCustomerById(PrivateCustomerQueryModels.GetCustomerById query)
        {
            return await Context.PrivateCustomer
                .Where(x => x.Id == query.Id)
                .Select(x => new GetCustomerDetails
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CPR = x.CPR,
                    Username = x.Username,
                    Password = x.Password,
                    Text = x.Text,
                    AccountNo = x.AccountNo,
                    Created = (DateTime)x.Created,
                    LastUpdate = (DateTime)x.LastUpdate
                })
                .FirstOrDefaultAsync();
        }

    }
}
