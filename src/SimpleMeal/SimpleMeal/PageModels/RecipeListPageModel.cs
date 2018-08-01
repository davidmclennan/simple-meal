using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.Services;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace SimpleMeal.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class RecipeListPageModel : FreshBasePageModel
    {
        IRestService _restService;
        string category;
        readonly string baseAddress = "https://www.themealdb.com/api/json/v1/1/filter.php?c=";
        Recipe _selectedRecipe;

        public ObservableCollection<Recipe> Recipes { get; set; }
        public bool IsLoading { get; set; }

        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                if (value != null)
                {
                    RecipeSelected.Execute(value);
                }
            }
        }

        /// <summary>
        /// Construct and inject rest service
        /// </summary>
        /// <param name="restService"></param>
        public RecipeListPageModel(IRestService restService)
        {
            _restService = restService;
        }

        /// <summary>
        /// Initialise page
        /// </summary>
        /// <param name="initData"></param>
        public override void Init(object initData)
        {
            base.Init(initData);
            category = initData as string;
            CurrentPage.Title = category + " dishes";
            IsLoading = true;
        }

        /// <summary>
        /// Load web data to populate UI
        /// </summary>
        /// <returns></returns>
        public async Task GetRecipes()
        {
            //null category crashes
            Recipes = new ObservableCollection<Recipe>(await _restService.GetAllAsync<Recipe>(baseAddress + category, "meals"));

            // Unsuccessful request returns empty list
            // No results returns empty list
            // For now, handle both same way with infinite activity indicator
            if (Recipes.Count > 0)
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Open RecipePageModel and pass given Recipe
        /// </summary>
        public Command<Recipe> RecipeSelected
        {
            get
            {
                return new Command<Recipe>(async (recipe) =>
                {
                    await CoreMethods.PushPageModel<RecipePageModel>(recipe);
                });
            }
        }

        /// <summary>
        /// Handle view appearing and load web data to populate UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetRecipes();
        }
    }
}
