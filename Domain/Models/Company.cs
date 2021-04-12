using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<CompanyCustomerField> CompanyCustomerFields { get; set; }
    }
}