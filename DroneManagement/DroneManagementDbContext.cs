using DroneManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneManagement
{
    public class DroneManagementDbContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DroneDb");
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Diagnostics> Diagnostics { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

    }
}
