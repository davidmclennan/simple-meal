using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMeal.Services
{
    interface IRestService
    {
        Task<IList<T>> GetAllAsync<T>(string query);
        Task<IList<T>> GetAllAsync<T>(string query, string key);
    }
}
