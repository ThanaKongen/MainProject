using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static DanBase.Shared.CustomerModels.Query.BusinessCustomerReadModelsDto;
using System.Linq;

namespace Infrastructure.Query
{
    public class BusinessCustomerQueries
    {
        private readonly CostomerDbContext Context;

        public BusinessCustomerQueries(CostomerDbContext _context)
        {
            Context = _context;
        }

        public async Task<List<GetCustomerDetails>> GetAllCustomers()
        {
            return await Context.BusinessCustomer.Select(x => new GetCustomerDetails
            {
                Id = x.Id,
                CompanyId = x.CompanyId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CVR = x.CVR,
                EAN = x.EAN,
                WWW = x.WWW,
                VatCode = x.VatCode,
                DebitorNo = x.DebitorNo,
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

        public async Task<GetCustomerDetails> GetCustomerById(BusinessCustomerQueryModels.GetCustomerById query)
        {
            return await Context.BusinessCustomer
                .Where(x => x.Id == query.Id)
                .Select(x => new GetCustomerDetails
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CVR = x.CVR,
                    EAN = x.EAN,
                    WWW = x.WWW,
                    VatCode = x.VatCode,
                    DebitorNo = x.DebitorNo,
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
