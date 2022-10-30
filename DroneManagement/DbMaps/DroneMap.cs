using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DroneManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneManagement.DbMaps
{
    public class DroneMap
    {
        public DroneMap(EntityTypeBuilder<Drone> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("drones");

            entityBuilder.Property(x => x.Id).HasColumnName("id");

        }
    }
}
