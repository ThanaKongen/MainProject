﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("PrivateCustomer")]
    public class PrivateCustomer : Customer
    {
        //Has to be an empty contructor else EF will fail
        public PrivateCustomer()
        {

        }
        public PrivateCustomer(int companyId, string firstName, string lastName, string userName, string password, string text, string accountNo, DateTime created, DateTime lastUpdate)
        {
            CompanyId = companyId;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            Text = text;
            AccountNo = accountNo;
            Created = created;
            LastUpdate = lastUpdate;
        }

        [MaxLength(10)]
        public string CPR { get; set; }

        public DateTime CPRDelete { get; set; }
    }
}
