using Microsoft.AspNetCore.Mvc;
using DroneManagement.Models;
using DroneManagement.Services;

namespace DroneManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class DroneManagementController : ControllerBase
    {
        private readonly IDroneRepository _droneRepository;

        public DroneManagementController(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        /// <summary>
        /// List all drones
        /// </summary>
        /// <returns>List of drones</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Drone[]), 200)]
        public async Task<IActionResult> Index()
        {
            return Ok(_droneRepository.GetDrones());
        }

        /// <summary>
        /// Get Drone with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Drone matching requested ID</returns>
        [HttpGet]
        [Route("/api/[controller]/{id}")]
        [ProducesResponseType(typeof(Drone), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Drone drone = _droneRepository.GetDrone(id);
                return Ok(drone);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a new drone
        /// </summary>
        /// <returns>Requested Drone</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Drone), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create()
        {
            Drone drone = _droneRepository.CreateDrone();
            return Created("", drone);
        }

        /// <summary>
        /// Update drone with given Id
        /// </summary>
        /// <param name="drone"></param>
        /// <returns>Newly created Drone</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Drone), 200)]
        [ProducesResponseType(400)]
        [Route("/api/[controller]/{id}")]
        public async Task<IActionResult> Update([FromBody]Drone drone)
        {
            if (ModelState.IsValid)
            {
                Drone newDrone = _droneRepository.UpdateDrone(drone);
                return Ok(newDrone);
            } else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes drone with gived Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = _droneRepository.DeleteDrone(id);
            if (result == true)
            {
                return Ok();
            } else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// DOES NOT WORK - Simulates a hardware fault to trigger scheduling a service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/api/[controller]/{id}/simulate-hw-fault")]
        public async Task<IActionResult> SimulateError(int id)
        {
            Drone drone = _droneRepository.GetDrone(id);
            if (drone != null)
            {
                drone.Diagnostics.Motor1Alert = true;
                _droneRepository.UpdateDrone(drone);
                await drone.SimulatedHWError();
                return Ok(drone);
            } else
            {
                return NotFound();
            }
        }
    }
}
