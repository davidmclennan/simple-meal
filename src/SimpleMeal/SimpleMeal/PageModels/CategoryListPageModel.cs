using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreshMvvm;

namespace SimpleMeal.PageModels
{
    class CategoryListPageModel : FreshBasePageModel
    {
        public Command OpenCategory
        {
            get
            {
                return new Command(async (category) =>
                {
                    await CoreMethods.PushPageModel<RecipeListPageModel>(category);
                });
            }
        }
    }
}
