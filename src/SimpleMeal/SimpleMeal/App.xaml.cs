using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SimpleMeal.PageModels;

namespace SimpleMeal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var categoryList = FreshMvvm.FreshPageModelResolver.ResolvePageModel<CategoryListPageModel>();
            var navContainer = new FreshMvvm.FreshNavigationContainer(categoryList);
            MainPage = navContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
