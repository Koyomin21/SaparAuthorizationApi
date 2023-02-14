using Microsoft.EntityFrameworkCore;
using SaparAuthorization.Domain.Models;

namespace SaparAuthorization.Domain
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<User>().ToTable("users", "public");
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users);
        }

    }
}