using System;
using System.Collections.Generic;
using System.Text;

namespace DanBase.Shared.CustomerModels.Query
{
    public static class AddressReadModelsDto
    {
        public class GetAddressDetails
        {
            public int Id { get; set; }

            public int CustomerId { get; set; }

            public string Street { get; set; }

            public string Zip { get; set; }

            public string City { get; set; }

            public string Country { get; set; }
        }
    }
}
