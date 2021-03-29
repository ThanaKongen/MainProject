using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("RelationshipType")]
        public int RelationshipTypeId { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

        public int RelatedCustomerId { get; set; }

    }
}