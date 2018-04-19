using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.Services;

namespace SimpleMeal.PageModels
{
    class RecipeListPageModel : FreshBasePageModel
    {
        IRestService _restService;
        string baseAddress = "https://www.themealdb.com/api/json/v1/1/filter.php?c=";
        string category;

        public RecipeListPageModel(IRestService restService)
        {
            _restService = restService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            category = initData as string;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            List<Recipe> a = await _restService.GetAllAsync<Recipe>(baseAddress + category, "meals");
        }
    }
}
