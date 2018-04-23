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

namespace SimpleMeal.PageModels
{
    class RecipeListPageModel : FreshBasePageModel
    {
        IRestService _restService;
        string category;
        readonly string baseAddress = "https://www.themealdb.com/api/json/v1/1/filter.php?c=";
        ObservableCollection<Recipe> _recipes;
        bool _isLoading;
        string _title;

        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set { _recipes = value; RaisePropertyChanged(); }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
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
            Title = category + " dishes";
            IsLoading = true;
        }

        /// <summary>
        /// Handle view appearing and load web data to populate UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Recipes = new ObservableCollection<Recipe>(await _restService.GetAllAsync<Recipe>(baseAddress + category, "meals"));
            IsLoading = false;
        }
    }
}
