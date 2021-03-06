using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Domain.Models
{
    public class CustomerFieldValue
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("CustomerField")]
        public int CistomerFieldId { get; set; }
        public CustomerField CustomerField { get; set; }

        [MaxLength(150)]
        public string Value { get; set; }
    }
}
