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
            var effect = (SimpleMeal.Effects.NativePaddingEffect)Element.Effects.FirstOrDefault(e => e is SimpleMeal.Effects.NativePaddingEffect);
            if (effect != null)
            {
                var left = (int)effect.NativePadding.Left;
                var top = (int)effect.NativePadding.Top;
                var right = (int)effect.NativePadding.Right;
                var bottom = (int)effect.NativePadding.Bottom;

                if (Control != null)
                    Control.SetPadding(left, top, right, bottom);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}