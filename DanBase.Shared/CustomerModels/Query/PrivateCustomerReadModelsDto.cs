using System;
using System.Collections.Generic;
using System.Text;

namespace DanBase.Shared.CustomerModels.Query
{
    public static class PrivateCustomerReadModelsDto
    {
        public class GetCustomerDetails
        {
            public int Id { get; set; }

            public int CompanyId { get; set; }

            public string FirstName { get; set; }

            public string? LastName { get; set; }

            public string? CPR { get; set; }

            public string? Username { get; set; }

            public string? Password { get; set; }

            //public DateTime Birthday { get; set; }

            public string? Text { get; set; }

            public string? AccountNo { get; set; }

            public DateTime? Created { get; set; }

            public DateTime? LastUpdate { get; set; }
        }
    }
}
