using DanBase.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DanBase.Shared.CustomerModels.Command
{
    public static class CustomerCommandDto
    {
        public class AddCustomer
        {
            public int CompanyId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            //public DateTime Birthday { get; set; }

            public string Text { get; set; }

            public string AccountNo { get; set; }

            public readonly DateTime Created = DateTime.Now;

            public readonly DateTime LastUpdate = DateTime.Now;

            public CustomerTypeEnum CustomerType {get;set;}
        }

        public class UpdateCustomer
        {
            public int CompanyId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public DateTime Birthday { get; set; }

            public string Text { get; set; }

            public string AccountNo { get; set; }

            public DateTime Created { get; set; }

            public DateTime LastUpdate { get; set; }

            public CustomerTypeEnum CustomerType { get; set; }
        }

        public class DeleteCustomer
        {
            public int Id { get; set; }
        }
    }
}
