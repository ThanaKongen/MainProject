using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("PrivateCustomer")]
    public class PrivateCustomer : Customer
    {
        [MaxLength(10)]
        public string CPR { get; set; }

        public DateTime CPRDelete { get; set; }
    }
}
