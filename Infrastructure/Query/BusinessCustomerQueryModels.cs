using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Query
{
    public static class BusinessCustomerQueryModels
    {
        public class GetCustomerById
        {
            public int Id { get; set; }
        }

        public class GetSearchedCustomers
        {
            public string SearchTerm { get; set; }

            public int Page { get; set; }

            public int PageSize { get; set; }
        }
    }
}
