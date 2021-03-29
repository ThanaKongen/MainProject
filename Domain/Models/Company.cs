using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}