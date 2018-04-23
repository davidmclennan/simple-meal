using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SimpleMeal.Models;

namespace SimpleMeal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipeListPageCell : ViewCell
	{
		public RecipeListPageCell ()
		{
			InitializeComponent ();
		}

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var recipe = BindingContext as Recipe;
            if (recipe == null)
                return;

            Image.Source = recipe.Thumb;
            Label.Text = recipe.Name;
        }
    }
}