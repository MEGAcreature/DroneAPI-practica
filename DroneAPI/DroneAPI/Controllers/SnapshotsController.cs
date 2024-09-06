using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroneAPI.Data;
using DroneAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DroneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnapshotsController : ControllerBase
    {
        private readonly DroneContext _context;
        private readonly IConfiguration _config;

        public SnapshotsController(DroneContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Snapshots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snapshot>>> GetSnapshots()
        {
            return await _context.Snapshots.ToListAsync();
        }

        // GET: api/Snapshots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Snapshot>> GetSnapshot(int id)
        {
            var snapshot = await _context.Snapshots.FindAsync(id);

            if (snapshot == null)
            {
                return NotFound();
            }

            return snapshot;
        }

        // PUT: api/Snapshots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnapshot(int id, SnapshotDTO snapshotDTO)
        {
            if (id != snapshotDTO.SnapshotID)
            {
                return BadRequest();
            }

            Snapshot snapshot = new()
            {
                SnapshotID = snapshotDTO.SnapshotID,
                Altitude = snapshotDTO.Altitude,
                DateTime = snapshotDTO.DateTime,
                Description = snapshotDTO.Description,
                Latitude = snapshotDTO.Latitude,
                Longitude = snapshotDTO.Longitude,
                DroneId = snapshotDTO.DroneId,
            };

            _context.Entry(snapshot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnapshotExists(id))
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

        // POST: api/Snapshots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Snapshot>> PostSnapshot(SnapshotDTO snapshotDTO)
        {
            Snapshot snapshot = new()
            {
                SnapshotID = snapshotDTO.SnapshotID,
                Altitude = snapshotDTO.Altitude,
                DateTime = snapshotDTO.DateTime,
                Description = snapshotDTO.Description,
                Latitude = snapshotDTO.Latitude,
                Longitude = snapshotDTO.Longitude,
                DroneId = snapshotDTO.DroneId,
            };

            _context.Snapshots.Add(snapshot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSnapshot", new { id = snapshot.SnapshotID }, snapshot);
        }

        // DELETE: api/Snapshots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSnapshot(int id)
        {
            var snapshot = await _context.Snapshots.FindAsync(id);
            if (snapshot == null)
            {
                return NotFound();
            }

            _context.Snapshots.Remove(snapshot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Snapshots/image/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=

        [HttpPost("image/{id}")]
        public async Task<IActionResult> PostSnapshotImage(int id, IFormFile file)
        {
            var snapshotRes = await GetSnapshot(id);
            Snapshot? snapshot = snapshotRes.Value;

            if (snapshot == null)
            {
                return NotFound();
            }

            if (file.Length > 0)
            {

                var fileName = file.FileName;
                var fileExtension = Path.GetExtension(fileName);
                var randomFileName = $"{Path.GetRandomFileName()}{fileExtension}";
                
                var saveToPath = Path.Combine(_config.GetValue<string>("StoredFilesPath"), randomFileName);
                //var saveToPath = Path.Combine(_config.GetValue<string>("StoredFilesPath"), fileName);

                using (var stream = System.IO.File.Create(saveToPath))
                {
                    await file.CopyToAsync(stream);
                }

                snapshot.Description = $"/images/{randomFileName}";

                _context.Entry(snapshot).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnapshotExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok();
        }


        private bool SnapshotExists(int id)
        {
            return _context.Snapshots.Any(e => e.SnapshotID == id);
        }



    }
}
