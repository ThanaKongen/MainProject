using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("TestCustomer")]
    public class TestCustomer:Customer
    {
        public string CVR { get; set; }
        public string EAN { get; set; }
    }
}
