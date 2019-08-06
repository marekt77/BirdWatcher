using System;
using System.Reflection;
using System.Runtime.InteropServices;
using BirdWatcherBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdWatcherBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdWatcherController : ControllerBase
    {
        // GET: api/BirdWatcher
        [HttpGet]
        public ActionResult<BirdWatcher> Get()
        {
            BirdWatcher myBirdWatcher = new BirdWatcher();

            myBirdWatcher.RequestDateTime = DateTime.Now;
            myBirdWatcher.ApplicationName = "BirdWatcher API";
            myBirdWatcher.AppVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            myBirdWatcher.WelcomeMessage = "If you can see this you are successfuly connected to the Bird Watcher API!";
            myBirdWatcher.ServerOS = RuntimeInformation.OSDescription;

            return myBirdWatcher;
        }
    }
}
