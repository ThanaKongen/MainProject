using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Danbase.WebClient.Models
{
    public class BusinessCustomer
    {
        public class BusinessCustomerDetails
        {

            public int Id { get; set; }

            [Required(ErrorMessage = "CompanyId mangler.")]
            public int CompanyId { get; set; }

            [Required(ErrorMessage = "Fornavn mangler.")]
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string CVR { get; set; }

            public string EAN { get; set; }

            public string WWW { get; set; }

            public int Vatcode { get; set; }

            public string DebitorNo { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string Text { get; set; }

            public string AccountNo { get; set; }

            public DateTime Created { get; set; }

            public DateTime LastUpdated { get; set; }
        }
    }
}
