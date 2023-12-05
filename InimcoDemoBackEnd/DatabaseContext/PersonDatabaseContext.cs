using InimcoDemoBackEnd.Entities;
using InimcoDemoBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace InimcoDemoBackEnd.DatabaseContext
{
    public class PersonDatabaseContext : DbContext
    {
        #region Constructors
        public PersonDatabaseContext(DbContextOptions<PersonDatabaseContext> options) : base(options)
        {
        }
        #endregion

        #region DB Sets
        public DbSet<PersonEntity> Persons { get; set; }
        #endregion

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialMediaAccountEntity>()
                .HasKey(sma => new { sma.Id });

            modelBuilder.Entity<SocialMediaAccountEntity>()
                .HasOne(sma => sma.PersonEntity)
                .WithMany(p => p.SocialMediaAccounts)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonEntity>()
                .HasKey(p => new { p.Id });
        }
        #endregion
    }
}
