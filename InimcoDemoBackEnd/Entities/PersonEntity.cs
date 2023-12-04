using InimcoDemoBackEnd.Models;

namespace InimcoDemoBackEnd.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string[] SocialSkills { get; set; }
        public SocialMediaAccount[] SocialMediaAccounts { get; set; }
    }
}
