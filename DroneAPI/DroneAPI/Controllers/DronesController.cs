using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroneAPI.Data;
using DroneAPI.Models;

namespace DroneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly DroneContext _context;

        public DronesController(DroneContext context)
        {
            _context = context;
        }

        // GET: api/Drones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drone>>> GetDrones()
        {
            return await _context.Drones.ToListAsync();
        }

        // GET: api/Drones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drone>> GetDrone(int id)
        {
            var drone = await _context.Drones.FindAsync(id);

            if (drone == null)
            {
                return NotFound();
            }

            return drone;
        }

        // PUT: api/Drones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrone(int id, DroneDTO droneDTO)
        {
            if (id != droneDTO.DroneID)
            {
                return BadRequest();
            }

            Drone drone = new()
            {
                DroneID = id,
                Model = droneDTO.Model,
                SerialNumber = droneDTO.SerialNumber,
                UserID = droneDTO.UserID,
            };

            _context.Entry(drone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DroneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drone>> PostDrone(DroneDTO droneDTO)
        {
            Drone drone = new()
            {
                UserID = droneDTO.UserID,
                SerialNumber = droneDTO.SerialNumber,
                Model = droneDTO.Model,
            };
            _context.Drones.Add(drone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrone", new { id = drone.DroneID }, drone);
        }

        // DELETE: api/Drones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrone(int id)
        {
            var drone = await _context.Drones.FindAsync(id);
            if (drone == null)
            {
                return NotFound();
            }

            _context.Drones.Remove(drone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DroneExists(int id)
        {
            return _context.Drones.Any(e => e.DroneID == id);
        }
    }
}
