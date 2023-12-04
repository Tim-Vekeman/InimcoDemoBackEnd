using InimcoDemoBackEnd.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InimcoDemoBackEnd.Entities
{
    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string[] SocialSkills { get; set; }
        public ICollection<SocialMediaAccountEntity> SocialMediaAccounts { get; set; }
    }
}
