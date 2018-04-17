using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleMeal.Services
{
    class RestService : IRestService
    {
        public async Task<List<T>> GetAllAsync<T>(string query)
        {
            using (HttpClient client = new HttpClient())
            using (Stream s = await client.GetStreamAsync(query))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                // read the json from a stream
                // json size doesn't matter because only a small piece is read at a time from the HTTP request
                return serializer.Deserialize<List<T>>(reader);
            }
        }
    }
}
