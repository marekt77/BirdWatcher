using BirdWatcherWeb.Models;
using BirdWatcherWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdLogController : ControllerBase
    {
        private readonly BirdWatcherContext _context;
        private readonly IWebHostEnvironment _env;

        public BirdLogController(BirdWatcherContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/BirdLog
        [HttpGet]
        public async Task<ActionResult<PagedBirdLogVM>> GetBirdLog(int page = 1, int pageSize = 100)
        {
            List<BirdLogVM> tmpBirgLogsVM = new List<BirdLogVM>();

            PagedBirdLogVM tmpPagedBirdLogVM = new PagedBirdLogVM();

            var query = _context.BirdLog
                .Include(e => e.BirdLogBird)
                .ThenInclude(e => e.Bird);

            var entries = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = await query.CountAsync();

            var totalPages = (int)Math.Ceiling(count / (float)pageSize);

            tmpPagedBirdLogVM.PagingHeader = new PagingHeader(count, page, pageSize, totalPages);

            foreach (BirdLog tmpBL in entries)
            {
                BirdLogVM tmpBLvm = new BirdLogVM();

                tmpBLvm.BirdLogID = tmpBL.BirdLogID;
                tmpBLvm.Location_latitude = tmpBL.Location_latitude;
                tmpBLvm.location_longitude = tmpBL.location_longitude;
                tmpBLvm.Picture = tmpBL.Picture;
                tmpBLvm.Temperature = tmpBL.Temperature;
                tmpBLvm.Timestamp = tmpBL.Timestamp;
                tmpBLvm.UserGUID = tmpBL.UserGUID;

                tmpBLvm.Birds = new List<long>();

                foreach (BirdLogBird tmpBLB in tmpBL.BirdLogBird)
                {
                    tmpBLvm.Birds.Add(tmpBLB.BirdID);
                }

                tmpBirgLogsVM.Add(tmpBLvm);
            }

            tmpPagedBirdLogVM.Items = tmpBirgLogsVM;

            return tmpPagedBirdLogVM;
        }

        // GET: api/BirdLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BirdLogVM>> GetBirdLog(long id)
        {
            var tmpBirdLog = await _context.BirdLog
                .Where(x => x.BirdLogID == id)
                .Include(e => e.BirdLogBird)
                .ThenInclude(e => e.Bird)
                .FirstAsync();

            if (tmpBirdLog == null)
            {
                return NotFound();
            }

            BirdLogVM tmpBirgLogsVM = new BirdLogVM();

            tmpBirgLogsVM.BirdLogID = tmpBirdLog.BirdLogID;
            tmpBirgLogsVM.Location_latitude = tmpBirdLog.Location_latitude;
            tmpBirgLogsVM.location_longitude = tmpBirdLog.location_longitude;
            tmpBirgLogsVM.Picture = tmpBirdLog.Picture;
            tmpBirgLogsVM.Temperature = tmpBirdLog.Temperature;
            tmpBirgLogsVM.Timestamp = tmpBirdLog.Timestamp;
            tmpBirgLogsVM.UserGUID = tmpBirdLog.UserGUID;

            tmpBirgLogsVM.Birds = new List<long>();

            foreach (BirdLogBird tmpBLB in tmpBirdLog.BirdLogBird)
            {
                tmpBirgLogsVM.Birds.Add(tmpBLB.BirdID);
            }

            return tmpBirgLogsVM;
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
        public async Task<ActionResult<BirdLog>> PostBirdLog(BirdLogVM birdLog)
        {
            BirdLog tmpBirdLog = new BirdLog();

            tmpBirdLog.Location_latitude = birdLog.Location_latitude;
            tmpBirdLog.location_longitude = birdLog.location_longitude;
            tmpBirdLog.Picture = birdLog.Picture;
            tmpBirdLog.Temperature = birdLog.Temperature;
            tmpBirdLog.Timestamp = birdLog.Timestamp;
            tmpBirdLog.UserGUID = birdLog.UserGUID;

            foreach (long x in birdLog.Birds)
            {
                var tmpBird = _context.Birds.Find(x);

                var tmpBLB = new BirdLogBird();

                tmpBLB.Bird = tmpBird;
                tmpBLB.BirdLog = tmpBirdLog;


                if (tmpBird.BirdLogBird == null)
                {
                    tmpBird.BirdLogBird = new List<BirdLogBird>();
                }

                tmpBird.BirdLogBird.Add(tmpBLB);
            }

            _context.BirdLog.Add(tmpBirdLog);

            await _context.SaveChangesAsync();

            birdLog.BirdLogID = tmpBirdLog.BirdLogID;

            return CreatedAtAction("GetBirdLog", new { id = birdLog.BirdLogID }, birdLog);
        }

        // Post: api/LogPicture
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LogPicture()
        {
            string fileType;

            //Check Content type
            switch (Request.ContentType)
            {
                case "image/jpeg":
                    fileType = ".jpg";
                    break;
                case "image/png":
                    fileType = ".png";
                    break;
                case "image/gif":
                    fileType = ".gif";
                    break;
                default:
                    fileType = ".jpg";
                    break;
            }

            string fileName = Guid.NewGuid().ToString() + fileType;
            string filePath = Path.Combine(_env.WebRootPath, "images", "captured", fileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Request.Body.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                //Todo log error
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500);
            }

            return Ok(fileName);
        }

        /*
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
        }*/

        private bool BirdLogExists(long id)
        {
            return _context.BirdLog.Any(e => e.BirdLogID == id);
        }
    }
}
