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

[assembly: ResolutionGroupName("SimpleMeal")]
[assembly: ExportEffect(typeof(NativePaddingEffect), "NativePaddingEffect")]
namespace SimpleMeal.Droid.Effects
{
    public class NativePaddingEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null)
                Control.SetPadding(50, 50, 50, 50);
        }

        protected override void OnDetached()
        {
        }
    }
}