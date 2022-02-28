using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


/*
 *  Fidel Ojimba
 *  Web API to get a description of the locations used in Studio Ghibli fims
 *  Runs but doesn't retrieve information
 */


namespace WebAPIAssignment
{
    class Location
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }
        
        [JsonProperty("surface_water")]
        public string Surface_Water { get; set; }

    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter movie location. Press Enter without writing a name to quit the program.");      // write the request for a movie name to console

                    var locationName = Console.ReadLine();     // take the name and store in the movie name variable

                    if (string.IsNullOrEmpty(locationName))        // this is how we quit if the name is empty and enter is pressed
                    {
                        break;
                    }

                    var result = await client.GetAsync("https://ghibliapi.herokuapp.com/locations/" + locationName.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();
                    var location = JsonConvert.DeserializeObject<Location>(resultRead);

                    Console.WriteLine("___");
                    Console.WriteLine("ID: " + location.Id);
                    Console.WriteLine("name: " + location.Name);
                    Console.WriteLine("climate: " + location.Climate);
                    Console.WriteLine("terrain: " + location.Terrain);
                    Console.WriteLine("Surface Water: " + location.Surface_Water);
                    Console.WriteLine("\n---");
                }
                catch(Exception)
                {
                    Console.WriteLine("ERROR. Please enter a valid movie name!");
                }
            }
        }
    }
}