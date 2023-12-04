namespace InimcoDemoBackEnd.Models
{
    public class PersonDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string[] SocialSkills { get; set; }
        public SocialMediaAccountEntity[] SocialMediaAccounts { get; set; }
    }
}
