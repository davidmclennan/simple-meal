using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.Services;

namespace SimpleMeal.PageModels
{
    public class RecipePageModel : FreshBasePageModel
    {
        IRestService _restService;
        readonly string baseAdress = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=";
        private Recipe _recipe;
        private string _title;

        public int Id { get; set; }

        public Recipe Recipe
        {
            get { return _recipe; }
            set { _recipe = value; RaisePropertyChanged(); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }

        // TEMPORARY SOLUTION
        private string pmThumb;

        public string PmThumb
        {
            get { return pmThumb; }
            set { pmThumb = value; RaisePropertyChanged(); }
        }

        private string pmVideo;

        public string PmVideo
        {
            get { return pmVideo; }
            set { pmVideo = value; RaisePropertyChanged(); }
        }
        // TEMPORARY SOLUTION

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
        }

        public async Task GetRecipe()
        {
            Recipe = await _restService.GetAsync<Recipe>(baseAdress + Id, "meals");
            PmThumb = Recipe.Thumb;
            PmVideo = Recipe.Video;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetRecipe();
        }
    }
}
