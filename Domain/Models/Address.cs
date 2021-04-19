using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [MaxLength(255)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string Zip { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public Address()
        {

        }

        public Address(int customerId, string street, string zip, string city, string country)
        {
            CustomerId = customerId;
            Street = street;
            Zip = zip;
            City = city;
            Country = country;
        }

        public void AddressUpdate(int customerId, string street, string zip, string city, string country)
        {
            CustomerId = customerId;
            Street = street;
            Zip = zip;
            City = city;
            Country = country;
        }
    }
}
