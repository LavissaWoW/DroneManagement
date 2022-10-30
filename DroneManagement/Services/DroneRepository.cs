using DroneManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneManagement.Services
{
    public class DroneRepository : IDroneRepository
    {
        public List<Drone> GetDrones()
        {
            using var context = new DroneManagementDbContext();
            var list = context.Drones.ToList();
            return list;
        }

        public Drone GetDrone(int id)
        {
            using var context = new DroneManagementDbContext();
            var drone = context.Drones.Find(id);
            if (drone != null)
            {
                return drone;
            } else
            {
                throw new Exception();
            }
        }

        public Drone CreateDrone()
        {
            using var context = new DroneManagementDbContext();
            int newID;
            if (context.Drones.Any())
            {
                newID = context.Drones.Select(x => x.Id).Max() + 1;
            }
            else
            {
                newID = 1;
            }

            Drone drone = new()
            {
                Id = newID
            };

            context.Drones.Add(drone);
            context.SaveChanges();
            return drone;
        }
        public Drone UpdateDrone(Drone drone)
        {
            using var context = new DroneManagementDbContext();

            context.Drones.Update(drone);
            context.SaveChanges();
            return GetDrone(drone.Id);
        }

        public bool DeleteDrone(int id)
        {
            using var context = new DroneManagementDbContext();

            var drone = context.Drones.Find(id);
            if(drone != null)
            {
                context.Drones.Remove(drone);
                var changes = context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
