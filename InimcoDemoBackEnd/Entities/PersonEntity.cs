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

        //*constructors
        //required for inheratence
        /// <summary>
        /// default constructor
        /// </summary>
        protected PersonEntity() { }

        /// <summary>
        /// Will transform a personDto to a PersonEntity
        /// IF "Id" IS NULL IT WILL NOT BE ASSIGNED
        /// </summary>
        /// <param name="person">The personDto that needs to be converted</param>
        internal PersonEntity(PersonDto person)
        {
            if (person.Id != null) this.Id = (uint) person.Id;
            this.Firstname = person.Firstname;
            this.Lastname = person.Lastname;
            this.SocialSkills = person.SocialSkills;
            this.SocialMediaAccounts = person.SocialMediaAccounts.Select(x => new SocialMediaAccountEntity(x)).ToArray();
        }
    }
}
