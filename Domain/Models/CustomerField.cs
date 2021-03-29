using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CustomerField
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Datatype { get; set; }

        public virtual ICollection<CustomerFieldValue> CustomerFieldValues { get; set; }

        public virtual ICollection<CompanyCustomerField> CompanyCustomerFields { get; set; }
    }
}
