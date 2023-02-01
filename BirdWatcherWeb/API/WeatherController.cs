using BirdWatcherWeb.Models;
using BirdWatcherWeb.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BirdWatcherWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IUriService _uriService;
        private Uri _baseUri;
        public IConfiguration _configuration { get; }

        public WeatherController(IUriService uriService, IConfiguration configuration)
        {
            _uriService = uriService;
            _configuration = configuration;
            _baseUri = new Uri("http://" + _configuration.GetSection("BirdWatcherIP").Value);
        }

        [Route("temperature")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient _client = new HttpClient();
            Temp temp = new Temp();

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                httpResponse = await _client.GetAsync(_baseUri + "api/temperature");

                if(httpResponse.IsSuccessStatusCode)
                {
                    string rawResult = await httpResponse.Content.ReadAsStringAsync();

                    temp = JsonConvert.DeserializeObject<Temp>(rawResult);
                }
            }
            catch (Exception ex)
            {
                _client.Dispose();
                throw new Exception("ERROR! Cannot retrive Tempurature");
            }

            return Ok(temp);
        }
    }
}
