using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class RelationshipType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Relationship> Relationships { get; set; }
    }
}
