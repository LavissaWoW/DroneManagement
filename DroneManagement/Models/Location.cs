using Microsoft.EntityFrameworkCore;

namespace DroneManagement.Models
{
    [Keyless]
    public class Location
    {
        public Location(double latitude = 78.22093, double longitude = 15.64488, double altitude = 25.35)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }
}
