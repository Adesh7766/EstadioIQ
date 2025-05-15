using EstadioIQ.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EstadioIQ.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "Adesh.Pandey",
                    Email = "adesh.pandey1673@gmail.com",
                    PasswordHash = "newpassword",
                    Role = "Admin",
                    CreatedDate = new DateTime(2025, 5, 15)
                }
            );
        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<MatchPerformance> MatchPerformances { get; set; }
    }
}
