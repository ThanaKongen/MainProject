using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Danbase.WebClient.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
