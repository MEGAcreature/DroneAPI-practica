using DroneAPI.Models;
using DroneAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DroneAPI.Controllers
{
    [Route("api/Drone")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private readonly ILogger<DroneController> _logger;

        public DroneController(ILogger<DroneController> logger)
        {
            _logger = logger;
        }

        // GET: api/<DroneController>
        [HttpGet(Name = "GetDrone")]
        public IEnumerable<Drone> Get()
        {
            return DroneService.GetAll();
        }

        // GET api/<DroneController>/5
        [HttpGet("{id}")]
        public ActionResult<Drone> Get(int id)
        {
            var drone = DroneService.Get(id);

            if (drone == null)
            {
                return NotFound();
            }

            return drone;
        }

        // POST api/<DroneController>
        [HttpPost]
        public IActionResult Create(Drone drone)
        {
            DroneService.Add(drone);
            return CreatedAtAction(nameof(Get), new { id = drone.DroneID }, drone);
        }

        // PUT api/<DroneController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Drone drone)
        {
            if (id != drone.DroneID)
            {
                return BadRequest();
            }

            var existingDrone = DroneService.Get(id);
            if (existingDrone is  null)
            {
                return NotFound();
            }

            DroneService.Update(drone);

            return NoContent();
        }

        // DELETE api/<DroneController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drone = DroneService.Get(id);

            if (drone is null)
                return NotFound();

            DroneService.Delete(id);

            return NoContent();
        }
    }
}
