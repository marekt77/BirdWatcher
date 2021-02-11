using BirdWatcherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly BirdWatcherContext _context;

        public BirdsController(BirdWatcherContext context)
        {
            _context = context;
        }

        // GET: api/Birds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bird>>> GetBirds()
        {
            return await _context.Birds.ToListAsync();
        }

        // GET: api/Birds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bird>> GetBird(long id)
        {
            var bird = await _context.Birds.FindAsync(id);

            if (bird == null)
            {
                return NotFound();
            }

            return bird;
        }

        /*
        // PUT: api/Birds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBird(long id, Bird bird)
        {
            if (id != bird.BirdID)
            {
                return BadRequest();
            }

            _context.Entry(bird).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdExists(id))
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

        // POST: api/Birds
        [HttpPost]
        public async Task<ActionResult<Bird>> PostBird(Bird bird)
        {
            _context.Birds.Add(bird);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBird", new { id = bird.BirdID }, bird);
        }

        
        // DELETE: api/Birds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bird>> DeleteBird(long id)
        {
            var bird = await _context.Birds.FindAsync(id);
            if (bird == null)
            {
                return NotFound();
            }

            _context.Birds.Remove(bird);
            await _context.SaveChangesAsync();

            return bird;
        }*/

        private bool BirdExists(long id)
        {
            return _context.Birds.Any(e => e.BirdID == id);
        }
    }
}
