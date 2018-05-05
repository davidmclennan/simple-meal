using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleMeal.Models
{
    public class Recipe
    {
        [JsonProperty("strMeal")]
        public string Name { get; set; }

        [JsonProperty("strMealThumb")]
        public string Thumb { get; set; }

        [JsonProperty("idMeal")]
        public int Id { get; set; }

        [JsonProperty("strInstructions")]
        public string Instructions { get; set; }
    }
}
