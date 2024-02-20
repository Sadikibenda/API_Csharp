using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntroToAPI.ConsoleApp.Models
{
    public class SearchResult<T>
    {
        [JsonProperty("count")]
        public int Count {get; set;}

        [JsonProperty("results")]
        public List<T> Results {get; set;}
    }
}