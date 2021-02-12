using BirdWatcherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatcherHealthController : ControllerBase
    {
        private readonly BirdWatcherContext _context;

        public WatcherHealthController(BirdWatcherContext context)
        {
            _context = context;
        }

        //GET: api/<WatcherHealthCheckController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatcherHealthCheck>>> GetWatcherHealth()
        {
            return await _context.WatcherHealthCheck.ToListAsync();
        }

        //GET: api/<WatcherHealthCheckController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatcherHealthCheck>> GetWatcherHealth(long id)
        {
            var watcherHealthCheck = await _context.WatcherHealthCheck.FindAsync(id);

            if(watcherHealthCheck == null)
            {
                return NotFound();
            }

            return watcherHealthCheck;
        }

        // POST api/<WatcherHealthCheckController>
        [HttpPost]
        public async Task<ActionResult<WatcherHealthCheck>> PostWatcherHealthCheck(WatcherHealthCheck watcherHealthCheck)
        {
            _context.WatcherHealthCheck.Add(watcherHealthCheck);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatcherHealthCheck", new { id = watcherHealthCheck.Id }, watcherHealthCheck);
        }
    }
}
