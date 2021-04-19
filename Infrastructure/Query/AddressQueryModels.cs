using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Query
{
    public class AddressQueryModels
    {
        public class GetAddressById
        {
            public int Id { get; set; }
        }

        public class GetSearchedAddress
        {
            public string SearchTerm { get; set; }

            public int Page { get; set; }

            public int PageSize { get; set; }
        }
    }
}
