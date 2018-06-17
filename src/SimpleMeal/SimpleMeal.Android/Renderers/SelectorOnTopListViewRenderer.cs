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
using SimpleMeal.Controls;
using SimpleMeal.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SelectorOnTopListView), typeof(SelectorOnTopListViewRenderer))]
namespace SimpleMeal.Droid.Renderers
{
    public class SelectorOnTopListViewRenderer : ListViewRenderer
    {
        public SelectorOnTopListViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            // Works, but isn't clear enough on some images
            // Could customise the tap/hold effect colour
            Control.SetDrawSelectorOnTop(true);
        }
    }
}