using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace InimcoDemoBackEnd.Models
{
    public class PersonExtendedDto : PersonDto
    {
        public uint Vowels { get; set; }
        public uint Constenants { get; set; } //? should be Consonant??
        public string Fullname { get; set; }
        public string ReversedFullname { get; set; }
        public string personAsJson { get; set; }

        //* constructor
        //required for inheratence
        /// <summary>
        /// default constructor
        /// </summary>
        public PersonExtendedDto() { }

        /// <summary>
        /// Will convert a PersonDto into a ExtendedPersonDto
        /// </summary>
        /// <param name="personDto">PersonDto to use as base to create the personExtendedDto</param>
        internal PersonExtendedDto(PersonDto personDto) : base(personDto)
        {
            const string VOWELS = "aeiou";
            const string CONSTANTS = "bcdfghjklmnpqrstvwxyz"; //counting "Y" as a constants (is actually a semivowel)

            //done first inorder to use it later in the constructor
            this.Fullname = String.Concat(personDto.Firstname, " ", personDto.Lastname);

            this.Vowels = (uint) this.Fullname.Count(x => VOWELS.Contains(Char.ToLower(x)));
            this.Constenants = (uint) this.Fullname.Count(x => CONSTANTS.Contains(Char.ToLower(x)));
            this.ReversedFullname = new string(this.Fullname.Reverse().ToArray());
            this.personAsJson = JsonSerializer.Serialize(personDto);
        }
    }
}
