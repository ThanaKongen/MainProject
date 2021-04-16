using System;
using System.Collections.Generic;
using System.Text;

namespace DanBase.Shared.CustomerModels.Command
{
    public static class BusinessCustomerCommandDto
    {
        public class AddCustomer
        {
            public int CompanyId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string CVR { get; set; }

            public string EAN { get; set; }

            public string WWW { get; set; }

            public int VatCode { get; set; }

            public string DebitorNo { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            //public DateTime Birthday { get; set; }

            public string Text { get; set; }

            public string AccountNo { get; set; }

            public readonly DateTime Created = DateTime.Now;

            public readonly DateTime LastUpdate = DateTime.Now;
        }

        public class UpdateCustomer
        {
            public int Id { get; set; }

            public int CompanyId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string CVR { get; set; }

            public string EAN { get; set; }

            public string WWW { get; set; }

            public int VatCode { get; set; }

            public string DebitorNo { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            //public DateTime Birthday { get; set; }

            public string Text { get; set; }

            public string AccountNo { get; set; }

            public readonly DateTime LastUpdate = DateTime.Now;
        }

        public class DeleteCustomer
        {
            public int Id { get; set; }
        }
    }
}
