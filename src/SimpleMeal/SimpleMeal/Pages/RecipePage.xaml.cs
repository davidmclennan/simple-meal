using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMeal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipePage : ContentPage
	{
		public RecipePage ()
		{
			InitializeComponent ();
		}

        private void SwitchTab(object sender, EventArgs e)
        {
            instructionsButton.IsEnabled = !instructionsButton.IsEnabled;
            ingredientsButton.IsEnabled = !ingredientsButton.IsEnabled;
        }
    }
}