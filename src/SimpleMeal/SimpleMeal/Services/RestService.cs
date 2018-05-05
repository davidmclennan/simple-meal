using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleMeal.Services
{
    public class RestService : IRestService
    {
        readonly HttpClient client = new HttpClient();

        // Look into changing from strings to streams

        /// <summary>
        /// Make web request to address query and deserialize into model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns>Model T from JSON</returns>
        public async Task<T> GetAsync<T>(string query)
        {
            try
            {
                var response = await client.GetStringAsync(query);
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception ex) when (ex.GetType().FullName.StartsWith("Java.Net"))
            {
                //Log exception here
                return default(T);
            }
        }

        /// <summary>
        /// Make web request to address query for JSON array key and deserialize into model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <returns>Model T from JSON</returns>
        public async Task<T> GetAsync<T>(string query, string key)
        {
            try
            {
                var response = await client.GetStringAsync(query);
                var array = JObject.Parse(response).SelectToken(key).ToObject<List<T>>();
                return array.First(); //Use FirsrOrDefault to handle null?
            }
            // No connection (android) gives Java.Net (UnknownHostException) error, can't access specific error in PCL, inherits directly from Exception
            catch (Exception ex) when (ex.GetType().FullName.StartsWith("Java.Net"))
            {
                //Log exception here
                return default(T);
            }
        }

        /// <summary>
        /// Make web request to address query and deserialize into List of model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns>List of model T from JSON</returns>
        public async Task<List<T>> GetAllAsync<T>(string query)
        {
            try
            {
                var response = await client.GetStringAsync(query);
                return JsonConvert.DeserializeObject<List<T>>(response);
            }
            // No connection (android) gives Java.Net (UnknownHostException) error, can't access specific error in PCL, inherits directly from Exception
            catch (Exception ex) when (ex.GetType().FullName.StartsWith("Java.Net"))
            {
                //Log exception here
                return new List<T>();
            }
        }

        /// <summary>
        /// Make web request to address query for JSON array key and deserialize into List of model T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <returns>List of model T from JSON</returns>
        public async Task<List<T>> GetAllAsync<T>(string query, string key)
        {
            try
            {
                var response = await client.GetStringAsync(query);
                return JObject.Parse(response).SelectToken(key).ToObject<List<T>>();
            }
            // No connection (android) gives Java.Net (UnknownHostException) error, can't access specific error in PCL, inherits directly from Exception
            catch (Exception ex) when (ex.GetType().FullName.StartsWith("Java.Net"))
            {
                //Log exception here
                return new List<T>();
            }
        }
    }
}
