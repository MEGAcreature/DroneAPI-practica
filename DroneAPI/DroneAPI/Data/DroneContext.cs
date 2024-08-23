using Microsoft.EntityFrameworkCore;
using DroneAPI.Models;

namespace DroneAPI.Data
{
    public class DroneContext(DbContextOptions<DroneContext> options) : DbContext(options)
    {
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Snapshot> Snapshots { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drone>().ToTable("Drone");
            modelBuilder.Entity<Snapshot>().ToTable("Snapshot");
            modelBuilder.Entity<User>().ToTable("User");
        }

    }
}
