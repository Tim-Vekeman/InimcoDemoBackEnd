using InimcoDemoBackEnd.DatabaseContext;
using InimcoDemoBackEnd.Entities;
using InimcoDemoBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace InimcoDemoBackEnd.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonDatabaseContext personDatabaseContext;

        public PersonService(PersonDatabaseContext personDatabaseContext) 
        {
            this.personDatabaseContext = personDatabaseContext;
        }

        public async Task<PersonDto> InsertNewPerson(PersonDto personToInsert)
        {
            // Create a new User entity
            var person = new PersonEntity(personToInsert);

            // Add the user to the database
            personDatabaseContext.Persons.Add(person);

            // Save changes to the database
            await personDatabaseContext.SaveChangesAsync();

            return new PersonDto(person);
        }
    }
}
