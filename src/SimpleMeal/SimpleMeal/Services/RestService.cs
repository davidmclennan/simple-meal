using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleMeal.Services
{
    class RestService : IRestService
    {
        //Look into changing from strings to streams

        /// <summary>
        /// Make web request to address query and deserialize into IList of model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns>IList of model T from JSON</returns>
        public async Task<IList<T>> GetAllAsync<T>(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(query);
                return JsonConvert.DeserializeObject<IList<T>>(response);
            }
        }

        /// <summary>
        /// Make web request to address query for JSON array key and deserialize into IList of model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns>IList of model T from JSON</returns>
        public async Task<IList<T>> GetAllAsync<T>(string query, string key)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(query);
                    return JObject.Parse(response).SelectToken(key).ToObject<IList<T>>();
                }
            }
            catch (Exception ex)
            {
                //No connection gives Java.Net errors - inherits directly from Exception and can't access in PCL
                //Can use reflection - bad?
                return null;
            }
        }
    }
}
