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
    public class SunTrackController : Controller
    {
        private readonly BirdWatcherContext _context;
        private readonly IUriService _uriService;
        public SunTrackController(BirdWatcherContext context, IUriService uriService)
        {
            _context = context;
            _uriService= uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.SunTrack
                .Skip((validFilter.PageNumber - 1) * filter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await _context.SunTrack.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<SunTrack>(
                pagedData, 
                validFilter, 
                totalRecords, 
                _uriService, 
                route);

            return Ok(pagedResponse); 
        }

        [Route("latest")]
        [HttpGet]
        public async Task<IActionResult> GetLatest([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.SunTrack
                .OrderByDescending(x => x.Timestamp)
                .Skip((validFilter.PageNumber - 1) * filter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await _context.SunTrack.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<SunTrack>(
                pagedData,
                validFilter,
                totalRecords,
                _uriService,
                route);

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SunTrack>> GetSunTrack(long id)
        {
            var tmpSunTrack = await _context.SunTrack.FirstOrDefaultAsync(x => x.Id == id);

            if(tmpSunTrack == null)
            {
                return NotFound();
            }

            return Ok(new Response<SunTrack>(tmpSunTrack));
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
