using InimcoDemoBackEnd.Models;

namespace InimcoDemoBackEnd.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Async function to insert a new Person into the database
        /// </summary>
        /// <param name="personToInsert">The dto containing the data of the person to insert</param>
        /// <returns>A personDto containg the data of the inserted user</returns>
        public Task<PersonDto> InsertNewPerson(PersonDto personToInsert);
    }
}
