using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InimcoDemoBackEnd.Entities;

namespace InimcoDemoBackEnd.Models
{
    public class SocialMediaAccountEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [ForeignKey("PersonEntity")]
        public uint PersonEntityId { get; set; }

        public string Type { get; set; }

        public string Address { get; set; }

        // Navigation properies
        public virtual PersonEntity PersonEntity { get; set; } = null!;
    }
}
