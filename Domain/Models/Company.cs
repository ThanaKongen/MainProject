using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<CompanyCustomerField> CompanyCustomerFields { get; set; }
    }
}