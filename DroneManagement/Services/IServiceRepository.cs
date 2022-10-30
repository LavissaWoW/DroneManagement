using DroneManagement.Models;

namespace DroneManagement.Services
{
    public interface IServiceRepository
    {
        public List<Service> Index();
        public Service GetService(int id);
        public Service CreateService(int droneId);
        public Service UpdateService(Service service);
        public bool DeleteService(int id);
    }
}
