using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.Services;
using Xamarin.Forms;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace SimpleMeal.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class RecipePageModel : FreshBasePageModel
    {
        IRestService _restService;
        readonly string baseAdress = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=";

        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsLoading { get; set; }
        public string Title { get; set; }
        public List<string> Instructions { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();

        /// <summary>
        /// Construct and inject rest service
        /// </summary>
        /// <param name="restService"></param>
        public RecipePageModel(IRestService restService)
        {
            _restService = restService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            var partialRecipe = initData as Recipe;
            Id = partialRecipe.Id;
            Title = partialRecipe.Name;
            IsLoading = true;
        }

        public void PopulateIngredients()
        {
            // This is inelegant, but with the way the API is structured it has to be
            // Email API creator about implementing JSON collections

            var tempIngredients = new List<string>
            {
                Recipe.Measure1 + " " + Recipe.Ingredient1,
                Recipe.Measure2 + " " + Recipe.Ingredient2,
                Recipe.Measure3 + " " + Recipe.Ingredient3,
                Recipe.Measure4 + " " + Recipe.Ingredient4,
                Recipe.Measure5 + " " + Recipe.Ingredient5,
                Recipe.Measure6 + " " + Recipe.Ingredient6,
                Recipe.Measure7 + " " + Recipe.Ingredient7,
                Recipe.Measure8 + " " + Recipe.Ingredient8,
                Recipe.Measure9 + " " + Recipe.Ingredient9,
                Recipe.Measure10 + " " + Recipe.Ingredient10,
                Recipe.Measure11 + " " + Recipe.Ingredient11,
                Recipe.Measure12 + " " + Recipe.Ingredient12,
                Recipe.Measure13 + " " + Recipe.Ingredient13,
                Recipe.Measure14 + " " + Recipe.Ingredient14,
                Recipe.Measure15 + " " + Recipe.Ingredient15,
                Recipe.Measure16 + " " + Recipe.Ingredient16,
                Recipe.Measure17 + " " + Recipe.Ingredient17,
                Recipe.Measure18 + " " + Recipe.Ingredient18,
                Recipe.Measure19 + " " + Recipe.Ingredient19,
                Recipe.Measure20 + " " + Recipe.Ingredient20
            };

            tempIngredients.RemoveAll(x => String.IsNullOrWhiteSpace(x));

            Ingredients = tempIngredients;
        }

        public async Task GetRecipe()
        {
            Recipe = await _restService.GetAsync<Recipe>(baseAdress + Id, "meals");
            Instructions = new List<string> { Recipe.Instructions };
            PopulateIngredients();
            IsLoading = false;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetRecipe();
        }
    }
}
