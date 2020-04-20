﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Syncfusion.SfBusyIndicator.XForms.Droid;
using Syncfusion.SfCalendar.XForms.Droid;
using Syncfusion.XForms.Android.Border;
using Syncfusion.XForms.Android.ComboBox;

namespace ViaticosPrism.Droid
{
    [Activity(Label = "Viaticos", 
        Icon = "@mipmap/ic_launcher", 
        Theme = "@style/MainTheme",
        MainLauncher = false, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            new SfBusyIndicatorRenderer();
            //new SfComboBoxRenderer();
            new SfCalendarRenderer();
            
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true); // Init Nuget 
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

