using BirdWatcherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartBeatController : ControllerBase
    {
        // GET: api/<HeartBeatController>
        [HttpGet]
        public IEnumerable<HeartbeatMessage> Get()
        {
            HeartbeatMessage heartbeatMessage = new HeartbeatMessage();

            heartbeatMessage.RequestDateTime = DateTime.Now;
            heartbeatMessage.ApplicationName = "Birdwatcher Web";
            heartbeatMessage.AppVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            heartbeatMessage.WelcomeMessage = "If you can see this you are successfuly connected to the Bird Watcher API!";

            yield return heartbeatMessage;
        }
    }
}
