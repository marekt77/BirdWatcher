using BirdWatcherMobileApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    class MockBirdExampleDataService : IKnownBirdsService<Bird>
    {
        private async Task<List<Bird>> LoadBirds()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppShell)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("BirdWatcherMobileApp.SampleData.birds.json");

            using (var reader = new StreamReader(stream))
            {
                var json = await reader.ReadToEndAsync();

                var myBirds = JsonConvert.DeserializeObject<List<Bird>>(json);
               
                return myBirds;
            }
        }

        public async Task<Bird> GetKnownBirdAsync(long id)
        {
            var myBirds = await LoadBirds();

            Bird rtnBird = myBirds.Find(x => x.BirdID == id);

            return rtnBird;
        }

        public async Task<IEnumerable<Bird>> GetKnownBirdsAsync()
        {
            var myBirds = await LoadBirds();

            IEnumerable<Bird> rtnBirds = myBirds;

            return rtnBirds;
        }
    }
}
