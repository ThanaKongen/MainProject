using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("BusinessCustomer")]
    public class BusinessCustomer : Customer
    {
        [MaxLength(10)]
        public string CVR { get; set; }

        [MaxLength(255)]
        public string EAN { get; set; }

        [MaxLength(255)]
        public string WWW { get; set; }

        public int VatCode { get; set; }

        [MaxLength(50)]
        public string DebitorNo { get; set; }

        public BusinessCustomer()
        {

        }

        public BusinessCustomer(int companyId, string firstName, string lastName, string cvr, string ean, string www, int vatcode, string debitorNo, string userName, string password, string text, string accountNo, DateTime created, DateTime lastUpdate)
        {
            CompanyId = companyId;
            FirstName = firstName;
            LastName = lastName;
            CVR = cvr;
            EAN = ean;
            WWW = www;
            VatCode = vatcode;
            DebitorNo = debitorNo;
            Username = userName;
            Password = password;
            Text = text;
            AccountNo = accountNo;
            Created = created;
            LastUpdate = lastUpdate;
        }

        public void BusinessCustomerUpdate(int companyId, string firstName, string lastName, string cvr, string ean, string www, int vatcode, string debitorNo, string userName, string password, string text, string accountNo, DateTime lastUpdate)
        {
            CompanyId = companyId;
            FirstName = firstName;
            LastName = lastName;
            CVR = cvr;
            EAN = ean;
            WWW = www;
            VatCode = vatcode;
            DebitorNo = debitorNo;
            Username = userName;
            Password = password;
            Text = text;
            AccountNo = accountNo;
            LastUpdate = lastUpdate;
        }
    }
}
