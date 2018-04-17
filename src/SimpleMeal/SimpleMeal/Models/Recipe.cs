using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleMeal.Models
{
    class Recipe
    {
        [JsonProperty("strMeal")]
        public string Name { get; set; }

        [JsonProperty("strMealThumb")]
        public string Thumb { get; set; }

        [JsonProperty("idMeal")]
        public int Id { get; set; }
    }
}
