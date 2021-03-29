using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public abstract class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(255)]
        public string Text { get; set; }

        [MaxLength(50)]
        public string AccountNo { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdate { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
}
