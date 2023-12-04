namespace InimcoDemoBackEnd.Models
{
    public class PersonExtendedDto : PersonDto
    {
        public uint Vowels { get; set; }
        public uint Constenants { get; set; }
        public string Fullname { get; set; }
        public string ReversedFullname { get; set; }
        public string personAsJson { get; set; }
    }
}
