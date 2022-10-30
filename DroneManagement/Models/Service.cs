namespace DroneManagement.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int DroneId { get; set; }
        public ServiceType serviceType { get; } = new ServiceType();
        
    }
}
