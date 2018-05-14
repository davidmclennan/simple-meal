﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms;
using CarouselView.FormsPlugin.Android;

namespace SimpleMeal.Droid
{
    [Activity(Label = "SimpleMeal", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.SetFlags("FastRenderers_Experimental");
            CachedImageRenderer.Init(true);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}

