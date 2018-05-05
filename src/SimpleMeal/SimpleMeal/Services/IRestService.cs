using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMeal.Services
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string query);
        Task<T> GetAsync<T>(string query, string key);
        Task<List<T>> GetAllAsync<T>(string query);
        Task<List<T>> GetAllAsync<T>(string query, string key);
    }
}
