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
    }
}
