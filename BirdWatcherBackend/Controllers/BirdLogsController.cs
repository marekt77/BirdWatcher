using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BirdWatcherBackend.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BirdWatcherBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdLogsController : ControllerBase
    {
        private readonly BirdWatcherContext _context;
        private readonly IHostingEnvironment _env;

        public BirdLogsController(BirdWatcherContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/BirdLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BirdLog>>> GetBirdLog()
        {
            return await _context.BirdLog.ToListAsync();
        }

        // GET: api/BirdLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BirdLog>> GetBirdLog(long id)
        {
            var birdLog = await _context.BirdLog.FindAsync(id);

            if (birdLog == null)
            {
                return NotFound();
            }

            return birdLog;
        }

        // PUT: api/BirdLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBirdLog(long id, BirdLog birdLog)
        {
            if (id != birdLog.BirdLogID)
            {
                return BadRequest();
            }

            _context.Entry(birdLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdLogExists(id))
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

        // POST: api/BirdLogs
        [HttpPost]
        public async Task<ActionResult<BirdLog>> PostBirdLog(BirdLog birdLog)
        {
            _context.BirdLog.Add(birdLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBirdLog", new { id = birdLog.BirdLogID }, birdLog);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PostLogPicture()
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(_env.WebRootPath, "images", "captured", fileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Request.Body.CopyToAsync(fileStream);
                }
            }
            catch(Exception ex)
            {
                //Todo log error
                return StatusCode(500);
            }

            return Ok(fileName);
        }

        // DELETE: api/BirdLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BirdLog>> DeleteBirdLog(long id)
        {
            var birdLog = await _context.BirdLog.FindAsync(id);
            if (birdLog == null)
            {
                return NotFound();
            }

            _context.BirdLog.Remove(birdLog);
            await _context.SaveChangesAsync();

            return birdLog;
        }

        private bool BirdLogExists(long id)
        {
            return _context.BirdLog.Any(e => e.BirdLogID == id);
        }
    }
}
