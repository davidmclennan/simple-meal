using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.Services;
using Xamarin.Forms;

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

        private bool instructionsSelected;

        public bool InstructionsSelected
        {
            get { return instructionsSelected; }
            set { instructionsSelected = value; RaisePropertyChanged(); }
        }

        private bool ingredientsSelected;

        public bool IngredientsSelected
        {
            get { return ingredientsSelected; }
            set { ingredientsSelected = value; RaisePropertyChanged(); }
        }

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
            InstructionsSelected = true;
            IngredientsSelected = false;
        }

        public async Task GetRecipe()
        {
            Recipe = await _restService.GetAsync<Recipe>(baseAdress + Id, "meals");
            PmThumb = Recipe.Thumb;
            PmVideo = Recipe.Video;
        }

        public Command<bool> SelectTab
        {
            get
            {
                return new Command<bool>((state) =>
                {
                    if (state)
                        return;

                    if (InstructionsSelected)
                    {
                        InstructionsSelected = false;
                        IngredientsSelected = true;
                    }
                    else
                    {
                        InstructionsSelected = true;
                        IngredientsSelected = false;
                    }
                });
            }
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetRecipe();
        }
    }
}
