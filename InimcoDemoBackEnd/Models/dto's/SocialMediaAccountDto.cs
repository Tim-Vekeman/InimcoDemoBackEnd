namespace InimcoDemoBackEnd.Models
{
    public class SocialMediaAccountDto
    {
        public string Type { get; set; }
        public string Address { get; set; }

        //* Constructors
        //required for inheratence
        //public is required for recieving data in the controller
        public SocialMediaAccountDto() { }

        /// <summary>
        /// Will transform a SocialMediaAccountEntity to a SocialMediaAccountDto
        /// </summary>
        /// <param name="socialMediaAccountEntity">The socialMediaAccountEntity to convert</param>
        internal SocialMediaAccountDto(SocialMediaAccountEntity socialMediaAccountEntity) 
        { 
            this.Type = socialMediaAccountEntity.Type;
            this.Address = socialMediaAccountEntity.Address;
        }

        //* Assist functions

        /// <summary>
        /// Checks if all fields from the SocialMediaAccountDto are filled in correctly
        /// </summary>
        /// <returns>Boolean to confirm if the fields are filled in correctly or not</returns>
        internal bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(this.Type)) return false;
            if (String.IsNullOrWhiteSpace(this.Address)) return false;
            return true;
        }
    }
}
