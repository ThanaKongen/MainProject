using System;
using System.Collections.Generic;
using System.Text;

namespace DanBase.Shared.CustomerModels.Command
{
    public class AddressCommandDto
    {
        public class AddAddress
        {
            public int CustomerId { get; set; }

            public string Street { get; set; }

            public string Zip { get; set; }

            public string City { get; set; }

            public string Country { get; set; }
        }

        public class UpdateAddress
        {
            public int Id { get; set; }

            public int CustomerId { get; set; }

            public string Street { get; set; }

            public string Zip { get; set; }

            public string City { get; set; }

            public string Country { get; set; }
        }
        public class DeleteAddress
        {
            public int Id { get; set; }
        }
    }
}
