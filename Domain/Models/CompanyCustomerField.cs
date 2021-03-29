using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class CompanyCustomerField
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerField")]
        public int CustomerFieldId { get; set; }
        public CustomerField CustomerField { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
