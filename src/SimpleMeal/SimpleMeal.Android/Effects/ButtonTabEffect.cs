using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SimpleMeal.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ButtonTabEffect), "ButtonTabEffect")]
namespace SimpleMeal.Droid.Effects
{
    public class ButtonTabEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var button = Control as AppCompatButton;

                if (button != null)
                    button.Background = ContextCompat.GetDrawable(button.Context, Resource.Drawable.btn_tab_selector);
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