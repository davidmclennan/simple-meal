using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimpleMeal.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ListViewSelectorTopEffect), "ListViewSelectorTopEffect")]
namespace SimpleMeal.Droid.Effects
{
    public class ListViewSelectorTopEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var listView = Control as AbsListView;

                if (listView != null)
                    listView.SetDrawSelectorOnTop(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}