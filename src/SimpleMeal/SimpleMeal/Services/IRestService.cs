using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMeal.Services
{
    interface IRestService
    {
        Task<List<T>> GetAllAsync<T>(string query);
    }
}
