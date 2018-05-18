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

        [JsonProperty("strYoutube")]
        public string Video { get; set; }

        [JsonProperty("strInstructions")]
        public string Instructions { get; set; }

        // This is inelegant, but with the way the API is structured it has to be
        // Email API creator about implementing JSON collections

        // Ingredients

        [JsonProperty("strIngredient1")]
        public string Ingredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string Ingredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string Ingredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string Ingredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string Ingredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string Ingredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string Ingredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string Ingredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string Ingredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string Ingredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string Ingredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string Ingredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string Ingredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string Ingredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string Ingredient15 { get; set; }

        [JsonProperty("strIngredient16")]
        public string Ingredient16 { get; set; }

        [JsonProperty("strIngredient17")]
        public string Ingredient17 { get; set; }

        [JsonProperty("strIngredient18")]
        public string Ingredient18 { get; set; }

        [JsonProperty("strIngredient19")]
        public string Ingredient19 { get; set; }

        [JsonProperty("strIngredient20")]
        public string Ingredient20 { get; set; }

        //Measures

        [JsonProperty("strMeasure1")]
        public string Measure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string Measure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string Measure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string Measure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string Measure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string Measure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string Measure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string Measure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string Measure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string Measure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string Measure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string Measure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string Measure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string Measure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string Measure15 { get; set; }

        [JsonProperty("strMeasure16")]
        public string Measure16 { get; set; }

        [JsonProperty("strMeasure17")]
        public string Measure17 { get; set; }

        [JsonProperty("strMeasure18")]
        public string Measure18 { get; set; }

        [JsonProperty("strMeasure19")]
        public string Measure19 { get; set; }

        [JsonProperty("strMeasure20")]
        public string Measure20 { get; set; }
    }
}
