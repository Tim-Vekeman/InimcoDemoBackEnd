using InimcoDemoBackEnd.Entities;
using InimcoDemoBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace InimcoDemoBackEnd.DatabaseContext
{
    public class PersonDatabaseContext : DbContext
    {
        public PersonDatabaseContext(DbContextOptions<PersonDatabaseContext> options) : base(options)
        {
        }
        public DbSet<PersonEntity> Persons { get; set; }

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
    }
}
