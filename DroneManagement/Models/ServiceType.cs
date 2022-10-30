using Microsoft.EntityFrameworkCore;

namespace DroneManagement.Models
{
    [Keyless]
    public class ServiceType
    {
        public ServiceType()
        {
        }

        public string Type { get; set; } = TypeString[0];

        private static readonly string[] TypeString = new[]
        {
            "Planned maintenance", "Unplanned Maintenance", "Repair", "Emergency Repair"
        };
    }
}
