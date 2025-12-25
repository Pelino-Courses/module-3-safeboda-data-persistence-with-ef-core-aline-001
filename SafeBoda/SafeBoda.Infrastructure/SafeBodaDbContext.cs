using Microsoft.EntityFrameworkCore;
using SafeBoda.Core;

namespace SafeBoda.Infrastructure
{
    public class SafeBodaDbContext : DbContext
    {
        public SafeBodaDbContext(DbContextOptions<SafeBodaDbContext> options) : base(options) { }

        public DbSet<Rider> Riders { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Fare).HasColumnType("decimal(18,2)");
                entity.HasOne(t => t.Rider).WithMany().HasForeignKey(t => t.RiderId);
                entity.HasOne(t => t.Driver).WithMany().HasForeignKey(t => t.DriverId);
            });
        }
    }
}