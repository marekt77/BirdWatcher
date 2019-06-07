using BirdWatcherBackend.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace BirdWatcherBackend.Setup
{
    public static class InitialDB_Setup
    {
        public static void SeedDB(BirdWatcherContext context, IHostingEnvironment env)
        {
            context.Database.EnsureCreated();

            if (context.Birds.Any())
            {
                return;
            }

            string jsonPath = Path.Combine(env.ContentRootPath, @"Data\birds.json");

            using (StreamReader myReader = new StreamReader(jsonPath))
            {

                string tmpJson = myReader.ReadToEnd();
                ExampleBirds myExampleBirds = JsonConvert.DeserializeObject<ExampleBirds>(tmpJson);

                foreach(ExampleBird tmpEB in myExampleBirds.birds)
                {
                    Bird tmpBird = new Bird();
                    tmpBird.Name = tmpEB.name;
                    tmpBird.ExamplePicture = tmpEB.image;

                    context.Add(tmpBird);
                }

                context.SaveChanges();
            }

        }
    }
}
