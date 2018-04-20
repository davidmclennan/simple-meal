using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FreshMvvm;
using System.Windows.Input;

namespace SimpleMeal.PageModels
{
    class CategoryListPageModel : FreshBasePageModel
    {
        /// <summary>
        /// Open RecipeListPage passing the category string to determine recipe data query
        /// FreshAwaitCommand and TaskCompletionSource to avoid button mash opening multiple pages
        /// </summary>
        public ICommand OpenCategory
        {
            get
            {
                return new FreshAwaitCommand(async (category, tcs) =>
                {
                    await CoreMethods.PushPageModel<RecipeListPageModel>(category);
                    tcs.SetResult(true);
                });
            }
        }
    }
}
