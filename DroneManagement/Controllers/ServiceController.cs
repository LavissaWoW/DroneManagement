using Microsoft.AspNetCore.Mvc;
using DroneManagement.Models;
using DroneManagement.Services;

namespace DroneManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        /// <summary>
        /// List all services
        /// </summary>
        /// <returns>List of all services</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Index()
        {
            return Ok(_serviceRepository.Index());
        }
        
        /// <summary>
        /// Get service with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Service</returns>
        [HttpGet]
        [Route("/api/[controller]/{id}")]
        [ProducesResponseType(typeof(Service), 200)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Service service = _serviceRepository.GetService(id);
                return Ok(service);
            } catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a new service
        /// </summary>
        /// <param name="droneId"></param>
        /// <returns>The created Service</returns>
        [HttpPost]
        [Route("/api/[controller]")]
        [ProducesResponseType(typeof(Service), 201)]
        public async Task<IActionResult> Create(int droneId)
        {
            Service service = _serviceRepository.CreateService(droneId);
            return Created("", service);
        }

        /// <summary>
        /// Updates Service with gived Id
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Updated Service</returns>
        [HttpPut]
        [Route("/api/[controller]/{id}")]
        [ProducesResponseType(typeof(Service), 200)]
        public async Task<IActionResult> Update([FromBody]Service service)
        {
            if (ModelState.IsValid)
            {
                Service newService = _serviceRepository.UpdateService(service);
                return Ok(newService);
            } else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes Service with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/api/[controller]/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _serviceRepository.DeleteService(id);
            if (result == true)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}
