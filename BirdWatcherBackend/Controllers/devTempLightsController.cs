using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirdWatcherBackend.Models;

namespace BirdWatcherBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devTempLightsController : ControllerBase
    {
        private readonly BirdWatcherContext _context;

        public devTempLightsController(BirdWatcherContext context)
        {
            _context = context;
        }

        // GET: api/devTempLights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<devTempLight>>> GetdevTempLight()
        {
            return await _context.devTempLight.ToListAsync();
        }

        // GET: api/devTempLights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<devTempLight>> GetdevTempLight(long id)
        {
            var devTempLight = await _context.devTempLight.FindAsync(id);

            if (devTempLight == null)
            {
                return NotFound();
            }

            return devTempLight;
        }

        // PUT: api/devTempLights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdevTempLight(long id, devTempLight devTempLight)
        {
            if (id != devTempLight.Id)
            {
                return BadRequest();
            }

            _context.Entry(devTempLight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!devTempLightExists(id))
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

        // POST: api/devTempLights
        [HttpPost]
        public async Task<ActionResult<devTempLight>> PostdevTempLight(devTempLight devTempLight)
        {
            _context.devTempLight.Add(devTempLight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdevTempLight", new { id = devTempLight.Id }, devTempLight);
        }

        // DELETE: api/devTempLights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<devTempLight>> DeletedevTempLight(long id)
        {
            var devTempLight = await _context.devTempLight.FindAsync(id);
            if (devTempLight == null)
            {
                return NotFound();
            }

            _context.devTempLight.Remove(devTempLight);
            await _context.SaveChangesAsync();

            return devTempLight;
        }

        private bool devTempLightExists(long id)
        {
            return _context.devTempLight.Any(e => e.Id == id);
        }
    }
}
