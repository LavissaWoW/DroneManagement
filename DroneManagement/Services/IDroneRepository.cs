using DroneManagement.Models;

namespace DroneManagement.Services
{
    public interface IDroneRepository
    {
        public List<Drone> GetDrones();
        public Drone GetDrone(int id);
        public Drone CreateDrone();
        public Drone UpdateDrone(Drone drone);
        public bool DeleteDrone(int id);
    }
}
