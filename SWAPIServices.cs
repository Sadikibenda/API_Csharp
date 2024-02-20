using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToAPI.ConsoleApp.Models;

namespace IntroToAPI.ConsoleApp
{
    public class SWAPIServices
    {
        private readonly HttpClient _httpclient = new HttpClient();

        public async Task<Person> GetPersonAsync(string url)            // async methode always return a Task<>
        {
            /*
            // Get request 
            HttpResponseMessage response = await _httpclient.GetAsync(url);  // used await instead of .Result bcz its async methode 

            if (response.IsSuccessStatusCode)
            {

                Person person = await response.Content.ReadAsAsync<Person>();
                return person;  // return person if response success
            }

            return null; // return null if response is not successfull  */

            return await GetTAsync<Person>(url);  // this is short methode, it will go hunt down it generic methode below.
            
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
             HttpResponseMessage response = await _httpclient.GetAsync(url); 

            if(response.IsSuccessStatusCode)
            {
                Vehicle vehicle = await response.Content.ReadAsAsync<Vehicle>();
                return vehicle;  // return vehicle if response success
            }

            return null; // return null if response is not successfull
        }

        public async Task<T> GetTAsync<T>(string url) where T: class
        {
            HttpResponseMessage response = await _httpclient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }
                // return default; 
            return null;
        }
    }
}