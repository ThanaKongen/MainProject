using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("PrivateCustomer")]
    public class PrivateCustomer:Customer
    {
        [Key]
        public new int Id { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CPR { get; set; }
    }
}
