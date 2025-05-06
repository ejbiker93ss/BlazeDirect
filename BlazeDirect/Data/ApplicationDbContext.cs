using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Church> Churches { get; set; }
        public DbSet<Fellowship> Fellowships { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PersonPlaceType> PersonPlaceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure default value for CreatedAt
            modelBuilder.Entity<Fellowship>()
                .Property(f => f.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Place>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Relationship>()
                .Property(r => r.CreatedAt)
                .HasDefaultValueSql("getdate()");

            // Configure foreign key relationships for Relationships table
            modelBuilder.Entity<Relationship>()
                .HasOne(r => r.Person)
                .WithMany()
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for PersonId

            modelBuilder.Entity<Relationship>()
                .HasOne(r => r.RelatedPerson)
                .WithMany()
                .HasForeignKey(r => r.RelatedPersonId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for RelatedPersonId
        }

    }
}
