using BirdWatcherWeb.Filter;
using BirdWatcherWeb.Helpers;
using BirdWatcherWeb.Models;
using BirdWatcherWeb.Services.Interface;
using BirdWatcherWeb.Wrappers;
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
        private readonly IUriService _uriService;

        public BirdsController(BirdWatcherContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Birds
                .Skip((validFilter.PageNumber - 1) * filter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await _context.Birds.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<Bird>(
                pagedData,
                validFilter,
                totalRecords,
                _uriService,
                route);

            return Ok(pagedResponse);
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

            return Ok(new Response<Bird>(bird));
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
