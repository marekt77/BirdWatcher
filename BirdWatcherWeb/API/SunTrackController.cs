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
    public class SunTrackController : Controller
    {
        private readonly BirdWatcherContext _context;

        public SunTrackController(BirdWatcherContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SunTrack>>> GetSunTrack()
        {
            return await _context.SunTrack.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SunTrack>> GetSunTrack(long id)
        {
            var tmpSunTrack = await _context.SunTrack.FirstOrDefaultAsync(x => x.Id == id);

            if(tmpSunTrack == null)
            {
                return NotFound();
            }

            return Ok(tmpSunTrack);
        }

        [HttpPost]
        public async Task<ActionResult<SunTrack>> PostSunTrack(SunTrack tmpSunTrack)
        {
            _context.SunTrack.Add(tmpSunTrack);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSunTrack", new {id = tmpSunTrack.Id}, tmpSunTrack);
        }
    }
}
