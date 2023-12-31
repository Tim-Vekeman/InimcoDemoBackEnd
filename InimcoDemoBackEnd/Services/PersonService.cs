﻿using InimcoDemoBackEnd.DatabaseContext;
using InimcoDemoBackEnd.Entities;
using InimcoDemoBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace InimcoDemoBackEnd.Services
{
    public class PersonService : IPersonService
    {
        #region Fields
        private readonly PersonDatabaseContext personDatabaseContext;
        #endregion

        #region Constructor
        public PersonService(PersonDatabaseContext personDatabaseContext) 
        {
            this.personDatabaseContext = personDatabaseContext;
        }
        #endregion

        #region Public Functions
        public async Task<PersonDto> InsertNewPerson(PersonDto personToInsert)
        {
            var person = new PersonEntity(personToInsert);

            personDatabaseContext.Persons.Add(person);
            await personDatabaseContext.SaveChangesAsync();

            return new PersonDto(person);
        }

        public async Task<PersonExtendedDto> GetExtendedPersonById(uint id)
        {
            var personEntity = await personDatabaseContext.Persons
                .Include(x => x.SocialMediaAccounts)
                .FirstAsync(x => x.Id == id);
            return new PersonExtendedDto(new PersonDto(personEntity));
        }
        #endregion
    }
}
