using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("PrivateCustomer")]
    public class PrivateCustomer : Customer
    {
        public PrivateCustomer(int id, string firstName, string lastName, string accountNo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AccountNo = accountNo;
        }

        [MaxLength(10)]
        public string CPR { get; set; }

        public DateTime CPRDelete { get; set; }
    }
}
