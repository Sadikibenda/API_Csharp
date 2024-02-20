using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToAPI.ConsoleApp.Models;
using Newtonsoft.Json;

namespace IntroToAPI.ConsoleApp 
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

          HttpResponseMessage response = httpClient.GetAsync("http://swapi.dev/api/people/1").Result;

          if (response.IsSuccessStatusCode)
          {
           // var content = response.Content.ReadAsStringAsync().Result;

            // this line below were added after working on model folder(person class)!!
          //  var person = JsonConvert.DeserializeObject<Person>(content);

            Person luke = response.Content.ReadAsAsync<Person>().Result; // used to examine or (parse out)
            Console.WriteLine(luke.Name);

            foreach(string vehiclesUrl in luke.Vehicles)
            {
                HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehiclesUrl).Result;
               // Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);

                Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result; // used to examine or (parse out)
                Console.WriteLine(vehicle.Name);
            }
          }
                    Console.WriteLine();   // to separate
                    
               // Create new instance of SWAPIService in program file
                SWAPIServices services = new SWAPIServices();
                Person person = services.GetPersonAsync("http://swapi.dev/api/people/11").Result;

                if (person != null)
                {
                    Console.WriteLine(person.Name);

                    foreach(var vehicleUrl in person.Vehicles)
                    {
                        var vehicle = services.GetVehicleAsync(vehicleUrl).Result;
                        Console.WriteLine(vehicle.Name);
                    }
                }

                        Console.WriteLine();

               // var genericResponse = services.GetTAsync<Vehicle>("http://swapi.dev/api/vehicles/4").Result;
                var genericResponse = services.GetTAsync<Person>("http://swapi.dev/api/people/4").Result;
                if (genericResponse != null)
                {
                    Console.WriteLine(genericResponse.Name);
                }
                else{
                    Console.WriteLine("Target object does not exist.");
                }

                Console.WriteLine();
                
                var person2Response = services.GetPersonAsync("https://swapi.dev/api/people/5").Result;
                if(person2Response != null)
                {
                    Console.WriteLine(person2Response.Name);
                }
                else
                {
                    Console.WriteLine("Target object does not exist.");
                }
                Console.WriteLine();


        }
    }
}

