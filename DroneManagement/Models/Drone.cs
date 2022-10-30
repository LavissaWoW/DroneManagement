using DroneManagement.Controllers;
using System.Net;
using System.Net.Http;

namespace DroneManagement.Models
{
    public class Drone
    {
        public Drone()
        {
        }
        public int Id { get; set; }  
        public string State { get; set; } = DroneStates[0];
        public Location Position { get; } = new Location();
        public Diagnostics Diagnostics { get; } = new Diagnostics();

        private static readonly string[] DroneStates = new[]
        {
            "Parked", "Delivering", "Returning", "Service"
        };
        
        // Does not work
        public async Task<bool> SimulatedHWError()
        {
            HttpClient client = new();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var values = new Dictionary<string, string>
            {
                {"id", Id.ToString()}
            };

            var content = new FormUrlEncodedContent(values);
            var uri = new Uri("http://localhost/api/Service", UriKind.Absolute);
            var response = await client.PostAsync(uri, content);

            return true;
        }
    }
}
