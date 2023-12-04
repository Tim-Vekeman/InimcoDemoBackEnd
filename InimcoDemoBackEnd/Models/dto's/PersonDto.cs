using InimcoDemoBackEnd.Entities;

namespace InimcoDemoBackEnd.Models
{
    public class PersonDto
    {
        public uint? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string[] SocialSkills { get; set; }
        public SocialMediaAccountDto[] SocialMediaAccounts { get; set; }

        //*constructors
        //required for inheratence
        //public is required for recieving data in the controller
        /// <summary>
        /// default constructor
        /// </summary>
        public PersonDto() { }

        /// <summary>
        /// constructor to pass a person dto as base class
        /// </summary>
        /// <param name="person">The personDto to send to the base class</param>
        protected PersonDto(PersonDto person)
        {
            this.Id = person.Id;
            this.Firstname = person.Firstname;
            this.Lastname = person.Lastname;
            this.SocialSkills = person.SocialSkills;
            this.SocialMediaAccounts = person.SocialMediaAccounts;
        }

        /// <summary>
        /// Will transform a PersonEntity to a personDto
        /// </summary>
        /// <param name="person">The personEntity that needs to be converted</param>
        internal PersonDto(PersonEntity person)
        {
            this.Id = person.Id;
            this.Firstname = person.Firstname;
            this.Lastname = person.Lastname;
            this.SocialSkills = person.SocialSkills;
            this.SocialMediaAccounts = person.SocialMediaAccounts.Select(x => new SocialMediaAccountDto(x)).ToArray();
        }

        //* Assist functions

        /// <summary>
        /// Will check if all fields of the PersonDto are filled in correctly
        /// </summary>
        /// <param name="shouldIdBeChecked">Should the "Id"-field be filled in (!null)</param>
        /// <returns>Boolean confirming if the PersonDto's fields are filled in or not</returns>
        internal bool IsValid(bool shouldIdBeChecked)
        {
            if (shouldIdBeChecked)
            {
                if(Id == null) return false;
            }
            if(String.IsNullOrWhiteSpace(this.Firstname)) return false;
            if(String.IsNullOrWhiteSpace(this.Lastname)) return false;
            if(SocialSkills.Any(String.IsNullOrWhiteSpace)) return false;
            if(SocialMediaAccounts.Any(x => !x.IsValid())) return false;
            return true;
        }
    }
}
