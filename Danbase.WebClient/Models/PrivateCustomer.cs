using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Danbase.WebClient.Models
{
    public class PrivateCustomer
    {
        public class PrivateCustomerDetails
        {
            public int id { get; set; }

            [Required(ErrorMessage = "CompanyId mangler.")]
            public int companyId { get; set; }

            [Required(ErrorMessage = "Fornavn mangler.")]
            public string firstName { get; set; }

            public string lastName { get; set; }

            //public string cPR { get; set; }

            public string username { get; set; }

            public string password { get; set; }

            public string text { get; set; }

            public string account { get; set; }

            public DateTime created { get; set; }

            public DateTime lastUpdated { get; set; }
        }
    }
}
