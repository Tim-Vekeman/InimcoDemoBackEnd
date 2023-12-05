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


        //* Constructors
        //required for inheratence
        /// <summary>
        /// default constructor
        /// </summary>
        public SocialMediaAccountEntity() { }


        /// <summary>
        /// Turns the SocialMediaAccountDto into an entity (not overlapping fields will be "null")
        /// </summary>
        /// <param name="socialMediaAccountDto">The socialMediaAccountDto to convert</param>
        internal SocialMediaAccountEntity(SocialMediaAccountDto socialMediaAccountDto)
        {
            this.Type = socialMediaAccountDto.Type;
            this.Address = socialMediaAccountDto.Address;
        }
    }
}
