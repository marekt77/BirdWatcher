using BirdWatcherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunTrackController : ControllerBase
    {
        private readonly BirdWatcherContext _context;

        public SunTrackController(BirdWatcherContext context)
        {
            _context = context;
        }

        // GET: api/<SunTrackController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SunTrack>>> GetSunTrack()
        {
            return await _context.SunTrack.ToListAsync();
        }

        // GET api/<SunTrackController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SunTrack>> GetSunTrack(long id)
        {
            var sunTrack = await _context.SunTrack.FindAsync(id);

            if(sunTrack == null)
            {
                return NotFound();
            }

            return sunTrack;
        }

        // POST api/<SunTrackController>
        [HttpPost]
        public async Task<ActionResult<SunTrack>> PostSunTrack(SunTrack sunTrack)
        {
            _context.SunTrack.Add(sunTrack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSunTrack", new { id = sunTrack.Id }, sunTrack);
        }

        /*
        // PUT api/<SunTrackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<SunTrackController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SunTrack>> DeleteSunTrack(long id)
        {
            var sunTrack = await _context.SunTrack.FindAsync(id);

            if(sunTrack == null)
            {
                return NotFound();
            }

            _context.Remove(sunTrack);
            await _context.SaveChangesAsync();

            return sunTrack;
        }
    }
}
