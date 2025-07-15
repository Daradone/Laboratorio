using poc.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace poc.infrastructure.context
{
    public class pocDbContext : DbContext
    {
        public pocDbContext(DbContextOptions<pocDbContext> options) : base(options) { }

        public DbSet<Person> TB001 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                                                            
            modelBuilder.Entity<Person>().ToTable("TB001_Person");
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Nome).IsRequired().HasMaxLength(100);
        }
    }
}