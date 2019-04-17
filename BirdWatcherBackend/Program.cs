using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BirdWatcherBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((WebHostBuilderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile("secretConfig.json", optional: false, reloadOnChange: true);
                })
                .UseUrls("http://*:5000")
                .UseStartup<Startup>();
    }
}
