using Microsoft.AspNetCore.Mvc;
using DroneManagement.Models;

namespace DroneManagement.Services
{
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> Index()
        {
            using var context = new DroneManagementDbContext();
            var list = context.Services.ToList();
            return list;
        }

        public Service GetService(int id)
        {
            using var context = new DroneManagementDbContext();
            var drone = context.Services.Find(id);
            if(drone != null)
            {
                return drone;
            } else
            {
                throw new Exception();
            }
        }

        public Service CreateService(int droneId)
        {
            using var context = new DroneManagementDbContext();

            int newID;
            if (context.Services.Any())
            {
                newID = context.Services.Select(x => x.Id).Max() + 1;
            } else
            {
                newID = 1;
            }

            Service service = new()
            {
                Id = newID,
                DroneId = droneId
            };

            context.Services.Add(service);
            context.SaveChanges();
            return service;
        }

        public Service UpdateService(Service service)
        {
            using var context = new DroneManagementDbContext();

            context.Services.Update(service);
            context.SaveChanges();
            return GetService(service.Id);
        }

        public bool DeleteService(int id)
        {
            using var context = new DroneManagementDbContext();

            var service = context.Services.Find(id);
            if(service != null)
            {
                context.Services.Remove(service);
                var changes = context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }
    }
}
