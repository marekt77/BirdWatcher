using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirdWatcherBackend.Models;

namespace BirdWatcherBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdLogBirdsController : ControllerBase
    {
        private readonly BirdWatcherContext _context;

        public BirdLogBirdsController(BirdWatcherContext context)
        {
            _context = context;
        }

        // GET: api/BirdLogBirds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BirdLogBird>>> GetBirdLogBird()
        {
            return await _context.BirdLogBird.ToListAsync();
        }

        // GET: api/BirdLogBirds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BirdLogBird>> GetBirdLogBird(long id)
        {
            var birdLogBird = await _context.BirdLogBird.FindAsync(id);

            if (birdLogBird == null)
            {
                return NotFound();
            }

            return birdLogBird;
        }

        // PUT: api/BirdLogBirds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBirdLogBird(long id, BirdLogBird birdLogBird)
        {
            if (id != birdLogBird.BirdID)
            {
                return BadRequest();
            }

            _context.Entry(birdLogBird).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdLogBirdExists(id))
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

        // POST: api/BirdLogBirds
        [HttpPost]
        public async Task<ActionResult<BirdLogBird>> PostBirdLogBird(BirdLogBird birdLogBird)
        {
            _context.BirdLogBird.Add(birdLogBird);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BirdLogBirdExists(birdLogBird.BirdID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBirdLogBird", new { id = birdLogBird.BirdID }, birdLogBird);
        }

        // DELETE: api/BirdLogBirds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BirdLogBird>> DeleteBirdLogBird(long id)
        {
            var birdLogBird = await _context.BirdLogBird.FindAsync(id);
            if (birdLogBird == null)
            {
                return NotFound();
            }

            _context.BirdLogBird.Remove(birdLogBird);
            await _context.SaveChangesAsync();

            return birdLogBird;
        }

        private bool BirdLogBirdExists(long id)
        {
            return _context.BirdLogBird.Any(e => e.BirdID == id);
        }
    }
}
