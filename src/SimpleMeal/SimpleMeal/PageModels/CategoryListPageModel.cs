using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreshMvvm;

namespace SimpleMeal.PageModels
{
    class CategoryListPageModel : FreshBasePageModel
    {
        //Switch to FreshAwaitCommand to avoid button mash opening multiple pages

        /// <summary>
        /// Open RecipeListPage passing the category string to determine recipe data query
        /// </summary>
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
