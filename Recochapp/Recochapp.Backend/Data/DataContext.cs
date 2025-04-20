using Microsoft.EntityFrameworkCore;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.PhoneNumber).IsUnique();

            modelBuilder.Entity<Group>().HasIndex(x => x.AccessCode).IsUnique();

            modelBuilder.Entity<Establishment>().HasIndex(x => x.Email).IsUnique();
        }

    }
}
