using Microsoft.EntityFrameworkCore;
namespace DroneManagement.Models
{
    [Keyless]
    public class Diagnostics
    {
        public Diagnostics(bool motor1Alert = false, bool motor2Alert = false, bool liftAlert = false)
        {
            Motor1Alert = motor1Alert;
            Motor2Alert = motor2Alert;
            LiftAlert = liftAlert;
        }
        public bool Motor1Alert { get; set; }
        public bool Motor2Alert { get; set; }
        public bool LiftAlert { get; set; }
    }
}
