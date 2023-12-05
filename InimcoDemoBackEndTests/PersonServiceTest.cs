using InimcoDemoBackEnd.DatabaseContext;
using InimcoDemoBackEnd.Entities;
using InimcoDemoBackEnd.Models;
using InimcoDemoBackEnd.Services;
using Microsoft.EntityFrameworkCore;

namespace InimcoDemoBackEndTests
{
    [TestFixture]
    public class PersonServiceTest
    {
        private PersonDatabaseContext _dbContext;
        private PersonService _personService;

        [SetUp]
        public void Setup()
        {
            // Initialize in-memory database context
            var options = new DbContextOptionsBuilder<PersonDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new PersonDatabaseContext(options);
            _personService = new PersonService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the database context after each test
            _dbContext.Dispose();
        }

        [Test]
        public async Task InsertNewPerson_ShouldInsertPerson()
        {

            #region Arrange
            var personDto1 = new PersonDto
            {
                Firstname = "Jhon",
                Lastname = "Doe",
                SocialSkills = ["tenacious", "head strong"],
                SocialMediaAccounts = new[]
                {
                    new SocialMediaAccountDto()
                    {
                        Type = "google",
                        Address = "https://www.google.be"
                    }
                }
            };

            var personDto2 = new PersonDto
            {
                Firstname = "Jane",
                Lastname = "Doe",
                SocialSkills = ["Social"],
                SocialMediaAccounts = new[]
                {
                    new SocialMediaAccountDto()
                    {
                        Type = "linkedin",
                        Address = "https://www.linkedin.be"
                    },
                    new SocialMediaAccountDto()
                    {
                        Type = "youtube",
                        Address = "https://www.youtube.com"
                    }
                }
            };
            #endregion

            #region Act
            var result1 = await _personService.InsertNewPerson(personDto1);
            var result2 = await _personService.InsertNewPerson(personDto2);
            #endregion

            #region Assertions
            //* result 1
            Assert.IsNotNull(result1);
            Assert.AreEqual(result1.Firstname, personDto1.Firstname);
            Assert.AreEqual(result1.Lastname, personDto1.Lastname);
            Assert.AreEqual(result1.SocialSkills, personDto1.SocialSkills);

            // check if the person was added to the database
            var insertedPerson1 = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == result1.Id);
            Assert.IsNotNull(insertedPerson1);

            //* result 2
            Assert.IsNotNull(result2);
            Assert.AreEqual(result2.Firstname, personDto2.Firstname);
            Assert.AreEqual(result2.Lastname, personDto2.Lastname);
            Assert.AreEqual(result2.SocialSkills, personDto2.SocialSkills);

            // check if the person was added to the database
            var insertedPerson2 = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == result2.Id);
            Assert.IsNotNull(insertedPerson2);

            //* general
            Assert.True(insertedPerson1.Id < insertedPerson2.Id);
            #endregion
        }

        [Test]
        public async Task GetExtendedPersonById_ShouldReturnExtendedPersonDto()
        {
            #region Arrange
            var personEntity = new PersonEntity
            {
                Firstname = "John",
                Lastname = "Doe",
                SocialSkills = ["tenacious", "head strong"],
                SocialMediaAccounts = new List<SocialMediaAccountEntity>()
                {
                    new SocialMediaAccountEntity()
                    {
                        Type = "google",
                        Address = "https://www.google.be"
                    },
                    new SocialMediaAccountEntity()
                    {
                        Type = "linkedin",
                        Address = "https://www.linkedin.be"
                    },
                    new SocialMediaAccountEntity()
                    {
                        Type = "youtube",
                        Address = "https://www.youtube.com"
                    }
                }
            };

            var personExtendedDto = new PersonExtendedDto
            {
                Firstname = "John",
                Lastname = "Doe",
                SocialSkills = ["tenacious", "head strong"],
                Fullname = "John Doe",
                Vowels = 3,
                Constenants = 4,
                ReversedFullname = "eoD nhoJ",
                SocialMediaAccounts = new[]
                {
                    new SocialMediaAccountDto()
                    {
                        Type = "google",
                        Address = "https://www.google.be"
                    },
                    new SocialMediaAccountDto()
                    {
                        Type = "linkedin",
                        Address = "https://www.linkedin.be"
                    },
                    new SocialMediaAccountDto()
                    {
                        Type = "youtube",
                        Address = "https://www.youtube.com"
                    }
                }
            };

            _dbContext.Persons.Add(personEntity);
            await _dbContext.SaveChangesAsync();
            #endregion

            #region Act
            var result = await _personService.GetExtendedPersonById(personEntity.Id);
            #endregion

            #region Assert
            Assert.IsNotNull(result);
            // Check if the SocialMediaAccounts are included
            Assert.IsNotNull(result.SocialMediaAccounts);
            Assert.IsTrue(result.SocialMediaAccounts.Any());

            Assert.AreEqual(result.Firstname, personExtendedDto.Firstname);
            Assert.AreEqual(result.Lastname, personExtendedDto.Lastname);
            Assert.AreEqual(result.SocialSkills, personExtendedDto.SocialSkills);
            Assert.AreEqual(result.Fullname, personExtendedDto.Fullname);
            Assert.AreEqual(result.ReversedFullname, personExtendedDto.ReversedFullname);
            Assert.AreEqual(result.Vowels, personExtendedDto.Vowels);
            Assert.AreEqual(result.Constenants, personExtendedDto.Constenants);
            #endregion
        }
    }
}